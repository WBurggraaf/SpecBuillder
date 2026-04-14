from __future__ import annotations

import json
import re
import sys
import time
from dataclasses import dataclass
from pathlib import Path
from typing import Any

import requests

OLLAMA_URL = "http://localhost:11434/api/chat"
DEFAULT_MODEL = "qwen3.5:2b"
REQUEST_TIMEOUT_SECONDS = 180
MAX_CONTEXT_CHARS = 6000
MAX_DESCRIPTION_WORDS = 60
SLEEP_BETWEEN_OLLAMA_CALLS = 0.05
CALLABLE_KINDS = {"function", "method", "constructor"}
SKIP_DIR_NAMES = {
    ".git",
    ".idea",
    ".vs",
    ".vscode",
    "build",
    "dist",
    "out",
    "bin",
    "obj",
    "node_modules",
    "run_artifacts",
    "__pycache__",
}
SOURCE_EXTENSIONS = {
    ".c", ".h", ".cpp", ".cc", ".cxx", ".hpp", ".hh", ".hxx",
    ".py", ".java", ".cs",
}


@dataclass
class FlatSymbol:
    component_name: str
    subcomponent_name: str
    symbol_ref: dict[str, Any]


@dataclass
class SymbolIndexEntry:
    file: str
    kind: str
    name: str
    qualified_name: str
    start_line: int
    end_line: int
    parent: str
    data_type: str
    data_shape: str
    signature: str


@dataclass
class SourceFile:
    path: Path
    normalized_path: str
    text: str
    lines: list[str]


@dataclass
class CallSite:
    line_no: int
    call_line: str
    snippet: str
    caller_symbol: SymbolIndexEntry | None


@dataclass
class TargetSymbol:
    qualified_name: str
    name: str
    kind: str
    file: str
    start_line: int
    end_line: int
    node: dict[str, Any]


def read_text(path: Path) -> str:
    return path.read_text(encoding="utf-8", errors="replace")


def read_json(path: Path) -> dict[str, Any]:
    return json.loads(read_text(path))


def write_json(path: Path, data: Any) -> None:
    path.write_text(json.dumps(data, indent=2, ensure_ascii=False), encoding="utf-8")


def normalize_whitespace(text: str) -> str:
    return re.sub(r"\s+", " ", str(text or "")).strip()


def normalize_path(path: str) -> str:
    return str(path).replace("\\", "/").lower().strip()


def trim_words(text: str, max_words: int = MAX_DESCRIPTION_WORDS) -> str:
    words = normalize_whitespace(text).split()
    if len(words) <= max_words:
        return " ".join(words)
    return " ".join(words[:max_words])


def parse_symbol_rows(symbol_text: str) -> list[SymbolIndexEntry]:
    rows: list[SymbolIndexEntry] = []
    for line in symbol_text.splitlines():
        raw = line.strip()
        if not raw:
            continue
        if raw.startswith("file | "):
            continue
        if set(raw) == {"-"}:
            continue

        parts = [p.strip() for p in raw.split(" | ")]
        if len(parts) < 8:
            continue

        try:
            file = parts[0]
            kind = parts[1]
            name = parts[2]
            qualified_name = parts[3]
            start_line = int(parts[4])
            end_line = int(parts[5])
            parent = parts[6]
            if len(parts) >= 10:
                data_type = parts[7]
                data_shape = parts[8]
                signature = " | ".join(parts[9:]).strip()
            else:
                data_type = ""
                data_shape = ""
                signature = " | ".join(parts[7:]).strip()
            rows.append(SymbolIndexEntry(
                file=file,
                kind=kind,
                name=name,
                qualified_name=qualified_name,
                start_line=start_line,
                end_line=end_line,
                parent=parent,
                data_type=data_type,
                data_shape=data_shape,
                signature=signature,
            ))
        except Exception:
            continue
    return rows


def flatten_hierarchy(hierarchy: dict[str, Any]) -> list[FlatSymbol]:
    flat: list[FlatSymbol] = []
    for component in hierarchy.get("components", []):
        component_name = component.get("component_name", "")
        for subcomponent in component.get("subcomponents", []):
            sub_name = subcomponent.get("subcomponent_name", "")
            for symbol in subcomponent.get("symbols", []):
                flat.append(FlatSymbol(
                    component_name=component_name,
                    subcomponent_name=sub_name,
                    symbol_ref=symbol,
                ))
    return flat


def index_hierarchy_symbols(hierarchy: dict[str, Any]) -> tuple[list[TargetSymbol], dict[tuple[str, str, int, int], FlatSymbol]]:
    targets: list[TargetSymbol] = []
    by_key: dict[tuple[str, str, int, int], FlatSymbol] = {}

    for flat in flatten_hierarchy(hierarchy):
        symbol = flat.symbol_ref
        key = (
            normalize_path(symbol.get("file", "")),
            str(symbol.get("qualified_name", "")).strip(),
            int(symbol.get("start_line") or 0),
            int(symbol.get("end_line") or 0),
        )
        by_key[key] = flat

        if str(symbol.get("kind", "")) not in CALLABLE_KINDS:
            continue

        targets.append(TargetSymbol(
            qualified_name=str(symbol.get("qualified_name", "")).strip(),
            name=str(symbol.get("name", "")).strip(),
            kind=str(symbol.get("kind", "")).strip(),
            file=str(symbol.get("file", "")).strip(),
            start_line=int(symbol.get("start_line") or 0),
            end_line=int(symbol.get("end_line") or 0),
            node=symbol,
        ))

    return targets, by_key


def build_component_lookup_from_hierarchy(hierarchy: dict[str, Any]) -> dict[tuple[str, str, int, int], tuple[str, str]]:
    lookup: dict[tuple[str, str, int, int], tuple[str, str]] = {}
    for flat in flatten_hierarchy(hierarchy):
        symbol = flat.symbol_ref
        key = (
            normalize_path(symbol.get("file", "")),
            str(symbol.get("qualified_name", "")).strip(),
            int(symbol.get("start_line") or 0),
            int(symbol.get("end_line") or 0),
        )
        lookup[key] = (flat.component_name, flat.subcomponent_name)
    return lookup


def build_symbols_by_file(symbol_rows: list[SymbolIndexEntry]) -> dict[str, list[SymbolIndexEntry]]:
    grouped: dict[str, list[SymbolIndexEntry]] = {}
    for row in symbol_rows:
        key = normalize_path(row.file)
        grouped.setdefault(key, []).append(row)

    for key, items in grouped.items():
        items.sort(key=lambda x: (x.start_line, -(x.end_line - x.start_line), x.qualified_name.lower()))
    return grouped


def collect_source_files(root: Path) -> dict[str, SourceFile]:
    files: dict[str, SourceFile] = {}
    for path in root.rglob("*"):
        if not path.is_file():
            continue
        if path.suffix.lower() not in SOURCE_EXTENSIONS:
            continue
        if any(part.lower() in SKIP_DIR_NAMES for part in path.parts):
            continue
        try:
            text = path.read_text(encoding="utf-8", errors="replace")
        except Exception:
            continue
        norm = normalize_path(str(path))
        files[norm] = SourceFile(path=path, normalized_path=norm, text=text, lines=text.splitlines())
    return files


def map_symbol_file_to_source_path(symbol_file: str, source_files: dict[str, SourceFile]) -> SourceFile | None:
    norm_symbol = normalize_path(symbol_file)
    if norm_symbol in source_files:
        return source_files[norm_symbol]

    suffix = "/".join(norm_symbol.split("/")[-6:])
    candidates = [sf for sf in source_files.values() if sf.normalized_path.endswith(suffix)]
    if len(candidates) == 1:
        return candidates[0]

    basename = Path(symbol_file).name.lower()
    candidates = [sf for sf in source_files.values() if sf.path.name.lower() == basename]
    if len(candidates) == 1:
        return candidates[0]

    return None


def resolve_enclosing_symbol(symbols_in_file: list[SymbolIndexEntry], line_no: int, target_name: str, target_start: int, target_end: int) -> SymbolIndexEntry | None:
    best: SymbolIndexEntry | None = None
    best_span: tuple[int, int] | None = None

    for sym in symbols_in_file:
        if sym.kind not in CALLABLE_KINDS:
            continue
        if not (sym.start_line <= line_no <= sym.end_line):
            continue
        if sym.name == target_name and sym.start_line == target_start and sym.end_line == target_end:
            continue
        span = (sym.end_line - sym.start_line, -sym.start_line)
        if best is None or span < best_span:
            best = sym
            best_span = span
    return best


def get_context_snippet(lines: list[str], call_line_no: int, caller: SymbolIndexEntry | None) -> str:
    if caller is not None:
        start = max(1, caller.start_line)
        end = min(len(lines), caller.end_line)
        if end >= start and (end - start) <= 120:
            block = lines[start - 1:end]
            text = "\n".join(block)
            if len(text) <= MAX_CONTEXT_CHARS:
                return text

    start = max(1, call_line_no - 8)
    end = min(len(lines), call_line_no + 8)
    return "\n".join(lines[start - 1:end])[:MAX_CONTEXT_CHARS]


def strip_comments_preserve_strings(line: str) -> str:
    result = []
    i = 0
    in_single = False
    in_double = False
    while i < len(line):
        ch = line[i]
        nxt = line[i + 1] if i + 1 < len(line) else ""
        if not in_double and ch == "'" and (i == 0 or line[i - 1] != "\\"):
            in_single = not in_single
            result.append(ch)
            i += 1
            continue
        if not in_single and ch == '"' and (i == 0 or line[i - 1] != "\\"):
            in_double = not in_double
            result.append(ch)
            i += 1
            continue
        if not in_single and not in_double:
            if ch == "/" and nxt == "/":
                break
            if ch == "#":
                break
        result.append(ch)
        i += 1
    return "".join(result)


def find_call_sites_in_file(source: SourceFile, target: TargetSymbol, symbols_in_file: list[SymbolIndexEntry]) -> list[CallSite]:
    short_name = target.name.strip()
    if not short_name or short_name in {"<anonymous>", "main"}:
        # allow main? too noisy, better skip.
        return []

    pattern = re.compile(rf"(?<![A-Za-z0-9_]){re.escape(short_name)}\s*\(")
    results: list[CallSite] = []

    for idx, raw_line in enumerate(source.lines, start=1):
        clean_line = strip_comments_preserve_strings(raw_line)
        if short_name not in clean_line:
            continue
        if not pattern.search(clean_line):
            continue
        if idx == target.start_line and source.normalized_path == normalize_path(target.file):
            continue

        caller = resolve_enclosing_symbol(symbols_in_file, idx, target.name, target.start_line, target.end_line)
        if caller is not None and caller.qualified_name == target.qualified_name and normalize_path(caller.file) == normalize_path(target.file):
            continue

        results.append(CallSite(
            line_no=idx,
            call_line=raw_line.strip(),
            snippet=get_context_snippet(source.lines, idx, caller),
            caller_symbol=caller,
        ))

    return results


def dedupe_callers(calls: list[dict[str, Any]]) -> list[dict[str, Any]]:
    seen: set[tuple[Any, ...]] = set()
    deduped: list[dict[str, Any]] = []
    for call in calls:
        key = (
            call.get("caller_qualified_name", ""),
            call.get("caller_file", ""),
            call.get("line_no", 0),
            call.get("call_line", ""),
        )
        if key in seen:
            continue
        seen.add(key)
        deduped.append(call)
    return deduped


def call_ollama_why(model: str, target: TargetSymbol, caller_name: str, caller_component: str, caller_subcomponent: str, snippet: str, call_line: str) -> str:
    prompt = f"""
You explain why one code symbol calls another.

Target symbol:
- qualified_name: {target.qualified_name}
- kind: {target.kind}
- file: {target.file}
- signature: {target.node.get('signature', '')}
- description: {target.node.get('description', '')}

Caller:
- qualified_name: {caller_name}
- component: {caller_component}
- subcomponent: {caller_subcomponent}

Call line:
{call_line}

Relevant code:
{snippet}

Task:
Write one concise explanation of why the caller invokes the target here.
Rules:
- Max {MAX_DESCRIPTION_WORDS} words.
- Be concrete and code-grounded.
- Mention the likely purpose in the flow.
- Do not mention uncertainty unless necessary.
- Return only the explanation sentence.
""".strip()

    payload = {
        "model": model,
        "stream": False,
        "think": False,
        "messages": [
            {"role": "system", "content": "You explain code call relationships briefly and concretely."},
            {"role": "user", "content": prompt},
        ],
        "options": {
            "temperature": 0.1,
            "top_p": 0.9,
            "num_predict": 120,
        },
    }

    try:
        response = requests.post(OLLAMA_URL, json=payload, timeout=REQUEST_TIMEOUT_SECONDS)
        response.raise_for_status()
        data = response.json()
        message = data.get("message", {})
        if isinstance(message, dict):
            content = message.get("content")
            if isinstance(content, str) and content.strip():
                return trim_words(content.strip(), MAX_DESCRIPTION_WORDS)
        fallback = data.get("response", "")
        if isinstance(fallback, str) and fallback.strip():
            return trim_words(fallback.strip(), MAX_DESCRIPTION_WORDS)
    except Exception:
        pass

    return trim_words(
        f"{caller_name} invokes {target.qualified_name} at this point to support its surrounding control flow and complete the required operation shown in the local code.",
        MAX_DESCRIPTION_WORDS,
    )


def enrich_targets(
    hierarchy: dict[str, Any],
    symbol_rows: list[SymbolIndexEntry],
    source_root: Path,
    model: str,
) -> dict[str, Any]:
    targets, hierarchy_lookup = index_hierarchy_symbols(hierarchy)
    component_lookup = build_component_lookup_from_hierarchy(hierarchy)
    symbols_by_file = build_symbols_by_file(symbol_rows)
    source_files = collect_source_files(source_root)

    mapped_targets = 0
    enriched_targets = 0

    for target in targets:
        target_norm_file = normalize_path(target.file)
        source_file = map_symbol_file_to_source_path(target.file, source_files)
        if source_file is None:
            target.node["caller_count"] = 0
            target.node["caller_components"] = []
            target.node["callers"] = []
            target.node["caller_resolution_status"] = "source_file_not_found"
            continue

        mapped_targets += 1
        symbols_in_file = symbols_by_file.get(source_file.normalized_path) or symbols_by_file.get(target_norm_file) or []
        call_sites = find_call_sites_in_file(source_file, target, symbols_in_file)

        caller_entries: list[dict[str, Any]] = []
        for site in call_sites:
            caller = site.caller_symbol
            caller_qn = caller.qualified_name if caller is not None else "<unknown caller>"
            caller_file = caller.file if caller is not None else str(source_file.path)
            caller_kind = caller.kind if caller is not None else "unknown"
            caller_start = caller.start_line if caller is not None else None
            caller_end = caller.end_line if caller is not None else None

            comp_key = (
                normalize_path(caller.file),
                caller.qualified_name,
                caller.start_line,
                caller.end_line,
            ) if caller is not None else None

            if comp_key and comp_key in component_lookup:
                caller_component, caller_subcomponent = component_lookup[comp_key]
            else:
                caller_component, caller_subcomponent = ("Unknown", "Unknown")

            why_called = call_ollama_why(
                model=model,
                target=target,
                caller_name=caller_qn,
                caller_component=caller_component,
                caller_subcomponent=caller_subcomponent,
                snippet=site.snippet,
                call_line=site.call_line,
            )
            time.sleep(SLEEP_BETWEEN_OLLAMA_CALLS)

            caller_entries.append({
                "caller_component_name": caller_component,
                "caller_subcomponent_name": caller_subcomponent,
                "caller_qualified_name": caller_qn,
                "caller_kind": caller_kind,
                "caller_file": caller_file,
                "caller_start_line": caller_start,
                "caller_end_line": caller_end,
                "line_no": site.line_no,
                "call_line": site.call_line,
                "why_called": why_called,
                "code_context": site.snippet,
            })

        caller_entries = dedupe_callers(caller_entries)
        caller_components = sorted({x["caller_component_name"] for x in caller_entries if x.get("caller_component_name")})

        target.node["caller_count"] = len(caller_entries)
        target.node["caller_components"] = caller_components
        target.node["callers"] = caller_entries
        target.node["caller_resolution_status"] = "ok"
        target.node["caller_resolution_strategy"] = "symbols.txt range index + hierarchy component lookup"
        if caller_entries:
            enriched_targets += 1

    hierarchy["caller_enrichment"] = {
        "enabled": True,
        "strategy": "Resolved enclosing callers from symbols.txt ranges, then mapped caller components via component_hierarchy.json.",
        "source_root": str(source_root),
        "target_callable_symbol_count": len(targets),
        "mapped_target_source_files": mapped_targets,
        "targets_with_callers": enriched_targets,
        "summary_model": model,
    }
    return hierarchy


def main() -> int:
    if len(sys.argv) < 4:
        print(
            "Usage: py enrich_component_hierarchy_with_callers_v2.py <component_hierarchy.json> <symbols.txt> <source_root> "
            "[output.json] [model]"
        )
        return 1

    hierarchy_path = Path(sys.argv[1]).resolve()
    symbols_path = Path(sys.argv[2]).resolve()
    source_root = Path(sys.argv[3]).resolve()
    output_path = Path(sys.argv[4]).resolve() if len(sys.argv) >= 5 else Path("component_hierarchy_with_callers.json").resolve()
    model = sys.argv[5] if len(sys.argv) >= 6 else DEFAULT_MODEL

    if not hierarchy_path.is_file():
        print(f"Hierarchy JSON not found: {hierarchy_path}")
        return 1
    if not symbols_path.is_file():
        print(f"Symbols file not found: {symbols_path}")
        return 1
    if not source_root.is_dir():
        print(f"Source root not found: {source_root}")
        return 1

    hierarchy = read_json(hierarchy_path)
    symbol_rows = parse_symbol_rows(read_text(symbols_path))
    if not symbol_rows:
        print("No symbol rows parsed from symbols.txt")
        return 1

    result = enrich_targets(
        hierarchy=hierarchy,
        symbol_rows=symbol_rows,
        source_root=source_root,
        model=model,
    )
    write_json(output_path, result)
    print(f"[ok] wrote: {output_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
