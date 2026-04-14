using System.Text.Json;
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

        var currentAnalysis = await LoadAnalysisAsync(previous, context, cancellationToken).ConfigureAwait(false);
        var executionContext = context with { Inputs = inputs, Analysis = currentAnalysis };
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
                if (step.StepId == "step-03-classification" && !HasNonEmptyClassificationOutput(cached.OutputPath))
                {
                    cached = null;
                }
            }

            if (cached is not null)
            {
                var cloned = await CloneCachedRecordAsync(cached, context, cancellationToken).ConfigureAwait(false);
                currentAnalysis = await ReloadAnalysisAsync(context, cancellationToken).ConfigureAwait(false) ?? currentAnalysis;
                executionContext = executionContext with { Analysis = currentAnalysis };
                records.Add(cloned with
                {
                    Status = StepStatus.Cached,
                    InputHash = inputHash,
                    StartedAtUtc = DateTimeOffset.UtcNow,
                    CompletedAtUtc = DateTimeOffset.UtcNow,
                    Duration = TimeSpan.Zero
                });
                continue;
            }

            var started = DateTimeOffset.UtcNow;
            var record = await step.ExecuteAsync(executionContext, cancellationToken).ConfigureAwait(false);
            var completed = DateTimeOffset.UtcNow;
            currentAnalysis = await ReloadAnalysisAsync(context, cancellationToken).ConfigureAwait(false) ?? currentAnalysis;
            executionContext = executionContext with { Analysis = currentAnalysis };
            records.Add(record with
            {
                InputHash = inputHash,
                StartedAtUtc = record.StartedAtUtc ?? started,
                CompletedAtUtc = record.CompletedAtUtc ?? completed,
                Duration = record.Duration ?? (completed - started)
            });
        }

        var manifest = new RunManifest(
            RunId: context.RunId,
            WorkspaceId: context.Workspace.WorkspaceId,
            StartedAtUtc: DateTimeOffset.UtcNow,
            CompletedAtUtc: DateTimeOffset.UtcNow,
            SelectedSteps: context.SelectedSteps,
            Steps: records);

        await _manifestStore.SaveAsync(context, manifest, cancellationToken).ConfigureAwait(false);
        await UpdateAnalysisTelemetryAsync(context, manifest, cancellationToken).ConfigureAwait(false);
        return manifest;
    }

    private static StepRecord? TryGetCachedStep(RunManifest? previous, string stepId, string inputHash)
    {
        var cached = previous?.Steps.FirstOrDefault(x => x.StepId == stepId && x.InputHash == inputHash);
        if (cached is null || string.IsNullOrWhiteSpace(cached.OutputPath))
        {
            return null;
        }

        var fileName = Path.GetFileName(cached.OutputPath);
        return string.Equals(fileName, "analysis.json", StringComparison.OrdinalIgnoreCase) ? cached : null;
    }

    private static bool HasNonEmptyClassificationOutput(string? outputPath)
    {
        if (string.IsNullOrWhiteSpace(outputPath) || !File.Exists(outputPath))
        {
            return false;
        }

        try
        {
            var text = File.ReadAllText(outputPath);
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var doc = JsonSerializer.Deserialize<RunAnalysisDocument>(text, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return doc?.Classification.Items.Count > 0;
        }
        catch
        {
            return false;
        }
    }

    private static async Task<RunAnalysisDocument> LoadAnalysisAsync(RunManifest? previous, PipelineContext context, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        return new RunAnalysisDocument(
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

    private static async Task<RunAnalysisDocument?> ReloadAnalysisAsync(PipelineContext context, CancellationToken cancellationToken)
    {
        var path = Path.Combine(context.RunRoot, "analysis.json");
        if (!File.Exists(path))
        {
            return null;
        }

        try
        {
            var text = await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);
            return JsonSerializer.Deserialize<RunAnalysisDocument>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch
        {
            return null;
        }
    }

    private async Task<StepRecord> CloneCachedRecordAsync(StepRecord cached, PipelineContext context, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(cached.OutputPath))
        {
            return cached;
        }

        if (File.Exists(cached.OutputPath))
        {
            var currentPath = Path.Combine(context.RunRoot, Path.GetFileName(cached.OutputPath));
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

    private static async Task UpdateAnalysisTelemetryAsync(PipelineContext context, RunManifest manifest, CancellationToken cancellationToken)
    {
        var path = Path.Combine(context.RunRoot, "analysis.json");
        if (!File.Exists(path))
        {
            return;
        }

        try
        {
            var text = await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);
            var analysis = JsonSerializer.Deserialize<RunAnalysisDocument>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (analysis is null)
            {
                return;
            }

            var telemetry = new RunTelemetrySection(
                OllamaCallCount: 0,
                Steps: manifest.Steps
                    .Where(step => step.StartedAtUtc is not null && step.CompletedAtUtc is not null)
                    .Select(step => new StepTelemetryRecord(
                        StepId: step.StepId,
                        DisplayName: step.DisplayName,
                        StartedAtUtc: step.StartedAtUtc!.Value,
                        CompletedAtUtc: step.CompletedAtUtc!.Value,
                        DurationSeconds: step.Duration?.TotalSeconds ?? 0))
                    .ToArray());

            var updated = analysis with { Telemetry = telemetry, UpdatedAtUtc = DateTimeOffset.UtcNow };
            await File.WriteAllTextAsync(path, JsonSerializer.Serialize(updated, new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase }), cancellationToken).ConfigureAwait(false);
        }
        catch
        {
        }
    }
}
