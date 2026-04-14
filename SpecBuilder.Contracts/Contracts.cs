namespace SpecBuilder.Contracts;

public sealed record SymbolRowDto(
    string File,
    string Kind,
    string Name,
    string QualifiedName,
    int StartLine,
    int EndLine,
    string Parent,
    string DataType,
    string DataShape,
    string Signature);

public sealed record PipelineStepResultDto(
    string StepId,
    string Status,
    string? OutputPath,
    string? Message);
