namespace SpecBuilder.Domain;

public enum StepStatus
{
    Pending,
    Running,
    Success,
    Warning,
    Failed,
    Cached
}

public sealed record WorkspaceDefinition(
    string WorkspaceId,
    string SourceRoot,
    string IntroductionFile,
    string? OllamaModel,
    string? PromptVersion);

public sealed record RunManifest(
    string RunId,
    string WorkspaceId,
    DateTimeOffset StartedAtUtc,
    DateTimeOffset? CompletedAtUtc,
    IReadOnlyList<string> SelectedSteps,
    IReadOnlyList<StepRecord> Steps);

public sealed record RunAnalysisDocument(
    string RunId,
    string WorkspaceId,
    string SourceRoot,
    string IntroductionFile,
    string? OllamaModel,
    string? PromptVersion,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc,
    DiscoverySection Discovery,
    SymbolSection Symbols,
    ClassificationSection Classification,
    HierarchySection Hierarchy,
    CallerSection Callers,
    ExportSection Export,
    RunTelemetrySection Telemetry);

public sealed record DiscoverySection(
    string Status,
    IReadOnlyList<string> SourceFiles,
    int SourceFileCount,
    DateTimeOffset? DiscoveredAtUtc);

public sealed record SymbolSection(
    string Status,
    IReadOnlyList<SourceSymbol> Items,
    string? FlatText,
    string? ValidationMessage);

public sealed record ClassificationSection(
    string Status,
    IReadOnlyList<SourceSymbol> Items,
    int RowCount,
    DateTimeOffset? ClassifiedAtUtc);

public sealed record HierarchySection(
    string Status,
    IReadOnlyList<ComponentRecord> Components,
    IReadOnlyList<ComponentHierarchySummary> Summaries,
    IReadOnlyList<ComponentSubcomponentIndex> Index,
    DateTimeOffset? BuiltAtUtc);

public sealed record ComponentHierarchySummary(
    string ComponentName,
    string Category,
    int SubcomponentCount,
    int SymbolCount,
    IReadOnlyList<string> SubcomponentNames);

public sealed record ComponentSubcomponentIndex(
    string ComponentName,
    string Category,
    IReadOnlyList<SubcomponentIndex> Subcomponents);

public sealed record SubcomponentIndex(
    string SubcomponentName,
    int SymbolCount,
    IReadOnlyList<string> SymbolQualifiedNames);

public sealed record CallerSection(
    string Status,
    string? Json,
    DateTimeOffset? EnrichedAtUtc);

public sealed record ExportSection(
    string Status,
    string? ComponentListMarkdown,
    string? SummaryText,
    DateTimeOffset? ExportedAtUtc);

public sealed record RunTelemetrySection(
    int OllamaCallCount,
    IReadOnlyList<StepTelemetryRecord> Steps);

public sealed record StepTelemetryRecord(
    string StepId,
    string DisplayName,
    DateTimeOffset StartedAtUtc,
    DateTimeOffset CompletedAtUtc,
    double DurationSeconds);

public sealed record StepRecord(
    string StepId,
    string DisplayName,
    string Fingerprint,
    StepStatus Status,
    string? InputHash,
    string? OutputPath,
    string? ErrorMessage,
    DateTimeOffset? StartedAtUtc = null,
    DateTimeOffset? CompletedAtUtc = null,
    TimeSpan? Duration = null);

public sealed record ComponentSymbol(
    string File,
    string Kind,
    string Name,
    string QualifiedName,
    int StartLine,
    int EndLine,
    string Parent,
    string DataType,
    string DataShape,
    string Signature);
