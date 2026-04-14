using System.Net.Http.Json;
using SpecBuilder.Application;
using System.Text.Json;

namespace SpecBuilder.Infrastructure;

public sealed class OllamaClient : IOllamaClient
{
    private readonly HttpClient _httpClient;
    private readonly IPipelineReporter? _reporter;

    public OllamaClient(HttpClient httpClient, IPipelineReporter? reporter = null)
    {
        _httpClient = httpClient;
        _reporter = reporter;
    }

    public async Task<OllamaChatResult> ChatAsync(string model, string systemPrompt, string userPrompt, OllamaCallContext? context, CancellationToken cancellationToken)
    {
        var callContext = context ?? new OllamaCallContext("ollama.chat");
        _reporter?.OnOllamaCallStarted(callContext, model, Preview(userPrompt));
        var started = DateTimeOffset.UtcNow;
        var payload = new
        {
            model,
            stream = false,
            think = false,
            messages = new[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = userPrompt }
            },
            options = new { temperature = 0.0, top_p = 0.8, num_predict = 160 }
        };

        var requestJson = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
        using var response = await _httpClient.PostAsJsonAsync("/api/chat", payload, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var json = JsonSerializer.Deserialize<OllamaChatResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var content = json?.Message?.Content?.Trim() ?? json?.Response?.Trim();
        _reporter?.OnOllamaCallFinished(callContext, model, DateTimeOffset.UtcNow - started, json?.DoneReason ?? "unknown", Preview(content ?? string.Empty));
        return new OllamaChatResult(
            RequestJson: requestJson,
            ResponseJson: responseJson,
            Content: content,
            SourceField: json?.Message?.Content is { Length: > 0 } ? "message.content" : json?.Response is { Length: > 0 } ? "response" : "none",
            ThinkingPreview: json?.Message?.Thinking,
            DoneReason: json?.DoneReason);
    }

    private sealed record OllamaChatResponse(OllamaMessage? Message, string? Response, string? DoneReason);
    private sealed record OllamaMessage(string? Content, string? Thinking);

    private static string Preview(string text)
        => string.IsNullOrWhiteSpace(text) ? "<empty>" : text.ReplaceLineEndings(" ").Trim()[(0)..Math.Min(180, text.ReplaceLineEndings(" ").Trim().Length)] + (text.ReplaceLineEndings(" ").Trim().Length > 180 ? "..." : string.Empty);
}
