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

            Assert.Contains(symbols, symbol => symbol.Kind == "typedef" && symbol.Name == "Example");
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
}
