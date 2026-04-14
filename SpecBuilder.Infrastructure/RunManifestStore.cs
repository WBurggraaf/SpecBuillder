using System.Text.Json;
using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.Infrastructure;

public sealed class RunManifestStore : IRunManifestStore
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task<RunManifest?> LoadLatestAsync(string workspaceRoot, CancellationToken cancellationToken)
    {
        var runsRoot = Path.Combine(workspaceRoot, ".specbuilder", "runs");
        if (!Directory.Exists(runsRoot))
        {
            return null;
        }

        foreach (var dir in Directory.EnumerateDirectories(runsRoot).OrderByDescending(x => x, StringComparer.Ordinal))
        {
            var manifestPath = Path.Combine(dir, "manifest.json");
            if (!File.Exists(manifestPath))
            {
                continue;
            }

            await using var stream = File.OpenRead(manifestPath);
            var manifest = await JsonSerializer.DeserializeAsync<RunManifest>(stream, JsonOptions, cancellationToken).ConfigureAwait(false);
            if (manifest is not null)
            {
                return manifest;
            }
        }

        return null;
    }

    public async Task SaveAsync(PipelineContext context, RunManifest manifest, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(context.RunRoot);
        var manifestPath = Path.Combine(context.RunRoot, "manifest.json");
        await using var stream = File.Create(manifestPath);
        await JsonSerializer.SerializeAsync(stream, manifest, JsonOptions, cancellationToken).ConfigureAwait(false);
    }
}
