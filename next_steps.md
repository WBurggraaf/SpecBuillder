# Next Steps

This plan turns the Python-to-C# parity backlog into concrete implementation tickets. The priority is to close the biggest fidelity gaps first, then validate by diffing against the existing Python artifacts.

## 1. Replace `SymbolExtraction.cs` with parser-backed extraction

**Files**
- `SpecBuilder.Infrastructure/SymbolExtraction.cs`
- `SpecBuilder.Tests/*` for parity tests

**Goal**
- Stop using heuristic line parsing for C/C++ and move to AST-backed extraction behavior.

**Tasks**
- Preserve exact `start_line` / `end_line` spans from syntax nodes.
- Extract types, fields, functions, typedefs, nested scopes, and callable symbols from real parse structure.
- Handle anonymous structs, unions, enums, classes, and nested declarations.
- Add support for function pointers, multiline declarators, and typedef chains.
- Keep Python, Java, and C# extraction stable while improving C/C++ fidelity.

**Acceptance criteria**
- Symbol rows for the Python baseline match the important span and kind fields closely enough to diff.
- Comment-only lines no longer appear as symbol content.
- Nested type members are qualified consistently.
- The extractor produces stable output on a broad set of C/C++ codebases, not just ngIRCd.

**Estimated effort**
- 1 to 2 weeks for a robust parser-backed implementation.
- 2 to 4 days for a meaningful fidelity upgrade if the parser library or syntax model is already available.

**Test cases**
- Extract a small C header with nested structs, typedefs, and function declarations.
- Extract a macro-heavy header and verify comment-only lines are ignored.
- Extract a file with function pointers and multiline declarations.
- Compare a known Python baseline file against the C# output for line span and kind sanity.

**First code change**
- Replace the current statement tokenizer in `SpecBuilder.Infrastructure/SymbolExtraction.cs` with a syntax-node driven extraction path for C/C++ files, starting with exact span capture.

## 2. Align classification with the Python script

**Files**
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/OllamaClient.cs`
- `SpecBuilder.Tests/*`

**Goal**
- Make row-by-row classification behave as close as possible to `symbols_to_components_per_row.py`.

**Tasks**
- Match Ollama generation settings more closely.
- Clone the Python prompt structure and output expectations.
- Keep strict `COMPONENT:` / `DESCRIPTION:` parsing and repair retries.
- Normalize aliases and fallback component names exactly.
- Compare row artifact files against Python artifacts and patch mismatches.

**Acceptance criteria**
- Classification artifacts are reproducible and structured the same way as the Python run artifacts.
- Invalid model responses still retry and recover.
- The resulting `component_assignments.json` is diff-friendly against the Python baseline.

**Estimated effort**
- 1 to 3 days.

**Test cases**
- Feed a single known row through the classifier and verify the request and response artifacts are written.
- Force an invalid model response and confirm the repair prompt is used.
- Verify alias normalization maps expected component names to canonical names.
- Compare a small classification batch against the Python artifact shape.

**First code change**
- Make the Ollama request payload in `SpecBuilder.Infrastructure/OllamaClient.cs` match the Python generation settings and prompt structure more closely.

## 3. Finish export parity

**Files**
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.Domain/ArchitectureModels.cs`

**Goal**
- Make the exported JSON and markdown closer to the Python outputs.

**Tasks**
- Keep `component_assignments.json` structure stable and explicit.
- Match `component_list.md` grouping and metadata formatting more closely.
- Preserve enough field naming and ordering to make artifact diffs easy to read.
- Add validation tests for the export schema.

**Acceptance criteria**
- Exported artifacts are easy to compare line-by-line with the Python versions.
- The report contains the same logical information as the Python outputs.
- No required metadata is dropped during export.

**Estimated effort**
- 1 to 2 days.

**Test cases**
- Export a small classified symbol set and inspect `component_assignments.json`.
- Verify `component_list.md` groups entries by component and preserves the original rows.
- Check that required metadata fields are present for every assignment.
- Confirm the summary file reflects the run configuration.

**First code change**
- Add a schema assertion test for `component_assignments.json` in `SpecBuilder.Tests` before changing export formatting further.

## 4. Improve hierarchy parity

**Files**
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.Tests/*`

**Goal**
- Make `component_hierarchy.json` closer to `build_component_hierarchy.py`.

**Tasks**
- Refine prompt composition for subcomponent grouping.
- Parse `OVERVIEW`, `SUBCOMPONENT`, and `MEMBER` output more robustly.
- Handle leftovers and fallback grouping in a Python-like way.
- Deduplicate members before prompting and after parsing.

**Acceptance criteria**
- The hierarchy structure is stable and readable.
- The output grouping resembles the Python artifact for the same inputs.
- Parsing failures do not drop symbols silently.

**Estimated effort**
- 2 to 4 days.

**Test cases**
- Feed a small component list into the hierarchy builder and verify subcomponents are emitted.
- Simulate malformed model output and confirm fallback grouping occurs.
- Verify leftovers are assigned to a generic supporting bucket.
- Compare hierarchy structure against the Python JSON on a known sample.

**First code change**
- Tighten the `OVERVIEW / SUBCOMPONENT / MEMBER` parser in `SpecBuilder.Infrastructure/Classification.cs` so it can preserve more of the model output structure.

## 5. Improve caller enrichment parity

**Files**
- `SpecBuilder.Infrastructure/Classification.cs`
- `SpecBuilder.Infrastructure/PipelineSteps.cs`
- `SpecBuilder.Tests/*`

**Goal**
- Make `component_hierarchy_with_callers.json` more faithful to `enrich_component_hierarchy_with_callers_v2.py`.

**Tasks**
- Improve enclosing caller resolution.
- Map callers back to owning component and subcomponent more reliably.
- Add richer caller explanation text.
- Preserve the caller metadata shape expected by downstream use.

**Acceptance criteria**
- Caller enrichment is source-aware and not just name-matching.
- The resulting JSON includes meaningful caller mappings and explanations.
- The structure remains stable across reruns.

**Estimated effort**
- 2 to 5 days.

**Test cases**
- Scan a small file with one known caller/callee pair and verify the caller is resolved.
- Run enrichment on a source file with multiple functions sharing names across scopes.
- Verify the output JSON includes caller component ownership when available.
- Confirm reruns produce stable enrichment output on unchanged input.

**First code change**
- Replace the current heuristic call-site resolver with a symbol-range-aware caller lookup in `SpecBuilder.Infrastructure/PipelineSteps.cs`.

## 6. Add full parity diff runs

**Files**
- `SpecBuilder.App/Program.cs`
- `SpecBuilder.App/ConsoleUi.cs`
- `.specbuilder/runs/*`

**Goal**
- Make it easy to run the full pipeline noninteractively and compare outputs against Python.

**Tasks**
- Ensure the app can run the full pipeline without menu interaction.
- Produce complete run artifacts for every stage.
- Add a repeatable diff workflow for Python vs C# outputs.
- Surface the key differences in the console dashboard.

**Acceptance criteria**
- A full run completes and writes all expected artifacts.
- Run artifacts can be compared without manual reconstruction.
- Differences between implementations are easy to locate.

**Estimated effort**
- 1 to 2 days.

**Test cases**
- Run the app noninteractively from start to finish.
- Verify every step writes a manifest or artifact into the run directory.
- Compare one complete C# run against a Python baseline folder.
- Confirm the dashboard reports cached and executed steps clearly.

**First code change**
- Add or refine a `--run-full` path in `SpecBuilder.App/Program.cs` that always produces a complete run folder without menu interaction.

## Suggested Order

1. `SymbolExtraction.cs`
2. `Classification.cs`
3. `PipelineSteps.cs`
4. hierarchy parity
5. caller enrichment parity
6. end-to-end diff runs

## Practical Definition of Done

- The C# solution can process the same source tree as the Python scripts.
- The generated artifacts are structurally comparable to the Python outputs.
- The biggest remaining differences are documented and isolated to specific files.
