using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.Infrastructure;

public sealed class DiscoveryStep(IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-01-discovery";
    public string DisplayName => "Project Discovery";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var previousDiscovery = context.Inputs.TryGetValue("previous-output:step-01-discovery", out var discoveryPath) ? discoveryPath : string.Empty;
        var sourceFiles = Directory.EnumerateFiles(context.Workspace.SourceRoot, "*.*", SearchOption.AllDirectories)
            .Where(f =>
            {
                var ext = Path.GetExtension(f).ToLowerInvariant();
                return ext is ".c" or ".h" or ".cpp" or ".cc" or ".cxx" or ".hpp" or ".hh" or ".hxx" or ".py" or ".java" or ".cs";
            })
            .Where(f => !f.Contains($"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return Task.FromResult(Hashing.Sha256(
            context.Workspace.SourceRoot,
            context.Workspace.IntroductionFile,
            context.Workspace.OllamaModel,
            context.Workspace.PromptVersion,
            string.Join('|', sourceFiles),
            previousDiscovery));
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var sourceFiles = Directory.EnumerateFiles(context.Workspace.SourceRoot, "*.*", SearchOption.AllDirectories)
            .Where(f =>
            {
                var ext = Path.GetExtension(f).ToLowerInvariant();
                return ext is ".c" or ".h" or ".cpp" or ".cc" or ".cxx" or ".hpp" or ".hh" or ".hxx" or ".py" or ".java" or ".cs";
            })
            .Where(f => !f.Contains($"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        var manifest = new
        {
            workspace = context.Workspace,
            discoveredAtUtc = DateTimeOffset.UtcNow,
            sourceFileCount = sourceFiles.Length,
            sourceFiles
        };

        await store.WriteJsonAsync(context, StepId, "manifest.json", manifest, cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: sourceFiles.Length.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "manifest.json"), null);
    }
}

public sealed class SymbolExtractionStep(ISourceSymbolExtractor extractor, IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-02-symbols";
    public string DisplayName => "Symbol Extraction";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var discoveryPath = context.Inputs.TryGetValue("previous-output:step-01-discovery", out var prevDiscovery)
            ? prevDiscovery
            : Path.Combine(context.RunRoot, "step-01-discovery", "manifest.json");
        var discovery = await store.ReadTextAsync(discoveryPath, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.SourceRoot, discovery);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var symbols = await extractor.ExtractAsync(context.Workspace.SourceRoot, cancellationToken).ConfigureAwait(false);
        await store.WriteJsonAsync(context, StepId, "symbols.json", symbols, cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: symbols.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "symbols.json"), null);
    }
}

public sealed class ClassificationStep(IComponentClassifier classifier, IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-03-classification";
    public string DisplayName => "Symbol Classification";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var symbolsPath = context.Inputs.TryGetValue("previous-output:step-02-symbols", out var prevSymbols)
            ? prevSymbols
            : Path.Combine(context.RunRoot, "step-02-symbols", "symbols.json");
        var symbols = await store.ReadTextAsync(symbolsPath, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.IntroductionFile, context.Workspace.OllamaModel, context.Workspace.PromptVersion, symbols, intro);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var inputPath = Path.Combine(context.RunRoot, "step-02-symbols", "symbols.json");
        var symbols = await store.ReadJsonAsync<List<SourceSymbol>>(inputPath, cancellationToken).ConfigureAwait(false) ?? [];
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? "";
        var classified = await classifier.ClassifyAsync(symbols, intro, context.Workspace.OllamaModel ?? "qwen3.5:2b", context, cancellationToken).ConfigureAwait(false);
        await store.WriteJsonAsync(context, StepId, "component_assignments.json", classified, cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: classified.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "component_assignments.json"), null);
    }
}

public sealed class HierarchyStep(IComponentHierarchyBuilder builder, IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-04-hierarchy";
    public string DisplayName => "Component Hierarchy";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var assignmentsPath = context.Inputs.TryGetValue("previous-output:step-03-classification", out var prevAssignments)
            ? prevAssignments
            : Path.Combine(context.RunRoot, "step-03-classification", "component_assignments.json");
        var assignments = await store.ReadTextAsync(assignmentsPath, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.OllamaModel, context.Workspace.PromptVersion, assignments, intro);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var inputPath = Path.Combine(context.RunRoot, "step-03-classification", "component_assignments.json");
        var symbols = await store.ReadJsonAsync<List<SourceSymbol>>(inputPath, cancellationToken).ConfigureAwait(false) ?? [];
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? "";
        var hierarchy = await builder.BuildAsync(symbols, intro, context.Workspace.OllamaModel ?? "qwen3.5:2b", cancellationToken).ConfigureAwait(false);
        await store.WriteJsonAsync(context, StepId, "component_hierarchy.json", hierarchy, cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: hierarchy.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "component_hierarchy.json"), null);
    }
}

public sealed class CallerEnrichmentStep(ICallerEnricher enricher, IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-05-callers";
    public string DisplayName => "Caller Enrichment";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var hierarchyPath = context.Inputs.TryGetValue("previous-output:step-04-hierarchy", out var prevHierarchy)
            ? prevHierarchy
            : Path.Combine(context.RunRoot, "step-04-hierarchy", "component_hierarchy.json");
        var hierarchy = await store.ReadTextAsync(hierarchyPath, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.SourceRoot, context.Workspace.OllamaModel, hierarchy);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var inputPath = Path.Combine(context.RunRoot, "step-04-hierarchy", "component_hierarchy.json");
        var hierarchy = await store.ReadJsonAsync<List<ComponentRecord>>(inputPath, cancellationToken).ConfigureAwait(false) ?? [];
        var output = await enricher.EnrichAsync(hierarchy, context.Workspace.SourceRoot, context.Workspace.OllamaModel ?? "qwen3.5:2b", cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "component_hierarchy_with_callers.json", output, cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: output.Length.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "component_hierarchy_with_callers.json"), null);
    }
}

public sealed class ExportStep(IArtifactStore store) : IPipelineStep
{
    public string StepId => "step-06-export";
    public string DisplayName => "Export";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var classificationPath = context.Inputs.TryGetValue("previous-output:step-03-classification", out var prevClassification)
            ? prevClassification
            : Path.Combine(context.RunRoot, "step-03-classification", "component_assignments.json");
        var classification = await store.ReadTextAsync(classificationPath, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(classification);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var inputPath = Path.Combine(context.RunRoot, "step-03-classification", "component_assignments.json");
        var symbols = await store.ReadJsonAsync<List<SourceSymbol>>(inputPath, cancellationToken).ConfigureAwait(false) ?? [];
        var payload = BuildAssignmentPayload(context, symbols);
        await store.WriteJsonAsync(context, StepId, "component_assignments.json", payload, cancellationToken).ConfigureAwait(false);
        var markdown = BuildMarkdown(symbols);
        await store.WriteTextAsync(context, StepId, "component_list.md", markdown, cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "summary.txt", $"Exported from run {context.RunId}", cancellationToken).ConfigureAwait(false);
        return new StepRecord(StepId, DisplayName, Fingerprint: symbols.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, StepId, "component_list.md"), null);
    }

    private static object BuildAssignmentPayload(PipelineContext context, IReadOnlyList<SourceSymbol> symbols)
    {
        return new
        {
            model = context.Workspace.OllamaModel ?? "qwen3.5:2b",
            project_introduction_file = context.Workspace.IntroductionFile,
            allowed_components = ArchitectureComponents.Allowed,
            assignments = symbols.Select(symbol => new
            {
                source_line_no = symbol.SourceLineNo,
                original_row = symbol.OriginalRow,
                file = symbol.File,
                kind = symbol.Kind,
                name = symbol.Name,
                qualified_name = symbol.QualifiedName,
                start_line = symbol.StartLine,
                end_line = symbol.EndLine,
                parent = symbol.Parent,
                data_type = symbol.DataType,
                data_shape = symbol.DataShape,
                signature = symbol.Signature,
                component_name = symbol.ComponentName ?? "Unclassified",
                category = symbol.Category ?? "mixed",
                line_description = symbol.LineDescription,
                reasoning_summary = BuildReasoningSummary(symbol),
            }).ToArray()
        };
    }

    private static string BuildOriginalRow(SourceSymbol symbol)
    {
        return symbol.OriginalRow;
    }

    private static string BuildReasoningSummary(SourceSymbol symbol)
        => $"Assigned to {symbol.ComponentName ?? "Unclassified"} based on the symbol name, type metadata, signature, and likely responsibility.";

    private static string BuildMarkdown(IReadOnlyList<SourceSymbol> symbols)
    {
        var grouped = symbols
            .GroupBy(x => x.ComponentName ?? "Unclassified", StringComparer.Ordinal)
            .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

        var lines = new List<string>
        {
            "# Component List",
            "",
            "Generated from per-row symbol classification.",
            ""
        };

        foreach (var group in grouped)
        {
            var category = group.First().Category ?? "mixed";
            lines.Add($"## Component: {group.Key}");
            lines.Add($"- Category: {category}");
            lines.Add($"- Assigned symbols: {group.Count()}");
            lines.Add("");
            lines.Add("### Symbols");
            lines.Add("| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |");
            lines.Add("|---|---|---|---|---|---|---:|---:|---|");

            foreach (var symbol in group.OrderBy(x => x.File, StringComparer.OrdinalIgnoreCase).ThenBy(x => x.StartLine))
            {
                lines.Add($"| {EscapeTable(symbol.File)} | {EscapeTable(symbol.Kind)} | {EscapeTable(symbol.Name)} | {EscapeTable(symbol.QualifiedName)} | {EscapeTable(symbol.DataType)} | {EscapeTable(symbol.DataShape)} | {symbol.StartLine} | {symbol.EndLine} | {EscapeTable(symbol.LineDescription)} |");
            }

            lines.Add("");
            lines.Add("### Original Rows");
            lines.Add("```text");
            foreach (var symbol in group)
            {
                lines.Add(BuildOriginalRow(symbol));
            }
            lines.Add("```");
            lines.Add("");
        }

        return string.Join(Environment.NewLine, lines);
    }

    private static string EscapeTable(string value)
        => (value ?? string.Empty).Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ").Trim();
}
