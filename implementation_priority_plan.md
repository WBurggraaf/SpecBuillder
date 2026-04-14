# Implementation Priority Plan

This plan orders the remaining work to close the Python-to-C# parity gap in a way that minimizes rework.

## Priority 1 - Match The Classification Workflow

Why first:
- This is the most visible user-facing stage after extraction.
- It already has the right pipeline slot and is easiest to validate against the Python artifacts.
- It drives the downstream hierarchy and export formats.

Target files:
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.App/Program.cs`
- `SpecBuilder.App/ConsoleUi.cs`

Work items:
- Recreate the Python row-by-row prompt structure exactly.
- Add strict parsing for the two-line `COMPONENT:` and `DESCRIPTION:` response format.
- Add repair prompts for invalid outputs.
- Persist raw request and response artifacts per row.
- Emit the same assignment fields as the Python `component_assignments.json`.
- Make reruns resume from the last successful row.

Success criteria:
- The C# classification output can be diffed meaningfully against the Python `component_assignments.json`.
- Invalid model output is retried instead of silently accepted.
- Per-row artifacts are written consistently.

## Priority 2 - Replace Heuristic Symbol Extraction

Why second:
- Every later step depends on the quality of the symbol index.
- Extraction quality is the main limitation on “any C/C++ codebase” support.

Target files:
- `SpecBuilder.Infrastructure/SymbolExtraction.cs`
- `SpecBuilder.Domain/ArchitectureModels.cs`
- `SpecBuilder.Infrastructure/PipelineSteps.cs`

Work items:
- Replace the current line-based C/C++ parsing with a proper syntax-tree-based parser or equivalent robust parser strategy.
- Preserve the Python-like symbol schema:
  - file
  - kind
  - name
  - qualified_name
  - parent
  - start_line
  - end_line
  - signature
  - data_type
  - data_shape
- Improve support for:
  - nested declarations
  - typedef aliases
  - anonymous structs/unions/enums
  - function pointers
  - multi-line declarations
  - macro-heavy headers

Success criteria:
- Extraction handles a broader set of real C/C++ repositories without ngIRCd-specific assumptions.
- Duplicate or malformed symbols are materially reduced.

## Priority 3 - Match The Hierarchy Builder

Why third:
- The hierarchy depends on normalized classification output.
- Once classification is stable, hierarchy generation can be made schema-compatible.

Target files:
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.Domain/Models.cs`
- `SpecBuilder.Contracts/Contracts.cs`

Work items:
- Recreate the `OVERVIEW / SUBCOMPONENT / MEMBER` prompt and parser behavior.
- Add fallback grouping similar to the Python version.
- Preserve member-to-subcomponent assignment rules.
- Add “Other Supporting Responsibilities” for leftovers.
- Produce hierarchy JSON compatible with the Python output structure.

Success criteria:
- The C# hierarchy output is structurally aligned with `component_hierarchy.json`.
- Subcomponent grouping behaves deterministically on malformed model output.

## Priority 4 - Implement Caller Enrichment

Why fourth:
- It depends on the hierarchy and symbol index being reasonably stable.
- It is the most complex behaviorally, but it can be built cleanly once upstream artifacts are trustworthy.

Target files:
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/SymbolExtraction.cs`

Work items:
- Scan source files for call sites.
- Resolve enclosing caller symbols.
- Map callers back to component and subcomponent ownership.
- Generate concise `why_called` explanations.
- Persist a `component_hierarchy_with_callers.json` artifact.

Success criteria:
- The C# enrichment output is structurally comparable to the Python caller-enriched hierarchy.

## Priority 5 - Tighten The Console Experience

Why fifth:
- The app already has the right basic menu flow.
- The remaining work is polish and operator ergonomics.

Target files:
- `SpecBuilder.App/ConsoleUi.cs`
- `SpecBuilder.App/Program.cs`

Work items:
- Add richer step dashboard visuals.
- Show cached vs executed steps more clearly.
- Display input hashes and artifact paths.
- Add direct rerun-from-step flow in the run browser.
- Add more structured run summaries.

Success criteria:
- The console is usable for repeated analysis sessions without reading logs manually.

## Priority 6 - Add Parity Tests

Why last:
- Tests are most useful when they lock in behavior that has already been made stable.
- This avoids writing tests around unstable intermediate behavior.

Target files:
- `SpecBuilder.Tests/*`

Work items:
- Add extractor regression tests.
- Add classification prompt and parsing tests.
- Add hierarchy parsing tests.
- Add caller enrichment tests.
- Add artifact structure tests.
- Add output comparison tests against the Python-generated artifacts.

Success criteria:
- The major pipeline stages are covered by repeatable tests.

## Suggested Execution Order

1. Classification workflow parity.
2. Symbol extraction hardening.
3. Hierarchy builder parity.
4. Caller enrichment.
5. Console polish.
6. Regression tests and diff-based validation.

## Practical Rule

Do not spend time polishing downstream steps until the extraction and classification outputs are stable enough to feed them reliably.

