using SpecBuilder.Domain;

namespace SpecBuilder.Application;

public sealed record PipelineContext(
    WorkspaceDefinition Workspace,
    string WorkspaceRoot,
    string RunId,
    string RunRoot,
    IReadOnlyDictionary<string, string> Inputs,
    IReadOnlyList<string> SelectedSteps);

public interface IPipelineStep
{
    string StepId { get; }
    string DisplayName { get; }
    bool SupportsResume { get; }
    bool SupportsPartialRerun { get; }
    Task<string> ComputeInputHashAsync(PipelineContext context, CancellationToken cancellationToken);
    Task<StepRecord> ExecuteAsync(PipelineContext context, CancellationToken cancellationToken);
}

public interface IPipelineEngine
{
    Task<RunManifest> RunAsync(PipelineContext context, CancellationToken cancellationToken);
}

public interface IRunManifestStore
{
    Task<RunManifest?> LoadLatestAsync(string workspaceRoot, CancellationToken cancellationToken);
    Task SaveAsync(PipelineContext context, RunManifest manifest, CancellationToken cancellationToken);
}
