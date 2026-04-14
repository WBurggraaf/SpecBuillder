using System.Text.Json;
using SpecBuilder.Application;

namespace SpecBuilder.Infrastructure;

public sealed class FileArtifactStore : IArtifactStore
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public string GetStepRoot(PipelineContext context, string stepId)
    {
        var path = Path.Combine(context.RunRoot, stepId);
        Directory.CreateDirectory(path);
        return path;
    }

    public async Task WriteTextAsync(PipelineContext context, string stepId, string fileName, string content, CancellationToken cancellationToken)
    {
        var path = Path.Combine(GetStepRoot(context, stepId), fileName);
        await File.WriteAllTextAsync(path, content, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteJsonAsync<T>(PipelineContext context, string stepId, string fileName, T value, CancellationToken cancellationToken)
    {
        var path = Path.Combine(GetStepRoot(context, stepId), fileName);
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, value, JsonOptions, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteRunJsonAsync<T>(PipelineContext context, string fileName, T value, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(context.RunRoot);
        var path = Path.Combine(context.RunRoot, fileName);
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, value, JsonOptions, cancellationToken).ConfigureAwait(false);
    }

    public async Task<T?> ReadJsonAsync<T>(string path, CancellationToken cancellationToken)
    {
        if (!File.Exists(path))
        {
            return default;
        }

        await using var stream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<T>(stream, JsonOptions, cancellationToken).ConfigureAwait(false);
    }

    public async Task<string?> ReadTextAsync(string path, CancellationToken cancellationToken)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        return await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);
    }

    public async Task<T?> ReadRunJsonAsync<T>(PipelineContext context, string fileName, CancellationToken cancellationToken)
    {
        var path = Path.Combine(context.RunRoot, fileName);
        return await ReadJsonAsync<T>(path, cancellationToken).ConfigureAwait(false);
    }
}
