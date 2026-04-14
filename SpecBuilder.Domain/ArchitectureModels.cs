namespace SpecBuilder.Domain;

public static class ArchitectureComponents
{
    public static readonly string[] Allowed =
    [
        "Presentation / UI",
        "Controller / API / Interface",
        "Business Logic / Application Services",
        "Domain Models",
        "State Management",
        "Data Access / Database",
        "Network / Communication / Protocol",
        "Infrastructure / Platform",
        "Configuration",
        "Security / Authentication / Authorization",
        "Logging / Monitoring",
        "Utilities / Shared",
        "Integration / External Systems",
        "Mapping / Translation",
        "Transformation / Processing",
        "Serialization / Deserialization",
        "Compression / Archiving",
        "Scheduling / Jobs / Workers",
        "Unclassified"
    ];

    public static readonly HashSet<string> Technical =
    [
        "State Management",
        "Data Access / Database",
        "Network / Communication / Protocol",
        "Infrastructure / Platform",
        "Configuration",
        "Security / Authentication / Authorization",
        "Logging / Monitoring",
        "Utilities / Shared",
        "Integration / External Systems",
        "Mapping / Translation",
        "Transformation / Processing",
        "Serialization / Deserialization",
        "Compression / Archiving",
        "Scheduling / Jobs / Workers"
    ];
}

public sealed record SourceSymbol(
    int SourceLineNo,
    string OriginalRow,
    string File,
    string Kind,
    string Name,
    string QualifiedName,
    int StartLine,
    int EndLine,
    string Parent,
    string DataType,
    string DataShape,
    string Signature,
    string LineDescription = "",
    string? ComponentName = null,
    string? Category = null);

public sealed record SubcomponentRecord(
    string SubcomponentName,
    string SubcomponentDescription,
    IReadOnlyList<SourceSymbol> Symbols);

public sealed record ComponentRecord(
    string ComponentName,
    string Category,
    string ComponentOverview,
    IReadOnlyList<SubcomponentRecord> Subcomponents);
