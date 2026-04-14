using SpecBuilder.Domain;
using System.Text.Json;

namespace SpecBuilder.App;

public static class ConsoleUi
{
    private static readonly string[] PipelineSteps =
    [
        "step-01-discovery",
        "step-02-symbols",
        "step-03-classification",
        "step-04-hierarchy",
        "step-05-callers",
        "step-06-export"
    ];

    public static IReadOnlyList<string> GetPipelineSteps() => PipelineSteps;

    public static void ShowBanner(WorkspaceDefinition workspace)
    {
        if (!Console.IsOutputRedirected)
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                // Ignore non-interactive consoles.
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("SpecBuilder");
        Console.ResetColor();
        Console.WriteLine("Step-based console rebuild for symbol analysis and architecture grouping.");
        Console.WriteLine($"Workspace: {workspace.WorkspaceId}");
        Console.WriteLine($"Source: {workspace.SourceRoot}");
        Console.WriteLine($"Intro: {workspace.IntroductionFile}");
        Console.WriteLine();
    }

    public static void ShowMenu()
    {
        WriteHeader("Main Menu");
        Console.WriteLine("1. Run full pipeline");
        Console.WriteLine("2. Rerun selected step");
        Console.WriteLine("3. Inspect runs");
        Console.WriteLine("4. Exit");
        Console.Write("Select: ");
    }

    public static string PromptForStepSelection(IReadOnlyList<string> steps)
    {
        WriteHeader("Select Step");
        for (var i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }

        Console.Write("Step: ");
        var input = (Console.ReadLine() ?? string.Empty).Trim();
        if (!int.TryParse(input, out var index) || index < 1 || index > steps.Count)
        {
            WriteWarning("Invalid step selection.");
            return string.Empty;
        }

        return steps[index - 1];
    }

    public static void ShowRunStart(string runId, IReadOnlyList<string> selectedSteps, bool forceRerun)
    {
        WriteHeader("Run Started");
        Console.WriteLine($"Run ID: {runId}");
        Console.WriteLine($"Force rerun: {forceRerun}");
        Console.WriteLine(selectedSteps.Count == 0 ? "Selected steps: all" : $"Selected steps: {string.Join(", ", selectedSteps)}");
        Console.WriteLine();
    }

    public static void ShowRunSummary(RunManifest manifest)
    {
        WriteHeader("Run Summary");
        Console.WriteLine($"Run: {manifest.RunId}");
        Console.WriteLine($"Workspace: {manifest.WorkspaceId}");
        Console.WriteLine($"Steps: {manifest.Steps.Count}");
        foreach (var step in manifest.Steps)
        {
            WriteStepLine(step.StepId, step.DisplayName, step.Status, step.OutputPath);
        }
    }

    public static void ShowRunBrowser(string workspaceRoot)
    {
        WriteHeader("Runs");
        var runsRoot = Path.Combine(workspaceRoot, ".specbuilder", "runs");
        if (!Directory.Exists(runsRoot))
        {
            WriteWarning("No runs found.");
            return;
        }

        var runs = Directory.EnumerateDirectories(runsRoot)
            .Select(Path.GetFileName)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .OrderByDescending(x => x, StringComparer.Ordinal)
            .Take(20)
            .ToArray();

        if (runs.Length == 0)
        {
            WriteWarning("No runs found.");
            return;
        }

        for (var i = 0; i < runs.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {runs[i]}");
        }

        Console.Write("Open run number (or Enter to return): ");
        var input = (Console.ReadLine() ?? string.Empty).Trim();
        if (!int.TryParse(input, out var index) || index < 1 || index > runs.Length)
        {
            return;
        }

        ShowRunDetails(workspaceRoot, runs[index - 1]!);
    }

    public static void ShowRunDetails(string workspaceRoot, string runId)
    {
        var manifestPath = Path.Combine(workspaceRoot, ".specbuilder", "runs", runId, "manifest.json");
        if (!File.Exists(manifestPath))
        {
            WriteWarning($"Manifest not found for run {runId}.");
            return;
        }

        var json = File.ReadAllText(manifestPath);
        var manifest = JsonSerializer.Deserialize<RunManifest>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (manifest is null)
        {
            WriteWarning("Could not read manifest.");
            return;
        }

        ShowRunSummary(manifest);
    }

    public static void PromptToContinue()
    {
        Console.Write("Press Enter to continue...");
        _ = Console.ReadLine();
    }

    public static void WriteWarning(string message)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = previous;
    }

    public static void WriteStepLine(string stepId, string displayName, StepStatus status, string? outputPath)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = status switch
        {
            StepStatus.Success => ConsoleColor.Green,
            StepStatus.Cached => ConsoleColor.DarkGreen,
            StepStatus.Warning => ConsoleColor.Yellow,
            StepStatus.Failed => ConsoleColor.Red,
            StepStatus.Running => ConsoleColor.Cyan,
            _ => ConsoleColor.Gray
        };

        var statusText = status.ToString().ToUpperInvariant().PadRight(8);
        Console.WriteLine($"[{statusText}] {stepId} - {displayName}");
        if (!string.IsNullOrWhiteSpace(outputPath))
        {
            Console.WriteLine($"          {outputPath}");
        }

        Console.ForegroundColor = previous;
    }

    private static void WriteHeader(string title)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"[{title}]");
        Console.ResetColor();
    }
}
