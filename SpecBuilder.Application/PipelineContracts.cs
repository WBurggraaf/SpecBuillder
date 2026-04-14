using SpecBuilder.Domain;

namespace SpecBuilder.Application;

public sealed record PipelineRunContext(
    WorkspaceDefinition Workspace,
    string WorkspaceRoot,
    string RunId,
    string RunRoot,
    string SelectedStep,
    bool ForceRerun);

public interface IArtifactStore
{
    string GetStepRoot(PipelineContext context, string stepId);
    Task WriteTextAsync(PipelineContext context, string stepId, string fileName, string content, CancellationToken cancellationToken);
    Task WriteJsonAsync<T>(PipelineContext context, string stepId, string fileName, T value, CancellationToken cancellationToken);
    Task<T?> ReadJsonAsync<T>(string path, CancellationToken cancellationToken);
    Task<string?> ReadTextAsync(string path, CancellationToken cancellationToken);
}

public interface ISourceSymbolExtractor
{
    Task<IReadOnlyList<SourceSymbol>> ExtractAsync(string sourceRoot, CancellationToken cancellationToken);
}

public interface IComponentClassifier
{
    Task<IReadOnlyList<SourceSymbol>> ClassifyAsync(IReadOnlyList<SourceSymbol> symbols, string introduction, string model, PipelineContext context, CancellationToken cancellationToken);
}

public sealed record OllamaChatResult(
    string RequestJson,
    string ResponseJson,
    string? Content,
    string SourceField,
    string? ThinkingPreview,
    string? DoneReason);

public interface IComponentHierarchyBuilder
{
    Task<IReadOnlyList<ComponentRecord>> BuildAsync(IReadOnlyList<SourceSymbol> symbols, string introduction, string model, CancellationToken cancellationToken);
}

public interface ICallerEnricher
{
    Task<string> EnrichAsync(IReadOnlyList<ComponentRecord> hierarchy, string sourceRoot, string model, CancellationToken cancellationToken);
}

public interface IOllamaClient
{
    Task<OllamaChatResult> ChatAsync(string model, string systemPrompt, string userPrompt, CancellationToken cancellationToken);
}
