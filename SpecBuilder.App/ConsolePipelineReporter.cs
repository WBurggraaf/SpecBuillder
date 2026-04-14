using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.App;

public sealed class ConsolePipelineReporter : IPipelineReporter
{
    private int _ollamaCallCount;
    public int OllamaCallCount => _ollamaCallCount;

    public void OnStepStarted(string stepId, string displayName, string description)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine($"[{stepId}] {displayName}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"  {description}");
        Console.ForegroundColor = previous;
    }

    public void OnStepFinished(string stepId, string displayName, StepStatus status, string summary)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = status switch
        {
            StepStatus.Success => ConsoleColor.Green,
            StepStatus.Cached => ConsoleColor.DarkGreen,
            StepStatus.Warning => ConsoleColor.Yellow,
            StepStatus.Failed => ConsoleColor.Red,
            _ => ConsoleColor.Gray
        };

        Console.WriteLine($"  -> {status}: {summary}");
        Console.ForegroundColor = previous;
    }

    public void WriteRunTelemetrySummary()
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("[Run Telemetry]");
        Console.ForegroundColor = previous;
        Console.WriteLine($"Ollama calls: {_ollamaCallCount}");
    }

    public void OnOllamaCallStarted(OllamaCallContext context, string model, string requestPreview)
    {
        _ollamaCallCount++;
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"    Ollama #{_ollamaCallCount} [{context.Phase}] model={model}{FormatContext(context)}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"      request: {requestPreview}");
        Console.ForegroundColor = previous;
    }

    public void OnOllamaCallFinished(OllamaCallContext context, string model, TimeSpan duration, string doneReason, string responsePreview)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"    Ollama complete [{context.Phase}] {duration.TotalSeconds:F1}s, done={doneReason}{FormatContext(context)}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"      response: {responsePreview}");
        Console.ForegroundColor = previous;
    }

    private static string FormatContext(OllamaCallContext context)
    {
        var parts = new List<string>();
        if (context.RowNumber is not null)
        {
            parts.Add($"row={context.RowNumber}");
        }
        if (context.Attempt is not null)
        {
            parts.Add($"attempt={context.Attempt}");
        }
        if (context.IsRepair)
        {
            parts.Add("repair");
        }
        return parts.Count == 0 ? string.Empty : $" ({string.Join(", ", parts)})";
    }
}
