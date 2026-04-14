using System.Text.Json;
using System.Text.RegularExpressions;
using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.Infrastructure;

public sealed class OllamaComponentClassifier(IOllamaClient ollamaClient) : IComponentClassifier
{
    private const int MaxRetriesPerRow = 4;
    private const int NumPredict = 160;

    private static readonly HashSet<string> AllowedComponents = new(ArchitectureComponents.Allowed, StringComparer.Ordinal);
    private static readonly Dictionary<string, string> ComponentAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        ["presentation"] = "Presentation / UI",
        ["ui"] = "Presentation / UI",
        ["controller"] = "Controller / API / Interface",
        ["api"] = "Controller / API / Interface",
        ["interface"] = "Controller / API / Interface",
        ["business logic"] = "Business Logic / Application Services",
        ["application services"] = "Business Logic / Application Services",
        ["domain model"] = "Domain Models",
        ["domain models"] = "Domain Models",
        ["state management"] = "State Management",
        ["data access"] = "Data Access / Database",
        ["database"] = "Data Access / Database",
        ["network"] = "Network / Communication / Protocol",
        ["communication"] = "Network / Communication / Protocol",
        ["protocol"] = "Network / Communication / Protocol",
        ["infrastructure"] = "Infrastructure / Platform",
        ["platform"] = "Infrastructure / Platform",
        ["config"] = "Configuration",
        ["configuration"] = "Configuration",
        ["security"] = "Security / Authentication / Authorization",
        ["authentication"] = "Security / Authentication / Authorization",
        ["authorization"] = "Security / Authentication / Authorization",
        ["logging"] = "Logging / Monitoring",
        ["monitoring"] = "Logging / Monitoring",
        ["utilities"] = "Utilities / Shared",
        ["shared"] = "Utilities / Shared",
        ["integration"] = "Integration / External Systems",
        ["mapper"] = "Mapping / Translation",
        ["mapping"] = "Mapping / Translation",
        ["translation"] = "Mapping / Translation",
        ["transformer"] = "Transformation / Processing",
        ["processing"] = "Transformation / Processing",
        ["serialization"] = "Serialization / Deserialization",
        ["deserialization"] = "Serialization / Deserialization",
        ["compression"] = "Compression / Archiving",
        ["archiving"] = "Compression / Archiving",
        ["jobs"] = "Scheduling / Jobs / Workers",
        ["workers"] = "Scheduling / Jobs / Workers",
        ["unclassified"] = "Unclassified"
    };

    public OllamaComponentClassifier(IOllamaClient ollamaClient, IArtifactStore artifactStore)
        : this(ollamaClient)
    {
    }

    public async Task<IReadOnlyList<SourceSymbol>> ClassifyAsync(IReadOnlyList<SourceSymbol> symbols, string introduction, string model, PipelineContext context, CancellationToken cancellationToken)
    {
        var output = new List<SourceSymbol>(symbols.Count);
        var allowed = string.Join("\n- ", ArchitectureComponents.Allowed);

        for (var i = 0; i < symbols.Count; i++)
        {
            var symbol = symbols[i];
            var classified = await ClassifySingleAsync(symbol, introduction, model, allowed, context, i + 1, cancellationToken).ConfigureAwait(false);
            output.Add(classified);
        }

        return output;
    }

    private async Task<SourceSymbol> ClassifySingleAsync(SourceSymbol symbol, string introduction, string model, string allowed, PipelineContext context, int rowNumber, CancellationToken cancellationToken)
    {
        var userPrompt = BuildUserPrompt(symbol, introduction, allowed);
        var lastResponse = string.Empty;
        var lastError = string.Empty;

        for (var attempt = 1; attempt <= MaxRetriesPerRow; attempt++)
        {
            try
            {
                var response = await ollamaClient.ChatAsync(model, "You classify architecture components.", userPrompt, new OllamaCallContext("classification", rowNumber, attempt, IsRepair: attempt > 1), cancellationToken).ConfigureAwait(false);
                lastResponse = response.Content ?? string.Empty;
                SaveArtifacts(context, rowNumber, attempt, userPrompt, response);
                var (component, description) = ParseTextResult(response.Content ?? string.Empty);
                return symbol with
                {
                    ComponentName = component,
                    Category = ArchitectureComponents.Technical.Contains(component) ? "technical" : "functional",
                    LineDescription = description
                };
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
                userPrompt = BuildRepairPrompt(symbol, lastResponse, lastError);
                if (attempt == MaxRetriesPerRow)
                {
                    break;
                }
            }
        }

        return symbol with
        {
            ComponentName = "Unclassified",
            Category = "mixed",
            LineDescription = string.IsNullOrWhiteSpace(lastError) ? "Classification failed." : $"Classification failed: {lastError}"
        };
    }

    private static string BuildUserPrompt(SourceSymbol symbol, string introduction, string allowed)
    {
        return $"""
Classify this one symbol row.

Project context:
{introduction}

Allowed components:
- {allowed}

Symbol row:
{symbol.File} | {symbol.Kind} | {symbol.Name} | {symbol.QualifiedName} | {symbol.StartLine} | {symbol.EndLine} | {symbol.Parent} | {symbol.DataType} | {symbol.DataShape} | {symbol.Signature}

Return exactly:
COMPONENT: <one allowed component name>
DESCRIPTION: <short description>
""";
    }

    private static string BuildRepairPrompt(SourceSymbol symbol, string previousResponse, string errorMessage)
    {
        return $"""
Your previous response was invalid.

Validation error:
{errorMessage}

Previous response:
{previousResponse}

Re-classify this one symbol row.

Return exactly these two lines and nothing else:
COMPONENT: <one allowed component name>
DESCRIPTION: <short description>

Symbol row:
{symbol.File} | {symbol.Kind} | {symbol.Name} | {symbol.QualifiedName} | {symbol.StartLine} | {symbol.EndLine} | {symbol.Parent} | {symbol.DataType} | {symbol.DataShape} | {symbol.Signature}
""";
    }

    private void SaveArtifacts(PipelineContext context, int rowNumber, int attempt, string prompt, OllamaChatResult response)
    {
        var root = Path.Combine(context.RunRoot, "step-03-classification");
        var rowArtifacts = Path.Combine(root, "row_artifacts");
        Directory.CreateDirectory(rowArtifacts);

        File.WriteAllText(Path.Combine(rowArtifacts, $"row_{rowNumber:0000}_attempt_{attempt}_user_prompt.txt"), prompt);
        File.WriteAllText(Path.Combine(rowArtifacts, $"row_{rowNumber:0000}_attempt_{attempt}_response.txt"), response.Content ?? string.Empty);
        File.WriteAllText(Path.Combine(rowArtifacts, $"row_{rowNumber:0000}_attempt_{attempt}_request.json"), response.RequestJson);
        File.WriteAllText(Path.Combine(rowArtifacts, $"row_{rowNumber:0000}_attempt_{attempt}_api_response.json"), response.ResponseJson);
    }

    private static (string Component, string Description) ParseTextResult(string rawText)
    {
        var cleaned = rawText.Trim();
        if (cleaned.StartsWith("```", StringComparison.Ordinal))
        {
            cleaned = cleaned.Trim('`');
        }

        var component = string.Empty;
        var description = string.Empty;

        foreach (var line in cleaned.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (line.StartsWith("COMPONENT:", StringComparison.OrdinalIgnoreCase))
            {
                component = line.Split(':', 2)[1].Trim();
            }
            else if (line.StartsWith("DESCRIPTION:", StringComparison.OrdinalIgnoreCase))
            {
                description = line.Split(':', 2)[1].Trim();
            }
        }

        if (string.IsNullOrWhiteSpace(component))
        {
            throw new InvalidOperationException("Missing component.");
        }

        component = NormalizeComponentName(component);
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new InvalidOperationException("Missing description.");
        }

        return (component, description);
    }

    private static string NormalizeComponentName(string value)
    {
        var text = value.Trim();
        if (AllowedComponents.Contains(text))
        {
            return text;
        }

        if (ComponentAliases.TryGetValue(text, out var alias))
        {
            return alias;
        }

        var compact = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
        foreach (var component in ArchitectureComponents.Allowed)
        {
            var cmp = new string(component.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
            if (cmp == compact)
            {
                return component;
            }
        }

        throw new InvalidOperationException($"Unrecognized component name: {value}");
    }
}

public sealed class OllamaHierarchyBuilder(IOllamaClient ollamaClient) : IComponentHierarchyBuilder
{
    public async Task<IReadOnlyList<ComponentRecord>> BuildAsync(IReadOnlyList<SourceSymbol> symbols, string introduction, string model, CancellationToken cancellationToken)
    {
        var groups = symbols
            .Where(s => !string.IsNullOrWhiteSpace(s.ComponentName))
            .GroupBy(s => s.ComponentName!, StringComparer.Ordinal)
            .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

        var result = new List<ComponentRecord>();
        foreach (var group in groups)
        {
            var items = DeduplicateSymbols(group.ToList());
            var prompt = BuildHierarchyPrompt(group.Key, items, introduction, maxSubcomponents: 5);
            var response = await ollamaClient.ChatAsync(model, "You summarize software architecture components.", prompt, new OllamaCallContext("hierarchy"), cancellationToken).ConfigureAwait(false);
            var (overview, subcomponents) = ParseGroupingResponse(response.Content ?? string.Empty, items);
            if (string.IsNullOrWhiteSpace(overview) || subcomponents.Count == 0)
            {
                (overview, subcomponents) = FallbackGrouping(group.Key, items);
            }

            result.Add(new ComponentRecord(
                group.Key,
                group.First().Category ?? InferCategory(group.Key),
                overview,
                subcomponents));
        }

        return result;
    }

    private static string BuildHierarchyPrompt(string componentName, IReadOnlyList<SourceSymbol> items, string introduction, int maxSubcomponents)
    {
        var trimmed = items.Take(160).ToList();
        var symbolsBlock = string.Join(Environment.NewLine, trimmed.Select(item =>
        {
            var extras = new List<string>();
            if (!string.IsNullOrWhiteSpace(item.Kind)) extras.Add($"kind={item.Kind}");
            if (!string.IsNullOrWhiteSpace(item.DataType)) extras.Add($"type={item.DataType}");
            if (!string.IsNullOrWhiteSpace(item.DataShape)) extras.Add($"shape={item.DataShape}");
            var extraText = extras.Count > 0 ? $" {string.Join(' ', extras)}" : string.Empty;
            var fileName = Path.GetFileName(item.File);
            if (!string.IsNullOrWhiteSpace(item.Signature))
            {
                return $"- {item.QualifiedName} ({fileName}){extraText} sig={item.Signature} :: {item.LineDescription}";
            }
            return $"- {item.QualifiedName} ({fileName}){extraText} :: {item.LineDescription}";
        }));

        return $"""
You are analyzing one software architecture component based on low-level code symbols.

Project context:
{introduction}

Component:
{componentName}

Goal:
- Review all provided symbols in this component.
- Identify the main subcomponents inside this component.
- Group the symbols into those subcomponents.
- Describe each subcomponent.
- For every assigned symbol, explain how it fits that subcomponent in 50 words or less.
- Produce a short overview of the full component.

Return EXACTLY this plain-text format:

OVERVIEW: <one short paragraph about the whole component>

SUBCOMPONENT: <name> | <short description>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>

SUBCOMPONENT: <name> | <short description>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>

Rules:
- Do not use markdown.
- Do not return JSON.
- Use only the supplied symbols and descriptions.
- Keep subcomponent names broad but meaningful.
- Use qualified names exactly as given.
- Put each symbol in at most one subcomponent.
- Prefer between 2 and {maxSubcomponents} subcomponents.
- If the component is small, return at least 1 subcomponent.
- Each MEMBER explanation must be 50 words or fewer.
- Focus on responsibility clusters, not filenames.

Symbols:
{symbolsBlock}
""";
    }

    private static (string Overview, List<SubcomponentRecord> Subcomponents) ParseGroupingResponse(string text, IReadOnlyList<SourceSymbol> items)
    {
        var overview = string.Empty;
        var subcomponents = new List<(string Name, string Description, List<string> Members)>();
        (string Name, string Description, List<string> Members)? current = null;

        foreach (var rawLine in text.Split('\n'))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.StartsWith("OVERVIEW:", StringComparison.OrdinalIgnoreCase))
            {
                overview = line.Split(':', 2)[1].Trim();
                continue;
            }

            if (line.StartsWith("SUBCOMPONENT:", StringComparison.OrdinalIgnoreCase))
            {
                if (current is not null)
                {
                    subcomponents.Add((current.Value.Name, current.Value.Description, current.Value.Members));
                }

                var payload = line.Split(':', 2)[1].Trim();
                var parts = payload.Split('|', 2, StringSplitOptions.TrimEntries);
                current = (
                    Name: parts.ElementAtOrDefault(0) ?? "General Responsibilities",
                    Description: parts.ElementAtOrDefault(1) ?? string.Empty,
                    Members: new List<string>());
                continue;
            }

            if (line.StartsWith("MEMBER:", StringComparison.OrdinalIgnoreCase) && current is not null)
            {
                var payload = line.Split(':', 2)[1].Trim();
                var parts = payload.Split('|', 2, StringSplitOptions.TrimEntries);
                current.Value.Members.Add(parts.ElementAtOrDefault(0) ?? "<unknown>");
            }
        }

        if (current is not null)
        {
            subcomponents.Add((current.Value.Name, current.Value.Description, current.Value.Members));
        }

        var built = new List<SubcomponentRecord>();
        foreach (var group in subcomponents)
        {
            var members = group.Members
                .Select(qn => FindSymbol(items, qn))
                .Where(x => x is not null)
                .Select(x => x!)
                .ToList();
            built.Add(new SubcomponentRecord(group.Name, group.Description, members));
        }

        return (overview, built);
    }

    private static (string Overview, List<SubcomponentRecord> Subcomponents) FallbackGrouping(string componentName, IReadOnlyList<SourceSymbol> items)
    {
        var selected = items.Take(12).ToList();
        var members = selected.Select(x => x).ToList();
        var subcomponents = new List<SubcomponentRecord>
        {
            new("General Responsibilities", $"General responsibilities grouped under {componentName}.", members)
        };

        return ($"This component contains symbols related to {componentName.ToLowerInvariant()} responsibilities.", subcomponents);
    }

    private static string InferCategory(string componentName)
        => ArchitectureComponents.Technical.Contains(componentName) ? "technical" : "functional";

    private static List<SourceSymbol> DeduplicateSymbols(IReadOnlyList<SourceSymbol> items)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var deduped = new List<SourceSymbol>();
        foreach (var item in items)
        {
            var key = $"{item.ComponentName}|{item.QualifiedName}|{item.File}|{item.StartLine}|{item.EndLine}|{item.Kind}|{item.DataType}|{item.DataShape}";
            if (seen.Add(key))
            {
                deduped.Add(item);
            }
        }

        return deduped;
    }

    private static SourceSymbol? FindSymbol(IReadOnlyList<SourceSymbol> items, string qualifiedName)
        => items.FirstOrDefault(x => string.Equals(x.QualifiedName, qualifiedName, StringComparison.Ordinal));
}

public sealed class CallerEnricher : ICallerEnricher
{
    private const int MaxContextChars = 6000;
    private static readonly HashSet<string> CallableKinds = new(StringComparer.OrdinalIgnoreCase) { "function", "method", "constructor" };
    private static readonly HashSet<string> SkipDirNames = new(StringComparer.OrdinalIgnoreCase)
    {
        ".git", ".idea", ".vs", ".vscode", "build", "dist", "out", "bin", "obj", "node_modules", "run_artifacts", "__pycache__", ".specbuilder"
    };

    public async Task<string> EnrichAsync(IReadOnlyList<ComponentRecord> hierarchy, string sourceRoot, string model, CancellationToken cancellationToken)
    {
        var sourceFiles = CollectSourceFiles(sourceRoot);
        var flatSymbols = FlattenHierarchy(hierarchy);
        var targets = flatSymbols.Where(x => CallableKinds.Contains(x.Symbol.Kind)).ToList();
        var componentLookup = BuildComponentLookup(hierarchy);

        var callerEnrichment = new List<object>();
        var mappedTargets = 0;
        var targetsWithCallers = 0;

        foreach (var target in targets)
        {
            if (!sourceFiles.TryGetValue(NormalizePath(target.Symbol.File), out var sourceFile))
            {
                callerEnrichment.Add(new
                {
                    target = target.Symbol.QualifiedName,
                    caller_count = 0,
                    callers = Array.Empty<object>(),
                    caller_resolution_status = "source_file_not_found"
                });
                continue;
            }

            mappedTargets++;
            var callSites = FindCallSites(sourceFile, target.Symbol);
            var callers = new List<object>();
            foreach (var site in callSites)
            {
                var caller = ResolveEnclosingSymbol(site.LineNo, target.Symbol, sourceFile.Symbols);
                var callerComponent = "Unknown";
                var callerSubcomponent = "Unknown";
                var callerQn = caller?.QualifiedName ?? "<unknown caller>";
                if (caller is not null)
                {
                    var key = (NormalizePath(caller.File), caller.QualifiedName, caller.StartLine, caller.EndLine);
                    if (componentLookup.TryGetValue(key, out var comp))
                    {
                        callerComponent = comp.component;
                        callerSubcomponent = comp.subcomponent;
                    }
                }

                callers.Add(new
                {
                    caller_component_name = callerComponent,
                    caller_subcomponent_name = callerSubcomponent,
                    caller_qualified_name = callerQn,
                    caller_kind = caller?.Kind ?? "unknown",
                    caller_file = caller?.File ?? sourceFile.Path,
                    caller_start_line = caller?.StartLine,
                    caller_end_line = caller?.EndLine,
                    line_no = site.LineNo,
                    call_line = site.CallLine,
                    why_called = $"The caller invokes {target.Symbol.QualifiedName} here to support its local control flow and complete the required operation."
                });
            }

            if (callers.Count > 0)
            {
                targetsWithCallers++;
            }

            callerEnrichment.Add(new
            {
                target = target.Symbol.QualifiedName,
                caller_count = callers.Count,
                caller_components = callers.Select(x => ((dynamic)x).caller_component_name).Distinct().OrderBy(x => x).ToArray(),
                callers,
                caller_resolution_status = "ok"
            });
        }

        var payload = new
        {
            generated_at_utc = DateTimeOffset.UtcNow,
            source_model = model,
            summary_model = model,
            source_root = sourceRoot,
            target_callable_symbol_count = targets.Count,
            mapped_target_source_files = mappedTargets,
            targets_with_callers = targetsWithCallers,
            caller_enrichment = callerEnrichment
        };

        return JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
    }

    private static Dictionary<string, SourceFileInfo> CollectSourceFiles(string root)
    {
        var files = new Dictionary<string, SourceFileInfo>(StringComparer.OrdinalIgnoreCase);
        foreach (var path in Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories))
        {
            if (SkipDirNames.Any(skip => path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Any(part => string.Equals(part, skip, StringComparison.OrdinalIgnoreCase))))
            {
                continue;
            }

            var ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext is not (".c" or ".h" or ".cpp" or ".cc" or ".cxx" or ".hpp" or ".hh" or ".hxx" or ".py" or ".java" or ".cs"))
            {
                continue;
            }

            var text = File.ReadAllText(path);
            files[NormalizePath(path)] = new SourceFileInfo(path, text, text.Split('\n'));
        }

        var extractor = new TreeSymbolExtractor();
        var allSymbols = extractor.ExtractAsync(root, CancellationToken.None).GetAwaiter().GetResult();
        var symbolLookup = allSymbols
            .GroupBy(symbol => NormalizePath(symbol.File), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => (IReadOnlyList<SourceSymbol>)group.ToList(), StringComparer.OrdinalIgnoreCase);

        foreach (var key in files.Keys.ToList())
        {
            if (symbolLookup.TryGetValue(key, out var symbols))
            {
                files[key] = files[key] with { Symbols = symbols };
            }
        }

        return files;
    }

    private static List<(string Component, string Subcomponent, SourceSymbol Symbol)> FlattenHierarchy(IReadOnlyList<ComponentRecord> hierarchy)
    {
        var flat = new List<(string, string, SourceSymbol)>();
        foreach (var component in hierarchy)
        {
            foreach (var sub in component.Subcomponents)
            {
                foreach (var symbol in sub.Symbols)
                {
                    flat.Add((component.ComponentName, sub.SubcomponentName, symbol));
                }
            }
        }
        return flat;
    }

    private static Dictionary<(string File, string QualifiedName, int StartLine, int EndLine), (string component, string subcomponent)> BuildComponentLookup(IReadOnlyList<ComponentRecord> hierarchy)
    {
        var lookup = new Dictionary<(string, string, int, int), (string, string)>();
        foreach (var component in hierarchy)
        {
            foreach (var sub in component.Subcomponents)
            {
                foreach (var symbol in sub.Symbols)
                {
                    lookup[(NormalizePath(symbol.File), symbol.QualifiedName, symbol.StartLine, symbol.EndLine)] = (component.ComponentName, sub.SubcomponentName);
                }
            }
        }
        return lookup;
    }

    private static List<CallSiteInfo> FindCallSites(SourceFileInfo source, SourceSymbol target)
    {
        var results = new List<CallSiteInfo>();
        var shortName = target.Name.Trim();
        if (string.IsNullOrWhiteSpace(shortName) || shortName is "<anonymous>" or "main")
        {
            return results;
        }

        var pattern = new Regex($@"(?<![A-Za-z0-9_]){Regex.Escape(shortName)}\s*\(", RegexOptions.Compiled);
        for (var idx = 0; idx < source.Lines.Length; idx++)
        {
            var lineNo = idx + 1;
            var raw = source.Lines[idx];
            var clean = StripCommentsPreserveStrings(raw);
            if (!clean.Contains(shortName, StringComparison.Ordinal) || !pattern.IsMatch(clean))
            {
                continue;
            }

            results.Add(new CallSiteInfo(lineNo, raw.Trim()));
        }

        return results;
    }

    private static SourceSymbol? ResolveEnclosingSymbol(int lineNo, SourceSymbol target, IEnumerable<SourceSymbol> symbolsInFile)
    {
        var best = symbolsInFile
            .Where(x => CallableKinds.Contains(x.Kind))
            .Where(x => x.StartLine <= lineNo && lineNo <= x.EndLine)
            .Where(x => !(x.QualifiedName == target.QualifiedName && NormalizePath(x.File) == NormalizePath(target.File) && x.StartLine == target.StartLine && x.EndLine == target.EndLine))
            .OrderBy(x => x.EndLine - x.StartLine)
            .ThenBy(x => x.StartLine)
            .FirstOrDefault();
        return best;
    }

    private static string StripCommentsPreserveStrings(string line)
    {
        var result = new List<char>();
        var inSingle = false;
        var inDouble = false;
        for (var i = 0; i < line.Length; i++)
        {
            var ch = line[i];
            var nxt = i + 1 < line.Length ? line[i + 1] : '\0';
            if (!inDouble && ch == '\'' && (i == 0 || line[i - 1] != '\\'))
            {
                inSingle = !inSingle;
                result.Add(ch);
                continue;
            }
            if (!inSingle && ch == '"' && (i == 0 || line[i - 1] != '\\'))
            {
                inDouble = !inDouble;
                result.Add(ch);
                continue;
            }
            if (!inSingle && !inDouble && ch == '/' && nxt == '/')
            {
                break;
            }
            if (!inSingle && !inDouble && ch == '#')
            {
                break;
            }
            result.Add(ch);
        }
        return new string(result.ToArray());
    }

    private static string NormalizePath(string path)
        => path.Replace('\\', '/').ToLowerInvariant().Trim();

    private sealed record SourceFileInfo(string Path, string Text, string[] Lines)
    {
        public IReadOnlyList<SourceSymbol> Symbols { get; init; } = Array.Empty<SourceSymbol>();
    }

    private sealed record CallSiteInfo(int LineNo, string CallLine);
}
