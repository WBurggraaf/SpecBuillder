using SpecBuilder.Domain;
using SpecBuilder.Infrastructure;

namespace SpecBuilder.Tests;

public class PipelineTests
{
    [Fact]
    public void WorkspaceDefinition_PreservesValues()
    {
        var workspace = new WorkspaceDefinition("ws", "src", "intro.txt", "model", "v1");

        Assert.Equal("ws", workspace.WorkspaceId);
        Assert.Equal("src", workspace.SourceRoot);
    }

    [Fact]
    public async Task SymbolExtractor_IgnoresCommentOnlyLines_AndCapturesBasicCDeclarations()
    {
        var tempRoot = Path.Combine(Path.GetTempPath(), $"specbuilder-tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempRoot);

        try
        {
            var filePath = Path.Combine(tempRoot, "sample.c");
            await File.WriteAllTextAsync(filePath, """
/* header comment */
typedef struct Example {
    int value;
} Example;

static int add(int left, int right) {
    return left + right;
}
""");

            var extractor = new TreeSymbolExtractor();
            var symbols = await extractor.ExtractAsync(tempRoot, CancellationToken.None);

            var structSymbol = Assert.Single(symbols.Where(symbol => symbol.Kind == "struct" && symbol.Name == "Example"));
            var functionSymbol = Assert.Single(symbols.Where(symbol => symbol.Kind == "function" && symbol.Name == "add"));
            Assert.True(functionSymbol.EndLine > functionSymbol.StartLine);
            Assert.Equal("int", functionSymbol.DataType);
            Assert.True(structSymbol.EndLine > structSymbol.StartLine);
            Assert.Contains(symbols, symbol => symbol.Kind == "function" && symbol.Name == "add");
            Assert.DoesNotContain(symbols, symbol => symbol.Signature.Contains("header comment", StringComparison.OrdinalIgnoreCase));
        }
        finally
        {
            if (Directory.Exists(tempRoot))
            {
                Directory.Delete(tempRoot, recursive: true);
            }
        }
    }

    [Fact]
    public void FlatSymbolsText_FormatMatchesPythonStyleLayout()
    {
        var symbols = new[]
        {
            new SourceSymbol(1, "row", @"C:\\src\\x.c", "function", "foo", "foo", 1, 3, "", "int", "scalar_or_unknown", "int foo(void) {"),
            new SourceSymbol(2, "row", @"C:\\src\\x.c", "field", "bar", "bar", 5, 5, "", "char", "scalar_or_unknown", "char bar;")
        };

        var text = InvokeBuildSymbolsText(symbols);

        Assert.StartsWith("file | kind | name | qualified_name | start_line | end_line | parent | data_type | data_shape | signature", text);
        Assert.Contains(@"C:\\src\\x.c | function | foo | foo | 1 | 3 |  | int | scalar_or_unknown | int foo(void) {", text);
        Assert.Contains(@"C:\\src\\x.c | field | bar | bar | 5 | 5 |  | char | scalar_or_unknown | char bar;", text);
    }

    private static string InvokeBuildSymbolsText(IReadOnlyList<SourceSymbol> symbols)
    {
        var method = typeof(SymbolExtractionStep).GetMethod("BuildSymbolsText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        Assert.NotNull(method);
        return (string)method!.Invoke(null, new object[] { symbols })!;
    }
}
