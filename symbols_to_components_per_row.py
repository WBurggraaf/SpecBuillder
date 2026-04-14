from __future__ import annotations

import json
import re
import sys
import time
from collections import defaultdict
from pathlib import Path
from typing import Any

import requests


OLLAMA_URL = "http://localhost:11434/api/chat"
DEFAULT_MODEL = "qwen3.5:2b"
MAX_RETRIES_PER_ROW = 4
REQUEST_TIMEOUT_SECONDS = 180

RUN_DIR = Path("run_artifacts")
RUN_DIR.mkdir(exist_ok=True)

VERBOSE = True
PREVIEW_LEN = 220
NUM_PREDICT = 160

ALLOWED_COMPONENTS = [
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
    "Unclassified",
]

ALLOWED_COMPONENT_SET = set(ALLOWED_COMPONENTS)


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


COMPONENT_ALIASES = {
    "presentation": "Presentation / UI",
    "ui": "Presentation / UI",
    "presentation / ui": "Presentation / UI",
    "controller": "Controller / API / Interface",
    "api": "Controller / API / Interface",
    "interface": "Controller / API / Interface",
    "controller / api / interface": "Controller / API / Interface",
    "business logic": "Business Logic / Application Services",
    "application services": "Business Logic / Application Services",
    "business logic / application services": "Business Logic / Application Services",
    "domain model": "Domain Models",
    "domain models": "Domain Models",
    "state": "State Management",
    "state management": "State Management",
    "data access": "Data Access / Database",
    "database": "Data Access / Database",
    "data access / database": "Data Access / Database",
    "network": "Network / Communication / Protocol",
    "communication": "Network / Communication / Protocol",
    "protocol": "Network / Communication / Protocol",
    "network / communication / protocol": "Network / Communication / Protocol",
    "infrastructure": "Infrastructure / Platform",
    "platform": "Infrastructure / Platform",
    "infrastructure / platform": "Infrastructure / Platform",
    "config": "Configuration",
    "configuration": "Configuration",
    "security": "Security / Authentication / Authorization",
    "authentication": "Security / Authentication / Authorization",
    "authorization": "Security / Authentication / Authorization",
    "security / authentication / authorization": "Security / Authentication / Authorization",
    "logging": "Logging / Monitoring",
    "monitoring": "Logging / Monitoring",
    "logging / monitoring": "Logging / Monitoring",
    "utilities": "Utilities / Shared",
    "shared": "Utilities / Shared",
    "utilities / shared": "Utilities / Shared",
    "integration": "Integration / External Systems",
    "external systems": "Integration / External Systems",
    "connector": "Integration / External Systems",
    "connectors": "Integration / External Systems",
    "adapter": "Integration / External Systems",
    "adapters": "Integration / External Systems",
    "gateway": "Integration / External Systems",
    "client": "Integration / External Systems",
    "integration / external systems": "Integration / External Systems",
    "mapping": "Mapping / Translation",
    "mapper": "Mapping / Translation",
    "mappers": "Mapping / Translation",
    "translation": "Mapping / Translation",
    "translator": "Mapping / Translation",
    "normalization": "Mapping / Translation",
    "normalizer": "Mapping / Translation",
    "mapping / translation": "Mapping / Translation",
    "transformation": "Transformation / Processing",
    "transform": "Transformation / Processing",
    "transformer": "Transformation / Processing",
    "processing": "Transformation / Processing",
    "processor": "Transformation / Processing",
    "pipeline": "Transformation / Processing",
    "enrichment": "Transformation / Processing",
    "sanitization": "Transformation / Processing",
    "transformation / processing": "Transformation / Processing",
    "serialization": "Serialization / Deserialization",
    "deserialization": "Serialization / Deserialization",
    "serializer": "Serialization / Deserialization",
    "deserializer": "Serialization / Deserialization",
    "marshal": "Serialization / Deserialization",
    "unmarshal": "Serialization / Deserialization",
    "encoding": "Serialization / Deserialization",
    "decoding": "Serialization / Deserialization",
    "codec": "Serialization / Deserialization",
    "serialization / deserialization": "Serialization / Deserialization",
    "compression": "Compression / Archiving",
    "compress": "Compression / Archiving",
    "compressor": "Compression / Archiving",
    "decompression": "Compression / Archiving",
    "decompress": "Compression / Archiving",
    "archive": "Compression / Archiving",
    "archiving": "Compression / Archiving",
    "zip": "Compression / Archiving",
    "gzip": "Compression / Archiving",
    "compression / archiving": "Compression / Archiving",
    "scheduling": "Scheduling / Jobs / Workers",
    "jobs": "Scheduling / Jobs / Workers",
    "workers": "Scheduling / Jobs / Workers",
    "scheduling / jobs / workers": "Scheduling / Jobs / Workers",
    "unclassified": "Unclassified",
}


def log(msg: str) -> None:
    print(msg, flush=True)


def step(msg: str) -> None:
    print(msg, flush=True)


def preview_text(text: str, limit: int = PREVIEW_LEN) -> str:
    text = text.replace("\r", "\\r").replace("\n", "\\n")
    if len(text) <= limit:
        return text
    return text[:limit] + "...<truncated>"


def save_text(name: str, content: str) -> Path:
    path = RUN_DIR / name
    path.write_text(content, encoding="utf-8")
    return path


def save_json(name: str, data: Any) -> Path:
    path = RUN_DIR / name
    path.write_text(json.dumps(data, indent=2, ensure_ascii=False), encoding="utf-8")
    return path


def read_text(path: Path) -> str:
    return path.read_text(encoding="utf-8", errors="replace")


def parse_symbol_rows(symbol_text: str) -> list[dict[str, Any]]:
    rows: list[dict[str, Any]] = []

    for line_no, line in enumerate(symbol_text.splitlines(), start=1):
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

        if len(parts) >= 10:
            file = parts[0]
            kind = parts[1]
            name = parts[2]
            qualified_name = parts[3]
            start_line_text = parts[4]
            end_line_text = parts[5]
            parent = parts[6]
            data_type = parts[7]
            data_shape = parts[8]
            signature = " | ".join(parts[9:]).strip()
        else:
            file = parts[0]
            kind = parts[1]
            name = parts[2]
            qualified_name = parts[3]
            start_line_text = parts[4]
            end_line_text = parts[5]
            parent = parts[6]
            data_type = ""
            data_shape = ""
            signature = " | ".join(parts[7:]).strip()

        try:
            row = {
                "source_line_no": line_no,
                "file": file,
                "kind": kind,
                "name": name,
                "qualified_name": qualified_name,
                "start_line": int(start_line_text),
                "end_line": int(end_line_text),
                "parent": parent,
                "data_type": data_type,
                "data_shape": data_shape,
                "signature": signature,
                "raw": raw,
            }
            rows.append(row)
        except ValueError:
            continue

    return rows


def build_system_prompt(project_introduction: str) -> str:
    allowed = "\n".join(f"- {x}" for x in ALLOWED_COMPONENTS)

    return f"""
You are a senior software architect classifying code symbols into standard software architecture components.

Project or application context:
{project_introduction.strip()}

Task:
- Classify one symbol row at a time.
- Assign it to exactly one allowed component.
- Provide one short description of what the symbol likely does.
- Do not return JSON.
- Return exactly these two lines and nothing else:
COMPONENT: <one allowed component name>
DESCRIPTION: <short description>

Allowed component names:
{allowed}

Technical-first priority:
1. Infrastructure / Platform
2. Network / Communication / Protocol
3. Data Access / Database
4. Serialization / Deserialization
5. Compression / Archiving
6. Mapping / Translation
7. Transformation / Processing
8. Configuration
9. Security / Authentication / Authorization
10. Logging / Monitoring
11. Utilities / Shared
12. Integration / External Systems
13. Scheduling / Jobs / Workers
14. State Management
15. Controller / API / Interface
16. Business Logic / Application Services
17. Domain Models
18. Presentation / UI
19. Unclassified

Generic classification guidance:
- transport, messaging, sockets, protocols, endpoints, connection handling -> Network / Communication / Protocol
- config loading, options, environment, initialization settings -> Configuration
- auth, access control, identity, secrets, certificates, encryption -> Security / Authentication / Authorization
- diagnostics, telemetry, metrics, logs, tracing, error reporting -> Logging / Monitoring
- shared helpers, support functions, reusable generic code -> Utilities / Shared
- persistence, repositories, storage, queries, records tied to persistence -> Data Access / Database
- mapping between schemas, DTOs, models, field conversion, canonicalization, translation -> Mapping / Translation
- transformation pipelines, reshaping, filtering, enrichment, parsing, content conversion, processing stages -> Transformation / Processing
- serializers, deserializers, codecs, marshaling, unmarshaling, encoding, decoding, wire/object conversion -> Serialization / Deserialization
- compression, decompression, archive packaging, zip or gzip handling -> Compression / Archiving
- domain entities, business data structures, enums, typedefs, core concepts -> Domain Models
- lifecycle, status tracking, session/runtime coordination, state transitions -> State Management
- handlers, commands, interfaces, request/response boundaries -> Controller / API / Interface
- orchestration, workflows, use cases, business rules, application behavior -> Business Logic / Application Services
- low-level runtime, platform abstractions, process/system support -> Infrastructure / Platform
- front-end, views, screens, widgets, user interaction -> Presentation / UI
- external connectors, third-party APIs, import/export bridges, system adapters at boundaries -> Integration / External Systems
- background jobs, timers, workers, schedulers -> Scheduling / Jobs / Workers

Important rules:
- Never invent a new component name.
- Never return a function name, struct name, symbol name, or file name as the component name.
- Prefer the most specific allowed architecture bucket that matches the symbol responsibility.
- Review the symbol from multiple angles: responsibility, naming, structure, and likely dependency role.
- When ambiguous, choose the more technical and more specific bucket first.
- The description should be one short sentence.
- Return exactly two lines in the required format.
""".strip()


def build_user_prompt(row: dict[str, Any]) -> str:
    return f"""
Classify this one symbol row.

Symbol row:
{row["raw"]}

Parsed fields:
- file: {row["file"]}
- kind: {row["kind"]}
- name: {row["name"]}
- qualified_name: {row["qualified_name"]}
- start_line: {row["start_line"]}
- end_line: {row["end_line"]}
- parent: {row["parent"]}
- data_type: {row.get("data_type", "")}
- data_shape: {row.get("data_shape", "")}
- data_type: {row.get("data_type", "")}
- data_shape: {row.get("data_shape", "")}
- signature: {row["signature"]}

Interpretation hints for richer symbol rows:
- Fields, properties, and enum values often describe data structures, storage shape, and object boundaries.
- data_type captures the declared type when available.
- data_shape captures structural hints like array_or_collection, map_or_dictionary, tuple_or_pair, pointer_or_reference, structured_object, or scalar_or_unknown.
- Use these richer fields when deciding between Domain Models, Data Access / Database, Mapping / Translation, Serialization / Deserialization, Transformation / Processing, Utilities / Shared, and similar technical buckets.

Return exactly:
COMPONENT: <one allowed component name>
DESCRIPTION: <short description>
""".strip()


def build_repair_user_prompt(row: dict[str, Any], previous_response: str, error_message: str) -> str:
    return f"""
Your previous response was invalid.

Validation error:
{error_message}

Previous response:
{previous_response}

Re-classify this one symbol row.

Return exactly these two lines and nothing else:
COMPONENT: <one allowed component name>
DESCRIPTION: <short description>

Rules reminder:
- Use exactly one allowed component name.
- Prefer technical classification before functional classification.
- Do not return JSON.
- Do not add explanations, bullets, or markdown.

Symbol row:
{row["raw"]}

Parsed fields:
- file: {row["file"]}
- kind: {row["kind"]}
- name: {row["name"]}
- qualified_name: {row["qualified_name"]}
- start_line: {row["start_line"]}
- end_line: {row["end_line"]}
- parent: {row["parent"]}
- data_type: {row.get("data_type", "")}
- data_shape: {row.get("data_shape", "")}
- signature: {row["signature"]}
""".strip()


def strip_code_fences(text: str) -> str:
    original = text
    cleaned = text.strip()

    if cleaned.startswith("```"):
        cleaned = re.sub(r"^```[a-zA-Z0-9_-]*\s*", "", cleaned)
        cleaned = re.sub(r"\s*```$", "", cleaned)

    if VERBOSE and cleaned != original.strip():
        step("[parse] removed markdown code fences")

    return cleaned.strip()


def normalize_component_name(value: str) -> str:
    text = value.strip()
    if not text:
        raise ValueError("Missing component")

    if text in ALLOWED_COMPONENT_SET:
        return text

    if text.lower() in COMPONENT_ALIASES:
        return COMPONENT_ALIASES[text.lower()]

    compact = re.sub(r"[^a-z0-9]+", "", text.lower())
    for item in ALLOWED_COMPONENTS:
        if compact == re.sub(r"[^a-z0-9]+", "", item.lower()):
            return item

    raise ValueError(f"Unrecognized component name: {value}")


def parse_text_result(raw_text: str) -> tuple[str, str]:
    cleaned = strip_code_fences(raw_text)
    if not cleaned:
        raise ValueError("Empty response after cleaning")

    component = ""
    description = ""

    for line in cleaned.splitlines():
        s = line.strip()
        if not s:
            continue
        if s.lower().startswith("component:"):
            component = s.split(":", 1)[1].strip()
        elif s.lower().startswith("description:"):
            description = s.split(":", 1)[1].strip()

    if not component or not description:
        lines = [ln.strip() for ln in cleaned.splitlines() if ln.strip()]
        if not component and len(lines) >= 1 and ":" not in lines[0]:
            component = lines[0]
        if not description and len(lines) >= 2 and ":" not in lines[1]:
            description = lines[1]

    component = normalize_component_name(component)

    if not description:
        raise ValueError("Missing description")

    return component, description


def infer_category(component_name: str) -> str:
    if component_name == "Unclassified":
        return "mixed"
    if component_name in TECHNICAL_COMPONENTS:
        return "technical"
    return "functional"


def extract_content_from_chat_response(api_data: dict[str, Any]) -> tuple[str, str, str, str]:
    thinking_preview = ""
    done_reason = ""

    if isinstance(api_data, dict):
        done_reason = str(api_data.get("done_reason") or "")

    message = api_data.get("message")
    if isinstance(message, dict):
        thinking = message.get("thinking")
        if isinstance(thinking, str) and thinking.strip():
            thinking_preview = thinking

        content = message.get("content")
        if isinstance(content, str) and content.strip():
            return content, "message.content", thinking_preview, done_reason

    response = api_data.get("response")
    if isinstance(response, str) and response.strip():
        return response, "response", thinking_preview, done_reason

    return "", "none", thinking_preview, done_reason


def call_ollama_row(
    model: str,
    system_prompt: str,
    user_prompt: str,
    row_index: int,
    attempt: int,
) -> str:
    payload = {
        "model": model,
        "stream": False,
        "think": False,
        "messages": [
            {"role": "system", "content": system_prompt},
            {"role": "user", "content": user_prompt},
        ],
        "options": {
            "temperature": 0.0,
            "top_p": 0.8,
            "num_predict": NUM_PREDICT,
        }
    }

    save_json(f"row_{row_index:04d}_attempt_{attempt}_request.json", payload)

    step(f"[http] POST {OLLAMA_URL}")
    step(f"[http] model={model}")

    response = requests.post(
        OLLAMA_URL,
        json=payload,
        timeout=REQUEST_TIMEOUT_SECONDS,
    )
    response.raise_for_status()

    api_data = response.json()
    save_json(f"row_{row_index:04d}_attempt_{attempt}_api_response.json", api_data)

    raw_content, source_field, thinking_preview, done_reason = extract_content_from_chat_response(api_data)

    step(f"[http] response field used: {source_field}")
    step(f"[http] content chars: {len(raw_content)}")
    step(f"[http] content preview: {preview_text(raw_content)}")

    if thinking_preview:
        step(f"[http] thinking preview: {preview_text(thinking_preview)}")

    if done_reason:
        step(f"[http] done_reason={done_reason}")
    if isinstance(api_data, dict):
        if "eval_count" in api_data:
            step(f"[http] eval_count={api_data.get('eval_count')}")
        if "prompt_eval_count" in api_data:
            step(f"[http] prompt_eval_count={api_data.get('prompt_eval_count')}")

    if not raw_content.strip() and thinking_preview and done_reason == "length":
        raise RuntimeError(
            "Model exhausted token budget in thinking before producing content. "
            "Retry with think=False or a higher num_predict."
        )

    return raw_content


def classify_row_with_retry(
    row: dict[str, Any],
    model: str,
    system_prompt: str,
    row_index: int,
    total_rows: int,
) -> dict[str, Any]:
    user_prompt = build_user_prompt(row)
    last_raw = ""
    last_error = ""

    for attempt in range(1, MAX_RETRIES_PER_ROW + 1):
        step("")
        step("=" * 100)
        step(
            f"[row {row_index}/{total_rows}] "
            f"name={row['name']} kind={row['kind']} file={row['file']} "
            f"(attempt {attempt}/{MAX_RETRIES_PER_ROW})"
        )
        step(f"[row] original: {row['raw']}")

        prompt_file = save_text(
            f"row_{row_index:04d}_attempt_{attempt}_user_prompt.txt",
            user_prompt,
        )
        step(f"[save] {prompt_file}")

        try:
            raw = call_ollama_row(
                model=model,
                system_prompt=system_prompt,
                user_prompt=user_prompt,
                row_index=row_index,
                attempt=attempt,
            )
        except Exception as exc:
            last_error = str(exc)
            step(f"[retry] {last_error}")
            user_prompt = build_repair_user_prompt(row, "", last_error)
            time.sleep(0.5)
            continue

        last_raw = raw

        response_file = save_text(
            f"row_{row_index:04d}_attempt_{attempt}_response.txt",
            raw,
        )
        step(f"[save] {response_file}")

        if not raw or not raw.strip():
            last_error = "Empty content returned by Ollama."
            step(f"[retry] {last_error}")
            user_prompt = build_repair_user_prompt(row, raw, last_error)
            time.sleep(0.5)
            continue

        try:
            step("[parse] attempting component/description extraction")
            component_name, line_description = parse_text_result(raw)
            step("[parse] extraction successful")
        except ValueError as exc:
            last_error = str(exc)
            step(f"[retry] {last_error}")
            step(f"[retry] raw preview: {preview_text(raw)}")
            user_prompt = build_repair_user_prompt(row, raw, last_error)
            time.sleep(0.5)
            continue

        category = infer_category(component_name)
        reasoning_summary = (
            f"Assigned to {component_name} based on the symbol name, type metadata, signature, and likely responsibility."
        )

        step("[validate] success")
        step(f"[result] component={component_name} category={category}")
        step(f"[result] line_description={line_description}")
        step(f"[result] reasoning_summary={reasoning_summary}")

        result = {
            "source_line_no": row["source_line_no"],
            "original_row": row["raw"],
            "file": row["file"],
            "kind": row["kind"],
            "name": row["name"],
            "qualified_name": row["qualified_name"],
            "start_line": row["start_line"],
            "end_line": row["end_line"],
            "parent": row["parent"],
            "data_type": row.get("data_type", ""),
            "data_shape": row.get("data_shape", ""),
            "signature": row["signature"],
            "component_name": component_name,
            "category": category,
            "line_description": line_description.strip(),
            "reasoning_summary": reasoning_summary.strip(),
        }
        return result

    raise RuntimeError(
        f"Failed to classify row after retries.\n"
        f"Row: {row['raw']}\n"
        f"Last error: {last_error}\n"
        f"Last response:\n{last_raw}"
    )


def render_markdown(assignments: list[dict[str, Any]]) -> str:
    grouped: dict[str, list[dict[str, Any]]] = defaultdict(list)
    categories: dict[str, str] = {}

    for item in assignments:
        grouped[item["component_name"]].append(item)
        categories[item["component_name"]] = item["category"]

    lines: list[str] = []
    lines.append("# Component List")
    lines.append("")
    lines.append("Generated from per-row symbol classification.")
    lines.append("")

    ordered_components = [c for c in ALLOWED_COMPONENTS if c in grouped]

    for component_name in ordered_components:
        items = grouped[component_name]
        category = categories.get(component_name, "mixed")

        lines.append(f"## Component: {component_name}")
        lines.append(f"- Category: {category}")
        lines.append(f"- Assigned symbols: {len(items)}")
        lines.append("")

        lines.append("### Symbols")
        lines.append("| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |")
        lines.append("|---|---|---|---|---|---|---:|---:|---|")

        items_sorted = sorted(
            items,
            key=lambda x: (x["file"].lower(), x["start_line"], x["name"].lower())
        )

        for item in items_sorted:
            file_name = item["file"].replace("|", "\\|")
            kind = item["kind"].replace("|", "\\|")
            name = item["name"].replace("|", "\\|")
            qualified_name = item["qualified_name"].replace("|", "\\|")
            line_description = item["line_description"].replace("|", "\\|").replace("\n", " ").strip()

            lines.append(
                f"| {file_name} | {kind} | {name} | {qualified_name} | "
                f"{item['start_line']} | {item['end_line']} | {line_description} |"
            )

        lines.append("")
        lines.append("### Original Rows")
        lines.append("```text")
        for item in items_sorted:
            lines.append(item["original_row"])
        lines.append("```")
        lines.append("")

    return "\n".join(lines)


def main() -> int:
    if len(sys.argv) < 3:
        print(
            "Usage: py symbols_to_components_per_row_simple_text.py <symbols_rich.txt> <introduction.txt> "
            "[output.md] [output.json] [model]"
        )
        return 1

    symbols_file = Path(sys.argv[1]).resolve()
    introduction_file = Path(sys.argv[2]).resolve()
    output_md = Path(sys.argv[3]).resolve() if len(sys.argv) >= 4 else Path("component_list.md").resolve()
    output_json = Path(sys.argv[4]).resolve() if len(sys.argv) >= 5 else Path("component_assignments.json").resolve()
    model = sys.argv[5] if len(sys.argv) >= 6 else DEFAULT_MODEL

    if not symbols_file.is_file():
        print(f"Symbols file not found: {symbols_file}")
        return 1

    if not introduction_file.is_file():
        print(f"Introduction file not found: {introduction_file}")
        return 1

    symbol_text = read_text(symbols_file)
    project_introduction = read_text(introduction_file).strip()

    if not project_introduction:
        print("Introduction file is empty.")
        return 1

    rows = parse_symbol_rows(symbol_text)
    if not rows:
        print("No valid symbol rows found in the input file.")
        return 1

    log(f"[info] parsed rows: {len(rows)}")
    save_text("symbols_input.txt", symbol_text)
    save_text("project_introduction.txt", project_introduction)

    system_prompt = build_system_prompt(project_introduction)
    save_text("system_prompt.txt", system_prompt)

    assignments: list[dict[str, Any]] = []
    total_rows = len(rows)
    component_counts: dict[str, int] = defaultdict(int)

    for index, row in enumerate(rows, start=1):
        result = classify_row_with_retry(
            row=row,
            model=model,
            system_prompt=system_prompt,
            row_index=index,
            total_rows=total_rows,
        )
        assignments.append(result)
        component_counts[result["component_name"]] += 1

        step(
            f"[progress] completed {index}/{total_rows} | "
            f"latest={result['component_name']} | "
            f"assigned_so_far={component_counts[result['component_name']]}"
        )

        if index % 25 == 0 or index == total_rows:
            step("[progress] component distribution so far:")
            for component_name in ALLOWED_COMPONENTS:
                count = component_counts.get(component_name, 0)
                if count > 0:
                    step(f"  - {component_name}: {count}")

    output_payload = {
        "model": model,
        "project_introduction_file": str(introduction_file),
        "allowed_components": ALLOWED_COMPONENTS,
        "assignments": assignments,
    }

    output_json.write_text(
        json.dumps(output_payload, indent=2, ensure_ascii=False),
        encoding="utf-8",
    )

    markdown = render_markdown(assignments)
    output_md.write_text(markdown, encoding="utf-8")

    summary = {
        "model": model,
        "row_count": len(rows),
        "output_markdown": str(output_md),
        "output_json": str(output_json),
    }
    save_json("run_summary.json", summary)

    log(f"[ok] markdown: {output_md}")
    log(f"[ok] json: {output_json}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
