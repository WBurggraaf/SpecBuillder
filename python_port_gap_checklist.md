# Python Port Gap Checklist

This checklist maps the current C# rewrite against the original Python scripts.

## `extract_code_symbols.py`

Implemented:
- Supported source discovery across C, C++, Python, Java, and C# files.
- Basic symbol emission into normalized records.
- Deduplication of emitted symbols.
- Scope-aware naming for simple C/C++ member fields.

Partially implemented:
- C/C++ symbol extraction is heuristic-based rather than tree-sitter-based.
- Basic line-based parsing exists for functions, structs, enums, typedef aliases, and fields.

Still missing:
- Tree-sitter AST parsing parity.
- Precise node-kind mapping for all supported languages.
- Exact `parent` scope behavior from the Python extractor.
- Exact `start_line` and `end_line` behavior for multi-line declarations.
- Python-level handling for nested declarations, anonymous types, enum values, properties, constructors, and complex declarators.
- Robust function signature extraction from syntax trees.
- Full `data_type` and `data_shape` inference parity.
- Preprocessor and macro-aware C/C++ handling.
- Function pointer and multi-line declaration support.

## `symbols_to_components_per_row.py`

Implemented:
- Per-step Ollama integration exists.
- Row classification is part of the C# pipeline structure.
- Allowed architecture component list exists.
- Run artifacts and manifest persistence exist.

Partially implemented:
- Classification workflow is integrated into the pipeline but not yet a full Python-equivalent row-by-row prompt/repair system.

Still missing:
- Exact two-line prompt output validation and repair loop.
- Saving per-row request/response files like the Python script.
- Python-style `component_list.md` generation with per-component tables and original row blocks.
- Exact classification prompt text and retry behavior.
- Exact `description`/`reasoning_summary` generation parity.
- Same field-level output shape in `component_assignments.json`.

## `build_component_hierarchy.py`

Implemented:
- A hierarchy step exists in the C# pipeline.
- Component grouping and subcomponent output are present at a basic level.
- JSON output is persisted per run.

Partially implemented:
- The hierarchy step exists but is much simpler than the Python version.

Still missing:
- Full model-driven subcomponent grouping behavior.
- Exact prompt construction based on all symbols in a component.
- Parsing of `OVERVIEW`, `SUBCOMPONENT`, and `MEMBER` response format.
- Fallback grouping behavior matching the Python script.
- Leftover symbol handling as “Other Supporting Responsibilities”.
- Exact deduplication and membership matching semantics.
- Exact output schema parity for nested component hierarchy JSON.

## `enrich_component_hierarchy_with_callers_v2.py`

Implemented:
- A caller-enrichment step exists in the C# pipeline.
- Run artifacts and persisted manifests exist.

Partially implemented:
- The step is present but not yet a full caller-resolution system.

Still missing:
- Source scanning for call-site detection.
- Enclosing caller resolution from source ranges.
- Mapping callers back into component/subcomponent ownership.
- Ollama-generated `why_called` explanations.
- Caller deduplication and component summary output.
- Full `component_hierarchy_with_callers.json` schema parity.
- Caller resolution strategy metadata equivalent to the Python version.

## Cross-Cutting Gaps

Implemented:
- Step-based console entry point.
- Run browser and summary output.
- Manifest-driven rerun caching.
- Clean project split into application, domain, infrastructure, contracts, app, and tests.

Still missing:
- Full fidelity parity with the Python artifact set.
- Strict prompt templates matching the Python scripts.
- Rich console dashboard visuals beyond colored text summaries.
- True production-grade cache invalidation across all step outputs.
- End-to-end compatibility validation against the existing Python-generated JSON files.

## Recommended Next Work

1. Port the Python classification workflow exactly, including prompt repair and raw request/response persistence.
2. Replace the heuristic C/C++ extractor with a proper syntax-tree-based implementation or an equivalent parser library.
3. Finish hierarchy building and caller enrichment to match the Python schema and behavior.
4. Add regression tests that compare the new C# outputs against the existing Python artifacts.

