using System.Net.Http.Json;
using SpecBuilder.Application;
using System.Text.Json;

namespace SpecBuilder.Infrastructure;

public sealed class OllamaClient(HttpClient httpClient) : IOllamaClient
{
    public async Task<OllamaChatResult> ChatAsync(string model, string systemPrompt, string userPrompt, CancellationToken cancellationToken)
    {
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
        using var response = await httpClient.PostAsJsonAsync("/api/chat", payload, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var json = JsonSerializer.Deserialize<OllamaChatResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var content = json?.Message?.Content?.Trim() ?? json?.Response?.Trim();
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
}
