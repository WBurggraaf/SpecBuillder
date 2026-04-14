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

public sealed record StepRecord(
    string StepId,
    string DisplayName,
    string Fingerprint,
    StepStatus Status,
    string? InputHash,
    string? OutputPath,
    string? ErrorMessage);

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
