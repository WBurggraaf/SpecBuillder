using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.Infrastructure;

public sealed class DiscoveryStep(IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-01-discovery";
    public string DisplayName => "Project Discovery";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var previousAnalysis = context.Inputs.TryGetValue("previous-output:step-01-discovery", out var discoveryPath) ? discoveryPath : string.Empty;
        var sourceFiles = EnumerateSourceFiles(context.Workspace.SourceRoot);
        return Task.FromResult(Hashing.Sha256(context.Workspace.SourceRoot, context.Workspace.IntroductionFile, context.Workspace.OllamaModel, context.Workspace.PromptVersion, string.Join('|', sourceFiles), previousAnalysis));
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var sourceFiles = EnumerateSourceFiles(context.Workspace.SourceRoot);
        var now = DateTimeOffset.UtcNow;
        var analysis = AnalysisDocumentFactory.CreateEmpty(context, now) with
        {
            Discovery = new DiscoverySection("completed", sourceFiles, sourceFiles.Length, now),
            UpdatedAtUtc = now
        };

        reporter?.OnStepStarted(StepId, DisplayName, $"Found {sourceFiles.Length} source files.");
        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Canonical analysis.json updated with {sourceFiles.Length} files.");
        return new StepRecord(StepId, DisplayName, Fingerprint: sourceFiles.Length.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static string[] EnumerateSourceFiles(string sourceRoot)
        => Directory.EnumerateFiles(sourceRoot, "*.*", SearchOption.AllDirectories)
            .Where(f =>
            {
                var ext = Path.GetExtension(f).ToLowerInvariant();
                return ext is ".c" or ".h" or ".cpp" or ".cc" or ".cxx" or ".hpp" or ".hh" or ".hxx" or ".py" or ".java" or ".cs";
            })
            .Where(f => !f.Contains($"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
            .ToArray();
}

public sealed class SymbolExtractionStep(ISourceSymbolExtractor extractor, IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-02-symbols";
    public string DisplayName => "Symbol Extraction";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var discovery = string.Join('|', analysis.Discovery.SourceFiles);
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.SourceRoot, discovery, intro);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        reporter?.OnStepStarted(StepId, DisplayName, "Scanning source files for symbols.");
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var symbols = await extractor.ExtractAsync(context.Workspace.SourceRoot, cancellationToken).ConfigureAwait(false);
        var symbolsText = BuildSymbolsText(symbols);
        var validation = ValidateFlatExport(symbolsText);
        var now = DateTimeOffset.UtcNow;

        analysis = analysis with
        {
            Symbols = new SymbolSection("completed", symbols, symbolsText, validation),
            UpdatedAtUtc = now
        };

        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "symbols.txt", symbolsText, cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "symbols_validation.txt", validation, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Captured {symbols.Count} symbols.");
        return new StepRecord(StepId, DisplayName, Fingerprint: symbols.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static string BuildSymbolsText(IReadOnlyList<SourceSymbol> symbols)
    {
        const string header = "file | kind | name | qualified_name | start_line | end_line | parent | data_type | data_shape | signature";
        var separator = new string('-', 220);
        var lines = new List<string> { header, separator };

        foreach (var symbol in symbols.OrderBy(x => x.File, StringComparer.OrdinalIgnoreCase).ThenBy(x => x.StartLine).ThenBy(x => x.Kind, StringComparer.OrdinalIgnoreCase).ThenBy(x => x.QualifiedName, StringComparer.OrdinalIgnoreCase))
        {
            lines.Add(string.Join(" | ", new[]
            {
                symbol.File,
                symbol.Kind,
                symbol.Name,
                symbol.QualifiedName,
                symbol.StartLine.ToString(),
                symbol.EndLine.ToString(),
                symbol.Parent,
                symbol.DataType,
                symbol.DataShape,
                symbol.Signature
            }));
        }

        return string.Join(Environment.NewLine, lines);
    }

    private static string ValidateFlatExport(string symbolsText)
        => string.IsNullOrWhiteSpace(symbolsText)
            ? "MISMATCH: symbols.txt is empty."
            : "OK: symbols.txt generated from the canonical analysis state.";
}

public sealed class ClassificationStep(IComponentClassifier classifier, IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-03-classification";
    public string DisplayName => "Symbol Classification";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var symbols = SerializeForHash(analysis.Symbols.Items);
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.IntroductionFile, context.Workspace.OllamaModel, context.Workspace.PromptVersion, symbols, intro);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        reporter?.OnStepStarted(StepId, DisplayName, "Classifying symbols into architecture components.");
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        var classified = await classifier.ClassifyAsync(analysis.Symbols.Items, intro, context.Workspace.OllamaModel ?? "gemma4:e2b", context, cancellationToken).ConfigureAwait(false);
        var now = DateTimeOffset.UtcNow;

        analysis = analysis with
        {
            Classification = new ClassificationSection("completed", classified, classified.Count, now),
            UpdatedAtUtc = now
        };

        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Classified {classified.Count} symbols.");
        return new StepRecord(StepId, DisplayName, Fingerprint: classified.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static string SerializeForHash(IReadOnlyList<SourceSymbol> symbols)
        => string.Join('\n', symbols.Select(symbol => $"{symbol.File}|{symbol.Kind}|{symbol.Name}|{symbol.QualifiedName}|{symbol.StartLine}|{symbol.EndLine}|{symbol.Parent}|{symbol.DataType}|{symbol.DataShape}|{symbol.Signature}"));
}

public sealed class HierarchyStep(IComponentHierarchyBuilder builder, IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-04-hierarchy";
    public string DisplayName => "Component Hierarchy";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        return Hashing.Sha256(context.Workspace.OllamaModel, context.Workspace.PromptVersion, SerializeForHash(analysis.Classification.Items), intro);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        reporter?.OnStepStarted(StepId, DisplayName, "Grouping classified symbols into component subtrees.");
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var intro = await store.ReadTextAsync(context.Workspace.IntroductionFile, cancellationToken).ConfigureAwait(false) ?? string.Empty;
        var hierarchy = await builder.BuildAsync(analysis.Classification.Items, intro, context.Workspace.OllamaModel ?? "gemma4:e2b", cancellationToken).ConfigureAwait(false);
        var now = DateTimeOffset.UtcNow;

        analysis = analysis with
        {
            Hierarchy = new HierarchySection("completed", hierarchy, CreateSummaries(hierarchy), CreateIndex(hierarchy), now),
            UpdatedAtUtc = now
        };

        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Built {hierarchy.Count} components with subcomponent trees.");
        return new StepRecord(StepId, DisplayName, Fingerprint: hierarchy.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static IReadOnlyList<ComponentHierarchySummary> CreateSummaries(IReadOnlyList<ComponentRecord> hierarchy)
        => hierarchy.Select(component => new ComponentHierarchySummary(
            ComponentName: component.ComponentName,
            Category: component.Category,
            SubcomponentCount: component.Subcomponents.Count,
            SymbolCount: component.Subcomponents.Sum(sub => sub.Symbols.Count),
            SubcomponentNames: component.Subcomponents.Select(sub => sub.SubcomponentName).ToArray())).ToArray();

    private static IReadOnlyList<ComponentSubcomponentIndex> CreateIndex(IReadOnlyList<ComponentRecord> hierarchy)
        => hierarchy.Select(component => new ComponentSubcomponentIndex(
            ComponentName: component.ComponentName,
            Category: component.Category,
            Subcomponents: component.Subcomponents.Select(sub => new SubcomponentIndex(
                SubcomponentName: sub.SubcomponentName,
                SymbolCount: sub.Symbols.Count,
                SymbolQualifiedNames: sub.Symbols.Select(symbol => symbol.QualifiedName).ToArray())).ToArray())).ToArray();

    private static string SerializeForHash(IReadOnlyList<SourceSymbol> symbols)
        => string.Join('\n', symbols.Select(symbol => $"{symbol.File}|{symbol.Kind}|{symbol.Name}|{symbol.QualifiedName}|{symbol.StartLine}|{symbol.EndLine}|{symbol.Parent}|{symbol.DataType}|{symbol.DataShape}|{symbol.Signature}|{symbol.ComponentName}|{symbol.Category}|{symbol.LineDescription}"));
}

public sealed class CallerEnrichmentStep(ICallerEnricher enricher, IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-05-callers";
    public string DisplayName => "Caller Enrichment";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        return Hashing.Sha256(context.Workspace.SourceRoot, context.Workspace.OllamaModel, SerializeForHash(analysis.Hierarchy.Components));
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        reporter?.OnStepStarted(StepId, DisplayName, "Scanning callable symbols and resolving callers.");
        var analysis = context.Analysis ?? await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var output = await enricher.EnrichAsync(analysis.Hierarchy.Components, context.Workspace.SourceRoot, context.Workspace.OllamaModel ?? "gemma4:e2b", cancellationToken).ConfigureAwait(false);
        var now = DateTimeOffset.UtcNow;

        analysis = analysis with
        {
            Callers = new CallerSection("completed", output, now),
            UpdatedAtUtc = now
        };

        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Produced caller enrichment for {analysis.Hierarchy.Components.Sum(c => c.Subcomponents.Sum(s => s.Symbols.Count))} grouped symbols.");
        return new StepRecord(StepId, DisplayName, Fingerprint: output.Length.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static string SerializeForHash(IReadOnlyList<ComponentRecord> components)
        => string.Join('\n', components.Select(component => $"{component.ComponentName}|{component.Category}|{component.ComponentOverview}|{string.Join(',', component.Subcomponents.Select(sub => sub.SubcomponentName))}"));
}

public sealed class ExportStep(IArtifactStore store, IPipelineReporter? reporter = null) : IPipelineStep
{
    public string StepId => "step-06-export";
    public string DisplayName => "Export";
    public bool SupportsResume => true;
    public bool SupportsPartialRerun => true;

    public async Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        return Hashing.Sha256(SerializeForHash(analysis.Classification.Items), SerializeForHash(analysis.Hierarchy.Components), analysis.Callers.Json, context.Workspace.OllamaModel, context.Workspace.PromptVersion);
    }

    public async Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        reporter?.OnStepStarted(StepId, DisplayName, "Rendering human-friendly exports from analysis.json.");
        var analysis = await AnalysisDocumentIO.LoadAnalysisAsync(store, context, cancellationToken).ConfigureAwait(false);
        var markdown = BuildMarkdown(analysis.Classification.Items);
        var summary = $"Exported from run {context.RunId}";
        var now = DateTimeOffset.UtcNow;

        analysis = analysis with
        {
            Export = new ExportSection("completed", markdown, summary, now),
            UpdatedAtUtc = now
        };

        await store.WriteRunJsonAsync(context, "analysis.json", analysis, cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "component_list.md", markdown, cancellationToken).ConfigureAwait(false);
        await store.WriteTextAsync(context, StepId, "summary.txt", summary, cancellationToken).ConfigureAwait(false);
        reporter?.OnStepFinished(StepId, DisplayName, StepStatus.Success, $"Export views generated for {analysis.Classification.Items.Count} symbols.");
        return new StepRecord(StepId, DisplayName, Fingerprint: analysis.Classification.Items.Count.ToString(), StepStatus.Success, null, Path.Combine(context.RunRoot, "analysis.json"), null);
    }

    private static string BuildMarkdown(IReadOnlyList<SourceSymbol> symbols)
    {
        var grouped = symbols
            .GroupBy(x => x.ComponentName ?? "Unclassified", StringComparer.Ordinal)
            .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase);

        var lines = new List<string>
        {
            "# Component List",
            "",
            "Generated from the canonical analysis.json document.",
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
                lines.Add(symbol.OriginalRow);
            }
            lines.Add("```");
            lines.Add("");
        }

        return string.Join(Environment.NewLine, lines);
    }

    private static string EscapeTable(string value)
        => (value ?? string.Empty).Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ").Trim();

    private static string SerializeForHash(IReadOnlyList<SourceSymbol> symbols)
        => string.Join('\n', symbols.Select(symbol => $"{symbol.File}|{symbol.Kind}|{symbol.Name}|{symbol.QualifiedName}|{symbol.StartLine}|{symbol.EndLine}|{symbol.Parent}|{symbol.DataType}|{symbol.DataShape}|{symbol.Signature}|{symbol.ComponentName}|{symbol.Category}|{symbol.LineDescription}"));

    private static string SerializeForHash(IReadOnlyList<ComponentRecord> components)
        => string.Join('\n', components.Select(component => $"{component.ComponentName}|{component.Category}|{component.ComponentOverview}|{string.Join(',', component.Subcomponents.Select(sub => sub.SubcomponentName))}"));
}

internal static class AnalysisDocumentFactory
{
    public static RunAnalysisDocument CreateEmpty(PipelineContext context, DateTimeOffset now)
        => new(
            RunId: context.RunId,
            WorkspaceId: context.Workspace.WorkspaceId,
            SourceRoot: context.Workspace.SourceRoot,
            IntroductionFile: context.Workspace.IntroductionFile,
            OllamaModel: context.Workspace.OllamaModel,
            PromptVersion: context.Workspace.PromptVersion,
            CreatedAtUtc: now,
            UpdatedAtUtc: now,
            Discovery: new DiscoverySection("pending", [], 0, null),
            Symbols: new SymbolSection("pending", [], null, null),
            Classification: new ClassificationSection("pending", [], 0, null),
            Hierarchy: new HierarchySection("pending", [], [], [], null),
            Callers: new CallerSection("pending", null, null),
            Export: new ExportSection("pending", null, null, null),
            Telemetry: new RunTelemetrySection(0, []));
}

internal static class AnalysisDocumentIO
{
    public static async Task<RunAnalysisDocument> LoadAnalysisAsync(IArtifactStore store, PipelineContext context, CancellationToken cancellationToken)
    {
        var analysis = await store.ReadRunJsonAsync<RunAnalysisDocument>(context, "analysis.json", cancellationToken).ConfigureAwait(false);
        return analysis ?? AnalysisDocumentFactory.CreateEmpty(context, DateTimeOffset.UtcNow);
    }
}
