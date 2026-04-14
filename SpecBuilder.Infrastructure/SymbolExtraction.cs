using System.Text.RegularExpressions;
using SpecBuilder.Application;
using SpecBuilder.Domain;

namespace SpecBuilder.Infrastructure;

public sealed class TreeSymbolExtractor : ISourceSymbolExtractor
{
    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".c", ".h", ".cpp", ".cc", ".cxx", ".hpp", ".hh", ".hxx", ".py", ".java", ".cs"
    };

    public Task<IReadOnlyList<SourceSymbol>> ExtractAsync(string sourceRoot, CancellationToken cancellationToken)
    {
        var symbols = new List<SourceSymbol>();

        foreach (var file in Directory.EnumerateFiles(sourceRoot, "*.*", SearchOption.AllDirectories))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!Extensions.Contains(Path.GetExtension(file)))
            {
                continue;
            }

            var ext = Path.GetExtension(file).ToLowerInvariant();
            var lines = File.ReadAllLines(file);
            if (ext is ".c" or ".h" or ".cpp" or ".cc" or ".cxx" or ".hpp" or ".hh" or ".hxx")
            {
                symbols.AddRange(ExtractCStyleSymbols(file, lines));
            }
            else if (ext == ".cs")
            {
                symbols.AddRange(ExtractCSharpSymbols(file, lines));
            }
            else if (ext == ".py")
            {
                symbols.AddRange(ExtractPythonSymbols(file, lines));
            }
            else if (ext == ".java")
            {
                symbols.AddRange(ExtractJavaSymbols(file, lines));
            }
        }

        return Task.FromResult<IReadOnlyList<SourceSymbol>>(symbols);
    }

    private static IEnumerable<SourceSymbol> ExtractCStyleSymbols(string file, string[] lines)
    {
        var results = new List<SourceSymbol>();
        var scopeStack = new Stack<ScopeFrame>();
        var pending = string.Empty;
        var pendingStartLine = 0;
        var blockCommentDepth = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var raw = lines[i];
            var line = StripComments(raw, ref blockCommentDepth).Trim();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (IsCommentOnly(line))
            {
                continue;
            }

            if (pending.Length == 0)
            {
                pendingStartLine = i + 1;
            }
            pending = string.IsNullOrWhiteSpace(pending) ? line : $"{pending} {line}";

            if (!IsStatementComplete(pending))
            {
                continue;
            }

            var statement = CompactStatement(pending);

            if (TryParseTypeIntro(statement, pendingStartLine, lines, i, file, out var intro))
            {
                results.Add(intro.Symbol);
                if (intro.OpensScope)
                {
                    scopeStack.Push(new ScopeFrame(intro.Name, intro.Kind, intro.LineNo, intro.Signature));
                }
                pending = string.Empty;
                continue;
            }

            if (scopeStack.Count > 0 && TryParseField(statement, pendingStartLine, file, scopeStack.Peek(), out var field))
            {
                results.Add(field);
            }

            if (TryParseTypedefAlias(statement, pendingStartLine, file, out var typedefSymbol))
            {
                results.Add(typedefSymbol);
                pending = string.Empty;
                continue;
            }

            if (TryParseFunction(statement, pendingStartLine, lines, i, file, out var function))
            {
                results.Add(function);
                pending = string.Empty;
                continue;
            }

            if (TryParseStandaloneField(statement, pendingStartLine, file, out var standaloneField))
            {
                results.Add(standaloneField);
            }

            var opens = statement.Count(c => c == '{');
            var closes = statement.Count(c => c == '}');
            for (var n = 0; n < closes && scopeStack.Count > 0; n++)
            {
                var frame = scopeStack.Pop();
                if (frame.Kind is "struct" or "union" or "enum" or "class" && frame.StartLine != 0)
                {
                    continue;
                }

                results.Add(CreateSymbol(
                    file,
                    frame.Kind,
                    frame.Name,
                    frame.QualifiedName,
                    frame.StartLine,
                    FindScopeEndLine(lines, frame.StartLine - 1, i),
                    "",
                    "",
                    "",
                    frame.Signature,
                    frame.StartLine));
            }

            if (opens > closes && scopeStack.Count > 0)
            {
                // nested anonymous blocks remain within the current frame
            }

            pending = string.Empty;
        }

        return Deduplicate(results);
    }

    private static IEnumerable<SourceSymbol> ExtractPythonSymbols(string file, string[] lines)
    {
        var results = new List<SourceSymbol>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (line.StartsWith("class "))
            {
                var name = line.Split(new[] { ' ', ':' }, 3, StringSplitOptions.RemoveEmptyEntries).ElementAtOrDefault(1) ?? "<anonymous>";
                results.Add(CreateSymbol(file, "class", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
            else if (line.StartsWith("def "))
            {
                var name = line.Split(new[] { ' ', '(' }, 3, StringSplitOptions.RemoveEmptyEntries).ElementAtOrDefault(1) ?? "<anonymous>";
                results.Add(CreateSymbol(file, "function", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
            else if (line.Contains('=') && !line.StartsWith("#"))
            {
                var left = line.Split('=')[0].Trim();
                if (!string.IsNullOrWhiteSpace(left) && !left.Contains(" "))
                {
                    results.Add(CreateSymbol(file, "field", left, left, i + 1, i + 1, "", "", "", line, i + 1));
                }
            }
        }

        return Deduplicate(results);
    }

    private static IEnumerable<SourceSymbol> ExtractJavaSymbols(string file, string[] lines)
    {
        var results = new List<SourceSymbol>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (Regex.IsMatch(line, @"\b(class|interface|enum)\s+([A-Za-z_][A-Za-z0-9_]*)"))
            {
                var name = Regex.Match(line, @"\b(class|interface|enum)\s+([A-Za-z_][A-Za-z0-9_]*)").Groups[2].Value;
                results.Add(CreateSymbol(file, "type", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
            else if (Regex.IsMatch(line, @"\b([A-Za-z_][A-Za-z0-9_<>\[\]]*)\s+([A-Za-z_][A-Za-z0-9_]*)\s*\("))
            {
                var name = Regex.Match(line, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*\(").Groups[1].Value;
                results.Add(CreateSymbol(file, "method", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
        }

        return Deduplicate(results);
    }

    private static IEnumerable<SourceSymbol> ExtractCSharpSymbols(string file, string[] lines)
    {
        var results = new List<SourceSymbol>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (Regex.IsMatch(line, @"\b(class|struct|interface|enum)\s+([A-Za-z_][A-Za-z0-9_]*)"))
            {
                var name = Regex.Match(line, @"\b(class|struct|interface|enum)\s+([A-Za-z_][A-Za-z0-9_]*)").Groups[2].Value;
                results.Add(CreateSymbol(file, "type", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
            else if (Regex.IsMatch(line, @"\b([A-Za-z_][A-Za-z0-9_<>\[\]]*)\s+([A-Za-z_][A-Za-z0-9_]*)\s*\("))
            {
                var name = Regex.Match(line, @"\b([A-Za-z_][A-Za-z0-9_]*)\s*\(").Groups[1].Value;
                results.Add(CreateSymbol(file, "method", name, name, i + 1, i + 1, "", "", "", line, i + 1));
            }
        }

        return Deduplicate(results);
    }

    private static bool TryParseTypeIntro(string line, int lineNo, string[] lines, int currentIndex, string file, out TypeIntro intro)
    {
        intro = default!;
        var match = Regex.Match(line, @"^\s*(typedef\s+)?(struct|union|enum|class)\s+([A-Za-z_][A-Za-z0-9_]*)?(\s*\{)?");
        if (!match.Success)
        {
            return false;
        }

        var isTypedef = !string.IsNullOrWhiteSpace(match.Groups[1].Value);
        var kind = match.Groups[2].Value.ToLowerInvariant();
        var name = match.Groups[3].Value;
        var opensScope = line.Contains('{');
        var qualified = !string.IsNullOrWhiteSpace(name) ? name : "<anonymous>";

        if (!opensScope && !isTypedef)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(name) || (isTypedef && opensScope))
        {
            var endLine = opensScope ? FindScopeEndLine(lines, currentIndex, currentIndex) : lineNo;
            intro = new TypeIntro(
                File: file,
                Kind: kind,
                Name: string.IsNullOrWhiteSpace(name) ? "<anonymous>" : name,
                QualifiedName: qualified,
                LineNo: lineNo,
                EndLine: endLine,
                OpensScope: opensScope,
                Signature: line);
            return true;
        }

        return false;
    }

    private static bool TryParseTypedefAlias(string line, int lineNo, string file, out SourceSymbol symbol)
    {
        symbol = default!;
        if (!line.StartsWith("typedef ", StringComparison.Ordinal) || !line.Contains(';'))
        {
            return false;
        }

        var aliasMatch = Regex.Match(line, @"typedef\s+.+?\}\s*([A-Za-z_][A-Za-z0-9_]*)\s*;");
        if (aliasMatch.Success)
        {
            var name = aliasMatch.Groups[1].Value;
            symbol = CreateSymbol(file, "typedef", name, name, lineNo, lineNo, "", "", "", line, lineNo);
            return true;
        }

        var simpleAlias = Regex.Match(line, @"typedef\s+(.+?)\s+([A-Za-z_][A-Za-z0-9_]*)\s*;");
        if (simpleAlias.Success && !simpleAlias.Groups[1].Value.Contains("(", StringComparison.Ordinal))
        {
            var name = simpleAlias.Groups[2].Value;
            symbol = CreateSymbol(file, "typedef", name, name, lineNo, lineNo, "", "", "", line, lineNo);
            return true;
        }

        return false;
    }

    private static bool TryParseFunction(string line, int lineNo, string[] lines, int currentIndex, string file, out SourceSymbol symbol)
    {
        symbol = default!;
        if (!line.Contains('(') || !line.Contains(')') || !line.Contains('{'))
        {
            return false;
        }

        if (line.StartsWith("if ", StringComparison.Ordinal) || line.StartsWith("for ", StringComparison.Ordinal) || line.StartsWith("while ", StringComparison.Ordinal) || line.StartsWith("switch ", StringComparison.Ordinal) || line.StartsWith("else ", StringComparison.Ordinal) || line.StartsWith("return ", StringComparison.Ordinal))
        {
            return false;
        }

        var openParen = line.IndexOf('(');
        var prefix = line[..openParen].Trim();
        var nameMatch = Regex.Match(prefix, @"(?<prefix>.+\s+)(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*$");
        if (!nameMatch.Success)
        {
            return false;
        }

        var name = nameMatch.Groups["name"].Value;
        var beforeName = nameMatch.Groups["prefix"].Value.Trim();
        if (string.IsNullOrWhiteSpace(beforeName))
        {
            return false;
        }

        if (!LooksLikeFunctionDeclarationPrefix(beforeName))
        {
            return false;
        }

        if (name is "if" or "for" or "while" or "switch" or "return" or "catch" or "sizeof" or "static_cast" or "reinterpret_cast" or "const_cast" or "dynamic_cast")
        {
            return false;
        }
        var endLine = line.Contains('{') ? FindScopeEndLine(lines, currentIndex, currentIndex) : lineNo;
        var returnType = ExtractFunctionReturnType(line, name);
        var dataShape = string.IsNullOrWhiteSpace(returnType)
            ? ""
            : (returnType.Contains('*') || returnType.Contains('&') ? "pointer_or_reference" : "scalar_or_unknown");
        symbol = CreateSymbol(file, "function", name, name, lineNo, endLine, "", returnType, dataShape, line, lineNo);
        return true;
    }

    private static bool TryParseField(string line, int lineNo, string file, ScopeFrame scope, out SourceSymbol symbol)
    {
        symbol = default!;
        if (!line.EndsWith(";") || line.Contains("(") || line.Contains("typedef "))
        {
            return false;
        }

        var match = Regex.Match(line, @"^([A-Za-z_][A-Za-z0-9_<>\*\s:&]+?)\s+([A-Za-z_][A-Za-z0-9_]*)\s*(\[[^\]]+\])?\s*;");
        if (!match.Success)
        {
            return false;
        }

        var dataType = match.Groups[1].Value.Trim();
        var name = match.Groups[2].Value;
        var shape = dataType.Contains('*') || dataType.Contains('&') || dataType.Contains("ptr", StringComparison.OrdinalIgnoreCase) ? "pointer_or_reference" : "scalar_or_unknown";
        var qualified = $"{scope.QualifiedName}::{name}";
        symbol = CreateSymbol(file, "field", name, qualified, lineNo, lineNo, scope.Name, dataType, shape, line, lineNo);
        return true;
    }

    private static bool TryParseStandaloneField(string line, int lineNo, string file, out SourceSymbol symbol)
    {
        symbol = default!;
        if (!line.EndsWith(";") || line.Contains("(") || line.StartsWith("typedef ", StringComparison.Ordinal))
        {
            return false;
        }

        if (line.StartsWith("return ", StringComparison.Ordinal) || line.StartsWith("case ", StringComparison.Ordinal) || line.StartsWith("break;", StringComparison.Ordinal))
        {
            return false;
        }

        var match = Regex.Match(line, @"^([A-Za-z_][A-Za-z0-9_<>\*\s:&]+?)\s+([A-Za-z_][A-Za-z0-9_]*)\s*(\[[^\]]+\])?\s*;");
        if (!match.Success)
        {
            return false;
        }

        var dataType = match.Groups[1].Value.Trim();
        var name = match.Groups[2].Value;
        var shape = dataType.Contains('*') || dataType.Contains('&') || dataType.Contains("ptr", StringComparison.OrdinalIgnoreCase) ? "pointer_or_reference" : "scalar_or_unknown";
        symbol = CreateSymbol(file, "field", name, name, lineNo, lineNo, "", dataType, shape, line, lineNo);
        return true;
    }

    private static IEnumerable<SourceSymbol> Deduplicate(IEnumerable<SourceSymbol> symbols)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        foreach (var symbol in symbols)
        {
            var key = $"{symbol.File}|{symbol.Kind}|{symbol.QualifiedName}|{symbol.StartLine}|{symbol.EndLine}|{symbol.Signature}";
            if (seen.Add(key))
            {
                yield return symbol;
            }
        }
    }

    private static string StripComments(string line, ref int blockCommentDepth)
    {
        var output = new List<char>(line.Length);
        var inSingle = false;
        var inDouble = false;
        for (var i = 0; i < line.Length; i++)
        {
            var ch = line[i];
            var next = i + 1 < line.Length ? line[i + 1] : '\0';

            if (blockCommentDepth > 0)
            {
                if (ch == '*' && next == '/')
                {
                    blockCommentDepth--;
                    i++;
                }
                continue;
            }

            if (!inDouble && ch == '\'' && (i == 0 || line[i - 1] != '\\'))
            {
                inSingle = !inSingle;
                output.Add(ch);
                continue;
            }

            if (!inSingle && ch == '"' && (i == 0 || line[i - 1] != '\\'))
            {
                inDouble = !inDouble;
                output.Add(ch);
                continue;
            }

            if (!inSingle && !inDouble && ch == '/' && next == '/')
            {
                break;
            }

            if (!inSingle && !inDouble && ch == '/' && next == '*')
            {
                blockCommentDepth++;
                i++;
                continue;
            }

            if (!inSingle && !inDouble && ch == '#')
            {
                break;
            }

            output.Add(ch);
        }

        return new string(output.ToArray());
    }

    private static bool IsCommentOnly(string line)
        => line.StartsWith("/*", StringComparison.Ordinal) || line.StartsWith("*", StringComparison.Ordinal) || line.StartsWith("//", StringComparison.Ordinal);

    private sealed record ScopeFrame(string Name, string Kind, int StartLine, string Signature)
    {
        public string QualifiedName => Name;
    }

    private sealed record TypeIntro(string File, string Kind, string Name, string QualifiedName, int LineNo, int EndLine, bool OpensScope, string Signature)
    {
        public SourceSymbol Symbol => new(
            LineNo,
            Signature,
            File,
            Kind,
            Name,
            QualifiedName,
            LineNo,
            EndLine,
            "",
            "",
            "",
            Signature);

        public IReadOnlyList<SourceSymbol> Symbols => new[]
        {
            Symbol
        };
    }

    private static SourceSymbol CreateSymbol(
        string file,
        string kind,
        string name,
        string qualifiedName,
        int startLine,
        int endLine,
        string parent,
        string dataType,
        string dataShape,
        string signature,
        int sourceLineNo)
    {
        var originalRow = string.Join(" | ", new[]
        {
            file,
            kind,
            name,
            qualifiedName,
            startLine.ToString(),
            endLine.ToString(),
            parent,
            dataType,
            dataShape,
            signature
        });

        return new SourceSymbol(
            sourceLineNo,
            originalRow,
            file,
            kind,
            name,
            qualifiedName,
            startLine,
            endLine,
            parent,
            dataType,
            dataShape,
            signature);
    }

    private static bool IsStatementComplete(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        var trimmed = text.Trim();
        if (trimmed.EndsWith("{", StringComparison.Ordinal) || trimmed.EndsWith("}", StringComparison.Ordinal) || trimmed.EndsWith(";", StringComparison.Ordinal))
        {
            return true;
        }

        return trimmed.Contains('{') || trimmed.Contains('}') || trimmed.Contains(';');
    }

    private static string CompactStatement(string text)
        => string.Join(" ", text.Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

    private static string ExtractFunctionReturnType(string line, string functionName)
    {
        var openParen = line.IndexOf('(');
        if (openParen < 0)
        {
            return string.Empty;
        }

        var prefix = line[..openParen].Trim();
        var nameIndex = prefix.LastIndexOf(functionName, StringComparison.Ordinal);
        if (nameIndex < 0)
        {
            return string.Empty;
        }

        var beforeName = prefix[..nameIndex].Trim();
        if (string.IsNullOrWhiteSpace(beforeName))
        {
            return string.Empty;
        }

        var tokens = beforeName.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(token => token is not "static" and not "inline" and not "extern" and not "GLOBAL" and not "__inline" and not "const" and not "volatile")
            .ToArray();
        return string.Join(" ", tokens).Trim();
    }

    private static bool LooksLikeFunctionDeclarationPrefix(string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix))
        {
            return false;
        }

        var keywords = new[]
        {
            "void", "char", "short", "int", "long", "float", "double", "bool", "size_t", "ssize_t",
            "static", "extern", "inline", "GLOBAL", "const", "volatile", "unsigned", "signed", "struct",
            "union", "enum", "*", "&", "::"
        };

        return keywords.Any(prefix.Contains);
    }

    private static int FindScopeEndLine(string[] lines, int startIndex, int currentIndex)
    {
        var depth = 0;
        var seenOpen = false;
        var blockCommentDepth = 0;
        for (var i = startIndex; i < lines.Length; i++)
        {
            var line = StripComments(lines[i], ref blockCommentDepth);
            foreach (var ch in line)
            {
                if (ch == '{')
                {
                    depth++;
                    seenOpen = true;
                }
                else if (ch == '}' && seenOpen)
                {
                    depth--;
                    if (depth <= 0)
                    {
                        return i + 1;
                    }
                }
            }
        }

        return currentIndex + 1;
    }
}
