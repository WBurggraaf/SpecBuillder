using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpecBuilder.App;
using SpecBuilder.Application;
using SpecBuilder.Domain;
using SpecBuilder.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IPipelineEngine, PipelineEngine>();
builder.Services.AddSingleton<IRunManifestStore, RunManifestStore>();
builder.Services.AddSingleton<IArtifactStore, FileArtifactStore>();
builder.Services.AddSingleton<ConsolePipelineReporter>();
builder.Services.AddSingleton<IPipelineReporter>(sp => sp.GetRequiredService<ConsolePipelineReporter>());
builder.Services.AddSingleton<ISourceSymbolExtractor, TreeSymbolExtractor>();
builder.Services.AddSingleton<IComponentClassifier, OllamaComponentClassifier>();
builder.Services.AddSingleton<IComponentHierarchyBuilder, OllamaHierarchyBuilder>();
builder.Services.AddSingleton<ICallerEnricher, CallerEnricher>();
builder.Services.AddSingleton<IPipelineStep, DiscoveryStep>();
builder.Services.AddSingleton<IPipelineStep, SymbolExtractionStep>();
builder.Services.AddSingleton<IPipelineStep, ClassificationStep>();
builder.Services.AddSingleton<IPipelineStep, HierarchyStep>();
builder.Services.AddSingleton<IPipelineStep, CallerEnrichmentStep>();
builder.Services.AddSingleton<IPipelineStep, ExportStep>();
builder.Services.AddHttpClient<IOllamaClient, OllamaClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434");
});

using var app = builder.Build();

var workspaceRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
var workspace = new WorkspaceDefinition(
    WorkspaceId: "default-workspace",
    SourceRoot: Path.Combine(workspaceRoot, "ngircd-master"),
    IntroductionFile: Path.Combine(workspaceRoot, "introduction.txt"),
    OllamaModel: "emma4:e2b",
    PromptVersion: "v1");

var engine = app.Services.GetRequiredService<IPipelineEngine>();
var reporter = app.Services.GetRequiredService<ConsolePipelineReporter>();
Directory.CreateDirectory(Path.Combine(workspaceRoot, ".specbuilder", "runs"));

if (args.Contains("--run-full", StringComparer.OrdinalIgnoreCase))
{
        await RunPipelineAsync(engine, reporter, workspace, workspaceRoot, Array.Empty<string>(), forceRerun: false);
        return;
}

while (true)
{
    ConsoleUi.ShowBanner(workspace);
    ConsoleUi.ShowModelStatus(workspace);
    ConsoleUi.ShowMenu();
    var choice = (Console.ReadLine() ?? string.Empty).Trim();

    switch (choice)
    {
        case "1":
            await RunPipelineAsync(engine, reporter, workspace, workspaceRoot, Array.Empty<string>(), forceRerun: false);
            break;
        case "2":
        {
            var steps = ConsoleUi.GetPipelineSteps();
            var selected = ConsoleUi.PromptForStepSelection(steps);
            if (!string.IsNullOrWhiteSpace(selected))
            {
                await RunPipelineAsync(engine, reporter, workspace, workspaceRoot, [selected], forceRerun: true);
            }
            break;
        }
        case "3":
            ConsoleUi.ShowRunBrowser(workspaceRoot);
            break;
        case "4":
            return;
        default:
            ConsoleUi.WriteWarning("Unknown option. Choose 1, 2, 3, or 4.");
            break;
    }

    Console.WriteLine();
    ConsoleUi.PromptToContinue();
}

static async Task RunPipelineAsync(IPipelineEngine engine, ConsolePipelineReporter reporter, WorkspaceDefinition workspace, string workspaceRoot, IReadOnlyList<string> selectedSteps, bool forceRerun)
{
    var runId = DateTimeOffset.UtcNow.ToString("yyyyMMdd-HHmmss");
    var runRoot = Path.Combine(workspaceRoot, ".specbuilder", "runs", runId);
    Directory.CreateDirectory(runRoot);

    var context = new PipelineContext(
        Workspace: workspace,
        WorkspaceRoot: workspaceRoot,
        RunId: runId,
        RunRoot: runRoot,
        Inputs: new Dictionary<string, string>(),
        SelectedSteps: selectedSteps);

    ConsoleUi.ShowRunStart(runId, selectedSteps, forceRerun);
    var manifest = await engine.RunAsync(context, CancellationToken.None);
    ConsoleUi.ShowRunSummary(manifest);
    ConsoleUi.ShowModelStatus(workspace);
    reporter.WriteRunTelemetrySummary();
}
