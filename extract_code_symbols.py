from __future__ import annotations

from dataclasses import dataclass
from pathlib import Path
from typing import Optional
import sys

from tree_sitter import Parser
from tree_sitter_language_pack import get_language


LANGUAGE_BY_EXTENSION = {
    ".c": "c",
    ".h": "c",
    ".cpp": "cpp",
    ".cc": "cpp",
    ".cxx": "cpp",
    ".hpp": "cpp",
    ".hh": "cpp",
    ".hxx": "cpp",
    ".py": "python",
    ".java": "java",
    ".cs": "c_sharp",
}

SYMBOL_NODE_TYPES = {
    "c": {
        "function_definition": "function",
        "struct_specifier": "struct",
        "union_specifier": "union",
        "enum_specifier": "enum",
        "type_definition": "typedef",
        "field_declaration": "field",
        "enumerator": "enum_value",
    },
    "cpp": {
        "function_definition": "function",
        "class_specifier": "class",
        "struct_specifier": "struct",
        "union_specifier": "union",
        "enum_specifier": "enum",
        "namespace_definition": "namespace",
        "field_declaration": "field",
        "enumerator": "enum_value",
    },
    "python": {
        "class_definition": "class",
        "function_definition": "function",
        "assignment": "field",
        "typed_parameter": "parameter",
    },
    "java": {
        "class_declaration": "class",
        "interface_declaration": "interface",
        "enum_declaration": "enum",
        "method_declaration": "method",
        "constructor_declaration": "constructor",
        "field_declaration": "field",
        "constant_declaration": "field",
        "enum_constant": "enum_value",
    },
    "c_sharp": {
        "class_declaration": "class",
        "struct_declaration": "struct",
        "interface_declaration": "interface",
        "enum_declaration": "enum",
        "method_declaration": "method",
        "constructor_declaration": "constructor",
        "field_declaration": "field",
        "property_declaration": "property",
        "enum_member_declaration": "enum_value",
    },
}

IDENTIFIER_NODE_TYPES = {
    "identifier",
    "type_identifier",
    "field_identifier",
    "property_identifier",
}

ARRAYISH_MARKERS = (
    "[]",
    "array",
    "list",
    "vector",
    "set",
    "map",
    "dict",
    "dictionary",
    "tuple",
    "queue",
    "stack",
)


@dataclass
class Symbol:
    file: str
    kind: str
    name: str
    qualified_name: str
    parent: str
    start_line: int
    end_line: int
    signature: str
    data_type: str = ""
    data_shape: str = ""


def get_lang_name(path: Path) -> Optional[str]:
    return LANGUAGE_BY_EXTENSION.get(path.suffix.lower())


def get_parser(lang_name: str) -> Parser:
    parser = Parser()
    parser.language = get_language(lang_name)
    return parser


def node_text(node, source: bytes) -> str:
    return source[node.start_byte:node.end_byte].decode("utf-8", errors="replace")


def compact_whitespace(text: str) -> str:
    return " ".join(text.replace("\r", " ").replace("\n", " ").replace("\t", " ").split())


def walk(node):
    stack = [node]
    while stack:
        cur = stack.pop()
        yield cur
        stack.extend(reversed(cur.children))


def find_first_child(node, types: set[str]):
    for child in node.children:
        if child.type in types:
            return child
    return None


def find_identifier_deep(node):
    stack = [node]
    while stack:
        cur = stack.pop()
        if cur.type in IDENTIFIER_NODE_TYPES:
            return cur
        stack.extend(reversed(cur.children))
    return None


def find_all_identifiers_deep(node):
    found = []
    stack = [node]
    while stack:
        cur = stack.pop()
        if cur.type in IDENTIFIER_NODE_TYPES:
            found.append(cur)
        stack.extend(reversed(cur.children))
    return found


def find_children(node, types: set[str]):
    return [child for child in node.children if child.type in types]


def is_inside(node, ancestor_types: set[str]) -> bool:
    cur = getattr(node, "parent", None)
    while cur is not None:
        if cur.type in ancestor_types:
            return True
        cur = getattr(cur, "parent", None)
    return False


def extract_c_function_name(node, source: bytes) -> str:
    declarator = find_first_child(node, {"function_declarator", "pointer_declarator"})
    if declarator is None:
        for child in node.children:
            if "declarator" in child.type:
                declarator = child
                break

    if declarator is None:
        ident = find_identifier_deep(node)
        return node_text(ident, source).strip() if ident else "<anonymous>"

    ident = find_identifier_deep(declarator)
    return node_text(ident, source).strip() if ident else "<anonymous>"


def extract_name(lang_name: str, node, source: bytes) -> str:
    if lang_name in {"c", "cpp"}:
        if node.type == "function_definition":
            return extract_c_function_name(node, source)

        if node.type in {"struct_specifier", "union_specifier", "enum_specifier", "class_specifier"}:
            ident = find_first_child(node, {"type_identifier", "identifier"})
            return node_text(ident, source).strip() if ident else "<anonymous>"

        if node.type == "type_definition":
            ids = find_all_identifiers_deep(node)
            if ids:
                return node_text(ids[-1], source).strip()
            return "<anonymous>"

        if node.type == "namespace_definition":
            ident = find_first_child(node, {"identifier", "namespace_identifier"})
            return node_text(ident, source).strip() if ident else "<anonymous>"

        if node.type == "field_declaration":
            declarator = find_first_child(node, {"field_identifier", "identifier"})
            if declarator is not None:
                return node_text(declarator, source).strip()
            ident = find_identifier_deep(node)
            return node_text(ident, source).strip() if ident else "<anonymous>"

        if node.type == "enumerator":
            ident = find_first_child(node, {"identifier"})
            return node_text(ident, source).strip() if ident else "<anonymous>"

    if lang_name == "python":
        if node.type == "assignment":
            left = find_first_child(node, {"identifier", "attribute"})
            if left is not None:
                return compact_whitespace(node_text(left, source))
        ident = find_first_child(node, {"identifier"})
        return node_text(ident, source).strip() if ident else "<anonymous>"

    if lang_name in {"java", "c_sharp"}:
        if node.type in {"field_declaration", "constant_declaration"}:
            declarator = find_first_child(node, {"variable_declarator"})
            if declarator is not None:
                ident = find_identifier_deep(declarator)
                return node_text(ident, source).strip() if ident else "<anonymous>"
        if node.type == "property_declaration":
            ident = find_first_child(node, {"identifier"})
            return node_text(ident, source).strip() if ident else "<anonymous>"
        if node.type in {"enum_constant", "enum_member_declaration"}:
            ident = find_first_child(node, {"identifier"})
            return node_text(ident, source).strip() if ident else "<anonymous>"
        ident = find_first_child(node, {"identifier"})
        return node_text(ident, source).strip() if ident else "<anonymous>"

    ident = find_identifier_deep(node)
    return node_text(ident, source).strip() if ident else "<anonymous>"


def classify_data_shape(data_type: str, signature: str) -> str:
    text = f"{data_type} {signature}".strip().lower()
    if not text:
        return ""
    if any(marker in text for marker in ("[]", "array", "vector", "list<", "list[", "ilist", "ienumerable", "queue<", "stack<", "set<")):
        return "array_or_collection"
    if any(marker in text for marker in ("dict", "dictionary", "map<", "unordered_map", "hashmap", "sortedmap")):
        return "map_or_dictionary"
    if any(marker in text for marker in ("tuple", "pair<", "std::pair", "namedtuple")):
        return "tuple_or_pair"
    if "*" in data_type or "pointer" in text:
        return "pointer_or_reference"
    if any(tok in text for tok in ("struct", "class", "record", "object", "dataclass")):
        return "structured_object"
    return "scalar_or_unknown"


def extract_python_assignment_type(node, source: bytes) -> tuple[str, str]:
    text = compact_whitespace(node_text(node, source))
    data_type = ""
    if ":" in text and "=" in text and text.index(":") < text.index("="):
        data_type = compact_whitespace(text.split(":", 1)[1].split("=", 1)[0])
    elif ":" in text and "=" not in text:
        data_type = compact_whitespace(text.split(":", 1)[1])

    lower = text.lower()
    if not data_type:
        if lower.endswith("= []") or "= list(" in lower:
            data_type = "list"
        elif lower.endswith("= {}") or "= dict(" in lower:
            data_type = "dict"
        elif lower.endswith("= set()"):
            data_type = "set"
        elif lower.endswith("= ()") or "= tuple(" in lower:
            data_type = "tuple"

    return data_type, classify_data_shape(data_type, text)


def extract_field_type(lang_name: str, node, source: bytes) -> tuple[str, str]:
    text = compact_whitespace(node_text(node, source))

    if lang_name in {"c", "cpp"} and node.type == "field_declaration":
        type_part = ""
        for child in node.children:
            if child.type in {"primitive_type", "type_identifier", "sized_type_specifier", "struct_specifier", "union_specifier", "enum_specifier", "template_type", "qualified_identifier"}:
                piece = compact_whitespace(node_text(child, source))
                if piece:
                    type_part = f"{type_part} {piece}".strip()
            elif "declarator" in child.type:
                break
        if not type_part:
            type_part = text.rsplit(" ", 1)[0] if " " in text else ""
        return type_part, classify_data_shape(type_part, text)

    if lang_name == "python" and node.type == "assignment":
        return extract_python_assignment_type(node, source)

    if lang_name in {"java", "c_sharp"} and node.type in {"field_declaration", "constant_declaration", "property_declaration"}:
        type_node = None
        for child in node.children:
            if child.type in {"type", "generic_type", "array_type", "integral_type", "floating_point_type", "boolean_type", "void_type", "predefined_type", "nullable_type", "identifier", "scoped_type_identifier"}:
                type_node = child
                break
        data_type = compact_whitespace(node_text(type_node, source)) if type_node is not None else ""
        if not data_type and " " in text:
            data_type = text.split(" ", 1)[0]
        return data_type, classify_data_shape(data_type, text)

    return "", ""


def extract_signature(lang_name: str, node, source: bytes) -> str:
    text = compact_whitespace(node_text(node, source))

    if lang_name in {"c", "cpp"} and node.type == "function_definition":
        body = find_first_child(node, {"compound_statement"})
        if body is not None:
            sig_text = source[node.start_byte:body.start_byte].decode("utf-8", errors="replace")
            return compact_whitespace(sig_text)
        return text[:300]

    if lang_name == "python" and node.type == "function_definition":
        body = find_first_child(node, {"block"})
        if body is not None:
            sig_text = source[node.start_byte:body.start_byte].decode("utf-8", errors="replace")
            return compact_whitespace(sig_text)
        return text[:300]

    if lang_name == "python" and node.type == "class_definition":
        body = find_first_child(node, {"block"})
        if body is not None:
            sig_text = source[node.start_byte:body.start_byte].decode("utf-8", errors="replace")
            return compact_whitespace(sig_text)
        return text[:300]

    return text[:300]


def is_scope_container(lang_name: str, node_type: str) -> bool:
    containers = {
        "c": {"struct_specifier", "union_specifier", "enum_specifier"},
        "cpp": {"class_specifier", "struct_specifier", "union_specifier", "enum_specifier", "namespace_definition"},
        "python": {"class_definition", "function_definition"},
        "java": {"class_declaration", "interface_declaration", "enum_declaration", "method_declaration"},
        "c_sharp": {"class_declaration", "struct_declaration", "interface_declaration", "enum_declaration", "method_declaration"},
    }
    return node_type in containers.get(lang_name, set())


def should_emit_symbol(lang_name: str, node, symbol_kind: str) -> bool:
    if symbol_kind == "field":
        if lang_name == "python":
            return is_inside(node, {"class_definition"})
        if lang_name in {"c", "cpp"}:
            return is_inside(node, {"struct_specifier", "class_specifier", "union_specifier"})
        if lang_name in {"java", "c_sharp"}:
            return is_inside(node, {"class_declaration", "struct_declaration", "interface_declaration", "enum_declaration"})
    if symbol_kind == "property":
        return is_inside(node, {"class_declaration", "struct_declaration", "interface_declaration"})
    if symbol_kind == "parameter":
        return False
    return True


def scan_node(lang_name: str, node, source: bytes, file_path: str, scope_stack: list[str], out: list[Symbol]):
    kind_map = SYMBOL_NODE_TYPES.get(lang_name, {})
    symbol_kind = kind_map.get(node.type)

    pushed = False

    if symbol_kind and should_emit_symbol(lang_name, node, symbol_kind):
        name = extract_name(lang_name, node, source)
        parent = "::".join(scope_stack)
        qualified_name = "::".join(scope_stack + [name]) if scope_stack else name
        signature = extract_signature(lang_name, node, source)
        data_type = ""
        data_shape = ""

        if symbol_kind in {"field", "property"}:
            data_type, data_shape = extract_field_type(lang_name, node, source)

        out.append(
            Symbol(
                file=file_path,
                kind=symbol_kind,
                name=name,
                qualified_name=qualified_name,
                parent=parent,
                start_line=node.start_point[0] + 1,
                end_line=node.end_point[0] + 1,
                signature=signature,
                data_type=data_type,
                data_shape=data_shape,
            )
        )

    if is_scope_container(lang_name, node.type):
        scope_name = extract_name(lang_name, node, source)
        if scope_name != "<anonymous>":
            scope_stack.append(scope_name)
            pushed = True

    for child in node.children:
        scan_node(lang_name, child, source, file_path, scope_stack, out)

    if pushed:
        scope_stack.pop()


def extract_symbols_from_file(path: Path) -> list[Symbol]:
    lang_name = get_lang_name(path)
    if not lang_name:
        return []

    try:
        source = path.read_bytes()
    except Exception:
        return []

    parser = get_parser(lang_name)

    try:
        tree = parser.parse(source)
    except Exception:
        return []

    out: list[Symbol] = []
    scan_node(lang_name, tree.root_node, source, str(path), [], out)
    return out


def should_scan(path: Path) -> bool:
    return path.suffix.lower() in LANGUAGE_BY_EXTENSION


def main() -> int:
    if len(sys.argv) < 2:
        print("Usage: py extract_code_symbols_rich.py <source_folder> [output_file]")
        return 1

    root = Path(sys.argv[1]).resolve()
    if not root.is_dir():
        print(f"Folder not found: {root}")
        return 1

    output_file = Path(sys.argv[2]).resolve() if len(sys.argv) >= 3 else Path("symbols_rich.txt").resolve()

    symbols: list[Symbol] = []
    for path in root.rglob("*"):
        if path.is_file() and should_scan(path):
            symbols.extend(extract_symbols_from_file(path))

    symbols.sort(key=lambda s: (s.file.lower(), s.start_line, s.kind.lower(), s.qualified_name.lower()))

    with output_file.open("w", encoding="utf-8", newline="\n") as f:
        f.write("file | kind | name | qualified_name | start_line | end_line | parent | data_type | data_shape | signature\n")
        f.write("-" * 220 + "\n")
        for s in symbols:
            f.write(
                f"{s.file} | {s.kind} | {s.name} | {s.qualified_name} | "
                f"{s.start_line} | {s.end_line} | {s.parent} | {s.data_type} | {s.data_shape} | {s.signature}\n"
            )

    print(f"Wrote {len(symbols)} symbols to {output_file}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
