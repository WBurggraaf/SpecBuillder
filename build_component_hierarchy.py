from __future__ import annotations

import json
import re
import sys
import time
from collections import defaultdict
from datetime import datetime, timezone
from pathlib import Path
from typing import Any

import requests

OLLAMA_URL = "http://localhost:11434/api/chat"
DEFAULT_MODEL = "qwen3.5:2b"
REQUEST_TIMEOUT_SECONDS = 180
DEFAULT_MAX_SUBCOMPONENTS = 5
MAX_ITEMS_PER_COMPONENT_PROMPT = 160


FUNCTIONAL_COMPONENTS = {
    "Presentation / UI",
    "Business Logic / Application Services",
    "Domain Models",
    "Controller / API / Interface",
}

TECHNICAL_COMPONENTS = {
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
}


def read_json(path: Path) -> dict[str, Any]:
    return json.loads(path.read_text(encoding="utf-8"))


def write_json(path: Path, data: Any) -> None:
    path.write_text(json.dumps(data, indent=2, ensure_ascii=False), encoding="utf-8")


def normalize_whitespace(text: str) -> str:
    return re.sub(r"\s+", " ", str(text or "")).strip()


def trim_words(text: str, max_words: int = 50) -> str:
    words = normalize_whitespace(text).split()
    if len(words) <= max_words:
        return " ".join(words)
    return " ".join(words[:max_words])


def infer_category_from_component(component_name: str) -> str:
    if component_name in FUNCTIONAL_COMPONENTS:
        return "functional"
    if component_name in TECHNICAL_COMPONENTS:
        return "technical"
    return "mixed"


def load_assignments(input_json: dict[str, Any]) -> list[dict[str, Any]]:
    rows = input_json.get("assignments", [])
    if not isinstance(rows, list):
        raise ValueError("Input JSON must contain an 'assignments' list.")

    normalized: list[dict[str, Any]] = []
    for row in rows:
        if not isinstance(row, dict):
            continue

        component_name = normalize_whitespace(
            row.get("component_name") or row.get("component") or "Unclassified"
        ) or "Unclassified"

        qualified_name = normalize_whitespace(
            row.get("qualified_name") or row.get("name") or "<unknown>"
        ) or "<unknown>"

        line_description = normalize_whitespace(
            row.get("line_description") or row.get("description") or "No description available."
        ) or "No description available."

        normalized.append({
            "source_line_no": row.get("source_line_no"),
            "original_row": row.get("original_row", ""),
            "file": row.get("file", ""),
            "kind": row.get("kind", ""),
            "name": row.get("name", ""),
            "qualified_name": qualified_name,
            "start_line": row.get("start_line"),
            "end_line": row.get("end_line"),
            "parent": row.get("parent", ""),
            "data_type": normalize_whitespace(row.get("data_type", "")),
            "data_shape": normalize_whitespace(row.get("data_shape", "")),
            "signature": row.get("signature", ""),
            "component_name": component_name,
            "category": row.get("category") or infer_category_from_component(component_name),
            "line_description": line_description,
            "reasoning_summary": row.get("reasoning_summary", ""),
        })

    return normalized


def deduplicate_symbols(items: list[dict[str, Any]]) -> list[dict[str, Any]]:
    seen = set()
    deduped = []
    for item in items:
        key = (
            item.get("component_name", ""),
            item.get("qualified_name", ""),
            item.get("file", ""),
            item.get("start_line"),
            item.get("end_line"),
            item.get("kind", ""),
            item.get("data_type", ""),
            item.get("data_shape", ""),
        )
        if key in seen:
            continue
        seen.add(key)
        deduped.append(item)
    return deduped


def group_by_component(assignments: list[dict[str, Any]]) -> dict[str, list[dict[str, Any]]]:
    grouped: dict[str, list[dict[str, Any]]] = defaultdict(list)
    for row in assignments:
        grouped[row["component_name"]].append(row)
    return dict(sorted(grouped.items(), key=lambda kv: kv[0].lower()))


def build_component_prompt(component_name: str, items: list[dict[str, Any]], max_subcomponents: int) -> str:
    trimmed = items[:MAX_ITEMS_PER_COMPONENT_PROMPT]

    symbol_lines = []
    for item in trimmed:
        qn = item.get("qualified_name") or item.get("name") or "<unknown>"
        desc = item.get("line_description") or ""
        kind = item.get("kind") or ""
        data_type = normalize_whitespace(item.get("data_type", ""))
        data_shape = normalize_whitespace(item.get("data_shape", ""))
        file_name = Path(item.get("file", "")).name if item.get("file") else ""
        signature = normalize_whitespace(item.get("signature", ""))

        extras = []
        if kind:
            extras.append(f"kind={kind}")
        if data_type:
            extras.append(f"type={data_type}")
        if data_shape:
            extras.append(f"shape={data_shape}")
        extra_text = " ".join(extras)

        if signature:
            symbol_lines.append(f"- {qn} ({file_name}) {extra_text} sig={signature} :: {desc}".strip())
        else:
            symbol_lines.append(f"- {qn} ({file_name}) {extra_text} :: {desc}".strip())

    symbols_block = "\n".join(symbol_lines)

    return f"""
You are analyzing one software architecture component based on low-level code symbols.

Component:
{component_name}

Goal:
- Review all provided symbols in this component.
- Identify the main subcomponents inside this component.
- Group the symbols into those subcomponents.
- Describe each subcomponent.
- For every assigned symbol, explain how it fits that subcomponent in 50 words or less.
- Produce a short overview of the full component.
- Use kind, data type, and data shape when they help distinguish structures, fields, mappers, serializers, processors, collections, and other responsibilities.

Return EXACTLY this plain-text format:

OVERVIEW: <one short paragraph about the whole component>

SUBCOMPONENT: <name> | <short description>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>

SUBCOMPONENT: <name> | <short description>
MEMBER: <qualified_name> | <why this symbol belongs here, max 50 words>

Rules:
- Do not use markdown.
- Do not return JSON.
- Use only the supplied symbols and descriptions.
- Keep subcomponent names broad but meaningful.
- Use qualified names exactly as given.
- Put each symbol in at most one subcomponent.
- Prefer between 2 and {max_subcomponents} subcomponents.
- If the component is small, return at least 1 subcomponent.
- Each MEMBER explanation must be 50 words or fewer.
- Focus on responsibility clusters, not filenames.

Symbols:
{symbols_block}
""".strip()


def call_ollama(model: str, prompt: str) -> str:
    payload = {
        "model": model,
        "stream": False,
        "think": False,
        "messages": [
            {
                "role": "system",
                "content": "You summarize software architecture components. Follow the requested plain-text format exactly."
            },
            {
                "role": "user",
                "content": prompt
            }
        ],
        "options": {
            "temperature": 0.1,
            "top_p": 0.9,
            "num_predict": 1400,
        }
    }

    response = requests.post(
        OLLAMA_URL,
        json=payload,
        timeout=REQUEST_TIMEOUT_SECONDS,
    )
    response.raise_for_status()
    data = response.json()

    message = data.get("message", {})
    if isinstance(message, dict):
        content = message.get("content")
        if isinstance(content, str) and content.strip():
            return content.strip()

    fallback = data.get("response", "")
    if isinstance(fallback, str) and fallback.strip():
        return fallback.strip()

    raise RuntimeError("Ollama returned no usable content.")


def parse_grouping_response(text: str) -> tuple[str, list[dict[str, Any]]]:
    overview = ""
    groups: list[dict[str, Any]] = []

    overview_match = re.search(r"(?ims)^\s*OVERVIEW\s*:\s*(.+?)(?=^\s*SUBCOMPONENT\s*:|\Z)", text)
    if overview_match:
        overview = normalize_whitespace(overview_match.group(1))

    lines = text.splitlines()
    current_group: dict[str, Any] | None = None

    for raw_line in lines:
        line = raw_line.strip()
        if not line:
            continue

        sub_match = re.match(r"(?i)^SUBCOMPONENT\s*:\s*(.+?)\s*\|\s*(.+)$", line)
        if sub_match:
            if current_group:
                groups.append(current_group)
            current_group = {
                "name": normalize_whitespace(sub_match.group(1)),
                "description": normalize_whitespace(sub_match.group(2)),
                "members": [],
            }
            continue

        mem_match = re.match(r"(?i)^MEMBER\s*:\s*(.+?)\s*\|\s*(.+)$", line)
        if mem_match and current_group is not None:
            current_group["members"].append({
                "qualified_name": normalize_whitespace(mem_match.group(1)),
                "fit_description": trim_words(mem_match.group(2), 50),
            })

    if current_group:
        groups.append(current_group)

    return overview, groups


def fallback_grouping(component_name: str, items: list[dict[str, Any]]) -> tuple[str, list[dict[str, Any]]]:
    overview = f"This component contains symbols related to {component_name.lower()} responsibilities."
    members = []
    for item in items[: min(12, len(items))]:
        qn = item.get("qualified_name", "")
        if qn:
            members.append({
                "qualified_name": qn,
                "fit_description": trim_words(
                    f"This symbol supports the general responsibilities inside {component_name} based on its role, type metadata, and description.",
                    50,
                ),
            })

    return overview, [{
        "name": "General Responsibilities",
        "description": f"General responsibilities grouped under {component_name}.",
        "members": members,
    }]


def build_nested_component(component_name: str, items: list[dict[str, Any]], model: str, max_subcomponents: int) -> dict[str, Any]:
    items = deduplicate_symbols(items)
    raw_response = call_ollama(model, build_component_prompt(component_name, items, max_subcomponents))

    overview, groups = parse_grouping_response(raw_response)
    if not overview or not groups:
        overview, groups = fallback_grouping(component_name, items)

    item_lookup: dict[str, list[dict[str, Any]]] = defaultdict(list)
    for item in items:
        key = normalize_whitespace(item.get("qualified_name") or item.get("name") or "")
        if key:
            item_lookup[key].append(item)

    used_keys: set[tuple[Any, ...]] = set()
    subcomponents = []

    for group in groups:
        grouped_symbols = []

        for member in group["members"]:
            member_name = member["qualified_name"]
            fit_description = trim_words(member["fit_description"], 50)

            for item in item_lookup.get(member_name, []):
                item_key = (
                    item.get("qualified_name", ""),
                    item.get("file", ""),
                    item.get("start_line"),
                    item.get("end_line"),
                    item.get("kind", ""),
                    item.get("data_type", ""),
                    item.get("data_shape", ""),
                )
                if item_key in used_keys:
                    continue
                used_keys.add(item_key)
                grouped_symbols.append({
                    "source_line_no": item.get("source_line_no"),
                    "file": item.get("file", ""),
                    "kind": item.get("kind", ""),
                    "name": item.get("name", ""),
                    "qualified_name": item.get("qualified_name", ""),
                    "start_line": item.get("start_line"),
                    "end_line": item.get("end_line"),
                    "parent": item.get("parent", ""),
                    "data_type": item.get("data_type", ""),
                    "data_shape": item.get("data_shape", ""),
                    "signature": item.get("signature", ""),
                    "description": item.get("line_description", ""),
                    "reasoning_summary": item.get("reasoning_summary", ""),
                    "membership_description": fit_description,
                    "original_row": item.get("original_row", ""),
                })

        if grouped_symbols:
            subcomponents.append({
                "subcomponent_name": group["name"],
                "subcomponent_description": group["description"],
                "symbol_count": len(grouped_symbols),
                "symbols": sorted(
                    grouped_symbols,
                    key=lambda x: (
                        str(x.get("qualified_name", "")).lower(),
                        str(x.get("file", "")).lower(),
                        x.get("start_line") or 0,
                    ),
                ),
            })

    leftovers = []
    for item in items:
        item_key = (
            item.get("qualified_name", ""),
            item.get("file", ""),
            item.get("start_line"),
            item.get("end_line"),
            item.get("kind", ""),
            item.get("data_type", ""),
            item.get("data_shape", ""),
        )
        if item_key in used_keys:
            continue
        leftovers.append({
            "source_line_no": item.get("source_line_no"),
            "file": item.get("file", ""),
            "kind": item.get("kind", ""),
            "name": item.get("name", ""),
            "qualified_name": item.get("qualified_name", ""),
            "start_line": item.get("start_line"),
            "end_line": item.get("end_line"),
            "parent": item.get("parent", ""),
            "data_type": item.get("data_type", ""),
            "data_shape": item.get("data_shape", ""),
            "signature": item.get("signature", ""),
            "description": item.get("line_description", ""),
            "reasoning_summary": item.get("reasoning_summary", ""),
            "membership_description": trim_words(
                f"This symbol supports other responsibilities within {component_name} but was not clearly assigned to a main subcomponent.",
                50,
            ),
            "original_row": item.get("original_row", ""),
        })

    if leftovers:
        subcomponents.append({
            "subcomponent_name": "Other Supporting Responsibilities",
            "subcomponent_description": f"Additional symbols within {component_name} not captured in the main subcomponents.",
            "symbol_count": len(leftovers),
            "symbols": sorted(
                leftovers,
                key=lambda x: (
                    str(x.get("qualified_name", "")).lower(),
                    str(x.get("file", "")).lower(),
                    x.get("start_line") or 0,
                ),
            ),
        })

    return {
        "component_name": component_name,
        "category": infer_category_from_component(component_name),
        "component_overview": overview,
        "symbol_count": len(items),
        "subcomponent_count": len(subcomponents),
        "subcomponents": subcomponents,
    }


def build_nested_output(input_payload: dict[str, Any], assignments: list[dict[str, Any]], model: str, max_subcomponents: int) -> dict[str, Any]:
    grouped = group_by_component(assignments)

    components = []
    for component_name, items in grouped.items():
        print(f"[component] {component_name} ({len(items)} symbols)", flush=True)
        components.append(build_nested_component(component_name, items, model, max_subcomponents))
        time.sleep(0.2)

    return {
        "generated_at_utc": datetime.now(timezone.utc).isoformat(),
        "source_model": input_payload.get("model", ""),
        "summary_model": model,
        "source_project_introduction_file": input_payload.get("project_introduction_file", ""),
        "source_assignment_count": len(assignments),
        "component_count": len(components),
        "components": components,
    }


def main() -> int:
    if len(sys.argv) < 2:
        print(
            "Usage: py build_component_hierarchy_nested.py <component_assignments.json> "
            "[output.json] [model] [max_subcomponents]"
        )
        return 1

    input_path = Path(sys.argv[1]).resolve()
    output_path = Path(sys.argv[2]).resolve() if len(sys.argv) >= 3 else Path("component_hierarchy_nested.json").resolve()
    model = sys.argv[3] if len(sys.argv) >= 4 else DEFAULT_MODEL
    max_subcomponents = int(sys.argv[4]) if len(sys.argv) >= 5 else DEFAULT_MAX_SUBCOMPONENTS

    if not input_path.is_file():
        print(f"Input file not found: {input_path}")
        return 1

    input_payload = read_json(input_path)
    assignments = load_assignments(input_payload)

    if not assignments:
        print("No assignments found in input JSON.")
        return 1

    print(f"[info] loaded assignments: {len(assignments)}", flush=True)
    print("[info] creating nested component hierarchy...", flush=True)

    result = build_nested_output(
        input_payload=input_payload,
        assignments=assignments,
        model=model,
        max_subcomponents=max_subcomponents,
    )

    write_json(output_path, result)
    print(f"[ok] wrote: {output_path}", flush=True)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
