using SpecBuilder.Domain;

namespace SpecBuilder.Application;

public sealed class PipelineEngine : IPipelineEngine
{
    private readonly IReadOnlyList<IPipelineStep> _steps;
    private readonly IRunManifestStore _manifestStore;
    private readonly IArtifactStore _artifactStore;

    public PipelineEngine(IEnumerable<IPipelineStep> steps, IRunManifestStore manifestStore, IArtifactStore artifactStore)
    {
        _steps = steps.OrderBy(s => s.StepId, StringComparer.Ordinal).ToArray();
        _manifestStore = manifestStore;
        _artifactStore = artifactStore;
    }

    public async Task<RunManifest> RunAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var previous = await _manifestStore.LoadLatestAsync(context.WorkspaceRoot, cancellationToken).ConfigureAwait(false);
        var inputs = new Dictionary<string, string>(context.Inputs, StringComparer.Ordinal);
        if (previous is not null)
        {
            foreach (var step in previous.Steps)
            {
                if (!string.IsNullOrWhiteSpace(step.OutputPath))
                {
                    inputs[$"previous-output:{step.StepId}"] = step.OutputPath!;
                }
                if (!string.IsNullOrWhiteSpace(step.InputHash))
                {
                    inputs[$"previous-input:{step.StepId}"] = step.InputHash!;
                }
            }
        }

        var executionContext = context with { Inputs = inputs };
        var records = new List<StepRecord>(_steps.Count);
        foreach (var step in _steps)
        {
            if (context.SelectedSteps.Count > 0 && !context.SelectedSteps.Contains(step.StepId, StringComparer.Ordinal))
            {
                continue;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var inputHash = await step.ComputeInputHashAsync(executionContext, cancellationToken).ConfigureAwait(false);
            var cached = TryGetCachedStep(previous, step.StepId, inputHash);
            if (cached is not null)
            {
                records.Add(await CloneCachedRecordAsync(cached, context, cancellationToken).ConfigureAwait(false) with { Status = StepStatus.Cached, InputHash = inputHash });
                continue;
            }

            var record = await step.ExecuteAsync(executionContext, cancellationToken).ConfigureAwait(false);
            records.Add(record with { InputHash = inputHash });
        }

        var manifest = new RunManifest(
            RunId: context.RunId,
            WorkspaceId: context.Workspace.WorkspaceId,
            StartedAtUtc: DateTimeOffset.UtcNow,
            CompletedAtUtc: DateTimeOffset.UtcNow,
            SelectedSteps: context.SelectedSteps,
            Steps: records);

        await _manifestStore.SaveAsync(context, manifest, cancellationToken).ConfigureAwait(false);
        return manifest;
    }

    private static StepRecord? TryGetCachedStep(RunManifest? previous, string stepId, string inputHash)
    {
        var cached = previous?.Steps.FirstOrDefault(x => x.StepId == stepId && x.InputHash == inputHash);
        return cached is null || string.IsNullOrWhiteSpace(cached.OutputPath) ? null : cached;
    }

    private async Task<StepRecord> CloneCachedRecordAsync(StepRecord cached, PipelineContext context, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(cached.OutputPath))
        {
            return cached;
        }

        if (File.Exists(cached.OutputPath))
        {
            var currentPath = Path.Combine(context.RunRoot, cached.StepId, Path.GetFileName(cached.OutputPath));
            var currentDir = Path.GetDirectoryName(currentPath);
            if (!string.IsNullOrWhiteSpace(currentDir))
            {
                Directory.CreateDirectory(currentDir);
            }

            File.Copy(cached.OutputPath, currentPath, overwrite: true);
            return cached with { OutputPath = currentPath };
        }

        return cached;
    }
}
