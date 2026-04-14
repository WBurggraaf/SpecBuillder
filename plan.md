SpecBuilder One-Pass Rebuild Plan
Goal

Rebuild the current Python-based symbol-analysis pipeline as a production-grade console application in C# 14 on .NET 10, with no Python dependency in the final system.

The rebuild should be done in one coherent implementation pass, with architecture, pipeline, persistence, rerun support, console UX, and Ollama integration designed together from the beginning.

The system must:

Preserve the intent of the current pipeline.
Improve structure, observability, resilience, and performance.
Support resumable, step-based execution.
Provide a modern interactive console experience.
Keep model usage safe, validated, and traceable.
Be suitable for large repositories and repeated runs.
Build Strategy
Core Principle

Do not treat this as a script port or a sequence of disconnected rewrites.

Build it as one integrated product with:

a stable domain model,
a step pipeline engine,
artifact persistence,
cache-aware rerun logic,
controlled Ollama orchestration,
and a presentation layer that sits on top of those capabilities.

This means the first complete build should already include:

full project structure,
all pipeline stages,
manifest-driven rerun support,
persisted artifacts,
console menus,
and testable abstractions.

The implementation should still be delivered incrementally in code, but the design must be finalized upfront so no major rework is needed later.

Product Shape
Final Product

A single console-first application called SpecBuilder, capable of:

selecting a workspace,
executing the full pipeline,
resuming incomplete work,
rerunning selected steps,
inspecting artifacts,
and exporting final results.
Pipeline to Rebuild

The new application replaces the current workflow:

Extract symbols from source code.
Classify symbols into architecture components using Ollama.
Build component hierarchies and subcomponents.
Resolve callers and enrich the hierarchy.
Export JSON and markdown artifacts.
Support reruns, caching, and inspection throughout.
Solution Structure

Create a .NET 10 solution with these projects:

SpecBuilder.App
console host
menu system
progress views
run selection
artifact inspection
SpecBuilder.Application
use cases
pipeline orchestration
step execution
run coordination
rerun policies
validation flows
SpecBuilder.Domain
core models
value objects
enums
domain rules
SpecBuilder.Infrastructure
filesystem access
parser integration
Ollama client
caching
manifests
artifact storage
JSON persistence
SpecBuilder.Contracts
DTOs
persisted JSON contracts
export contracts
SpecBuilder.Tests
unit tests
integration tests
pipeline smoke tests

If project count is reduced, the same boundaries must still exist clearly.

Architectural Rules
Domain must not depend on console, HTTP, Ollama, or filesystem APIs.
Application owns orchestration and pipeline rules.
Infrastructure owns external concerns only.
Presentation must remain thin.
Prompt construction must not live in UI code.
Artifacts and manifests must be first-class outputs of every step.
Every long-running operation must support cancellation, progress reporting, and resumability.
Primary Design Decision
Build Around a Pipeline Engine

Instead of building a set of commands that happen to call each other, implement a formal step pipeline engine.

Each step must be a first-class unit with:

step identity,
version,
declared inputs,
declared outputs,
validation,
cache fingerprint,
execution handler,
status,
and rerun policy.

This is the key to getting “build once properly” rather than retrofitting rerun logic later.

Required Step Interface

Each pipeline step should conceptually expose:

CanRun
Execute
ValidateOutputs
ComputeFingerprint
GetArtifactManifest
SupportsResume
SupportsPartialRerun
User Experience
Console Experience

The console should feel like an actual engineering tool.

Required:

numbered main menu
current workspace/run panel
step status dashboard
color-coded states:
success
warning
failure
running
cached
progress indicators during long work
short summaries after every step
previous run browsing
artifact browsing
rerun options
safe overwrite prompts
deterministic run IDs
visible artifact paths
Recommended Library

Use Spectre.Console unless there is a compelling reason not to.

Use:

tables
panels
status spinners
progress bars
selection prompts
confirmation prompts
markup/color for summaries

Avoid raw Console.WriteLine-driven UX except for low-level logs.

Workspace and Run Model
Workspace

A workspace is the top-level execution context and contains:

source root
introduction/context file
app settings
prompt template versions
run history
artifacts
manifests
logs
Run

Every execution should produce a deterministic run record:

run ID
workspace ID
timestamps
selected steps
inputs
hashes
status
output artifacts
error state
retry history
Artifact Directory Shape

Recommended layout:

.specbuilder/
  config/
  prompts/
  runs/
    <run-id>/
      manifest.json
      step-01-discovery/
      step-02-symbols/
      step-03-classification/
      step-04-hierarchy/
      step-05-callers/
      step-06-export/
  cache/
  logs/

This structure should exist from the start.

Pipeline Definition
Step 1 - Project Discovery

Responsibilities:

select or confirm source root
load introduction/context file
validate workspace
detect supported source files
compute initial workspace fingerprint

Outputs:

workspace manifest
discovered source file list
validation report

Must support:

cached discovery reuse
fast rescan when files changed
Step 2 - Symbol Extraction

Responsibilities:

scan supported files
parse symbols into normalized records
capture:
file
kind
name
qualified_name
line range
parent
signature
data_type
data_shape
generate stable symbol IDs
persist extraction artifacts

Outputs:

symbols.json
extraction manifest
parser diagnostics

Performance requirements:

incremental file hashing
skip unchanged files
parallel parsing where safe
deterministic ordering

This step should produce the canonical symbol index used by all later steps.

Step 3 - Symbol Classification

Responsibilities:

classify symbols one by one or in controlled batches
invoke Ollama only through the classification service
validate responses strictly
repair malformed responses with bounded retry logic
persist each completed row immediately

Outputs:

component_assignments.json
request/response logs
retry logs
classification manifest
unresolved or failed rows report

Critical design choice:
This step must be resumable at row level.

If interrupted, rerunning should continue from the last valid symbol, not restart the whole step.

Required persistence granularity

Persist:

row input
prompt version
request payload
raw model response
parsed response
validation status
final accepted assignment
Step 4 - Component Hierarchy Building

Responsibilities:

group symbols by component
generate subcomponents using Ollama
validate grouping output
apply deterministic fallback grouping when output is malformed
preserve symbol lineage to source assignment

Outputs:

component_hierarchy.json
hierarchy generation logs
fallback usage report

Critical rule:
Hierarchy generation must not lose symbol metadata from earlier steps.

All symbol-level metadata should flow through unchanged.

Step 5 - Caller Enrichment

Responsibilities:

find call sites in source code
resolve enclosing caller symbol by source range
map caller symbol back to component and subcomponent
attach caller information to target callable symbols
optionally use Ollama to describe why the caller invokes the target based on code context

Outputs:

component_hierarchy_with_callers.json
caller lookup index
unresolved caller report
Ollama reasoning logs for caller descriptions

Critical rule:
Caller resolution should be deterministic first, model-assisted second.

Use Ollama only to explain the intent of a resolved call, not to guess structural relationships.

Step 6 - Export and Review

Responsibilities:

generate final JSON artifacts
generate markdown reports
generate concise console summaries
expose artifact folder paths
support opening artifact folders from the UI where appropriate

Outputs:

markdown summaries
final JSON outputs
summary metrics
export manifest
Rerun and Cache Strategy

Rerun support must be designed into every step from the start.

Required Features
rerun one selected step
rerun from a selected step onward
reuse cached outputs if fingerprints match
force invalidation
partial rerun for a subset when supported
safe overwrite prompts in interactive mode
Recommended Cache Model

Each step writes a manifest containing:

step name
step version
input fingerprint
prompt template version
configuration version
output artifact hashes
start/end time
status
warnings/errors
Fingerprint Inputs

Fingerprints should include:

source file hashes
introduction file hash
prompt template hash
relevant configuration hash
application version or pipeline version
step implementation version

If any fingerprint-relevant input changes, the step becomes invalid.

Ollama Safety Model

Ollama must be treated as a controlled subsystem, not a helper scattered across the app.

Rules
only callable from approved application steps
all prompt templates versioned
all requests persisted
all responses validated before acceptance
bounded retries only
deterministic repair prompts only
timeout and cancellation support required
fallback behavior required for failure or malformed output
Recommended Interfaces
IModelClient
IClassificationPromptBuilder
IHierarchyPromptBuilder
ICallerReasoningPromptBuilder
IModelResponseValidator
Recommended Safeguards
per-step concurrency controls
request throttling
content length guards
prompt version IDs
response schema parsing
structured repair attempts
max retry cap
“dry run / no model mode” where feasible for non-model steps
Domain Model

Use immutable records or equivalent immutable types where practical.

Core concepts should include:

Workspace
RunRecord
RunStep
StepStatus
SourceFile
SourceFingerprint
Symbol
SymbolId
SymbolKind
ComponentAssignment
ArchitectureComponent
Subcomponent
CallRelationship
CallerReference
PromptVersion
ArtifactRecord
ValidationFailure
Important rule

Introduce stable IDs early:

symbol IDs should be deterministic
caller references should use stable symbol identity where possible
artifact records should be linkable from manifests
Application Layer Responsibilities

The application layer should own:

pipeline execution
rerun rules
cache validation
step dependencies
batch sizing
retry policy coordination
cancellation flow
progress reporting contracts
summary generation
error recovery logic

Example use cases:

initialize workspace
start new run
resume run
run full pipeline
run selected step
rerun from step
inspect run
export artifacts
invalidate cache
validate workspace
Infrastructure Responsibilities

Infrastructure should implement:

source discovery
parser integration
symbol extraction
artifact storage
JSON serialization
filesystem hashing
Ollama HTTP client
prompt template loading
logs and diagnostics
caching store
manifest persistence
Parsing Strategy

Because the Python version used tree-sitter-based extraction semantics, use a robust parsing approach that can support:

C / C++
C#
Java
Python

If tree-sitter integration is the best route in .NET, use it behind an abstraction so extraction logic stays isolated from parser implementation details.

Presentation Responsibilities

The console app should provide:

startup screen
workspace selection or creation
run dashboard
step execution menu
rerun menu
artifact browser
summary panels
failure diagnostics view
previous run history
cache status view
Menu shape

Recommended main menu:

Open workspace
Start full pipeline
Resume latest run
Run specific step
Rerun from step
View run history
Inspect artifacts
Clear cache / invalidate step
Settings
Exit
Performance Strategy

The rebuild must be optimized from the start.

Required performance decisions
incremental source hashing
skip unchanged files
parser reuse where possible
parallel extraction where safe
low-allocation JSON handling where practical
immediate persistence for long model stages
artifact streaming where useful
responsive progress rendering
bounded memory growth on large trees
Recommended optimizations
maintain a per-file symbol cache
separate “source scan hash” from “full content hash”
keep an index from file to symbols
lazy load large artifacts in inspection views
persist classification incrementally instead of at end
avoid re-reading giant JSON files when partial indexes suffice
Data and Artifact Flow

Canonical artifact chain:

workspace_manifest.json
source_inventory.json
symbols.json
component_assignments.json
component_hierarchy.json
component_hierarchy_with_callers.json
summary.md
run_manifest.json

Also persist:

request/response logs for Ollama
prompt versions
validation errors
retry logs
cache metadata
performance timings
Implementation Plan

This is the recommended one-pass implementation order.

Stage A - Skeleton and Contracts

Build the full solution structure first:

projects
dependency injection
configuration
logging
run manifest model
step contract
artifact contract
workspace model
console shell

This stage should already establish the final architectural shape.

Stage B - Pipeline Engine and Persistence

Before implementing individual steps, build:

step runner abstraction
manifest writer
cache fingerprint service
artifact directory conventions
resume/rerun mechanics
progress reporting contracts

This is what makes the whole app cohesive.

Stage C - Source Discovery and Extraction

Implement:

source discovery
parser integration
symbol normalization
symbol persistence
extraction validation
parser tests

At this point the application should already support:

discovery
extraction
artifact inspection
cached rerun
Stage D - Ollama Classification

Implement:

prompt template versioning
classification pipeline
strict validation
incremental persistence
retry and repair handling
cancellation support
classification summaries

At this point the system should already be usable end to end through classification.

Stage E - Hierarchy Builder

Implement:

grouping
subcomponent generation
fallback grouping
hierarchy artifact persistence
summary display
Stage F - Caller Enrichment

Implement:

source call scanning
caller symbol resolution
component/subcomponent back-mapping
why-called reasoning via Ollama
caller metrics and summaries
Stage G - Export and UX Completion

Implement:

markdown export
artifact browsing
run history views
rerun menus
invalidation menus
step status dashboard
final polish
Stage H - Hardening

Complete:

test coverage
malformed data recovery
performance tuning
large-repo smoke tests
structured diagnostics
timeout and cancellation hardening
Testing Plan
Required tests
symbol extraction unit tests
parser normalization tests
fingerprint tests
cache validity tests
rerun-from-step tests
classification validation tests
hierarchy fallback tests
caller resolution tests
Ollama client contract tests
end-to-end smoke test over a small fixture repo
Testing rules
most tests should mock Ollama
only a few integration tests should hit a real local model
regression fixtures should capture malformed outputs and duplicate symbol cases
tests must verify resumability and cache correctness, not just happy-path outputs
Migration Rules

Do not:

port Python line-for-line
treat scripts as architecture
scatter JSON assumptions throughout the app
bury rerun logic inside individual console commands
make the model client callable from anywhere

Do:

preserve behavior, not implementation shape
centralize all step orchestration
centralize manifest and cache rules
preserve artifact inspectability
keep the system deterministic wherever possible
make model use explicit and bounded
Definition of Done

The rebuild is complete when:

the full pipeline runs in C# 14 / .NET 10
no Python is required for normal operation
each pipeline step runs independently
rerun and resume work safely
cache invalidation works correctly
Ollama is invoked only through controlled application steps
artifacts are reproducible, persisted, and inspectable
the console UX is modern and usable
tests cover extraction, classification, hierarchy, caller enrichment, and rerun logic
the system is suitable for repeated use on large source trees
Recommended Final Delivery Approach

Build the first production-ready version with this scope in one cohesive branch:

solution skeleton
pipeline engine
manifests and cache
source discovery
symbol extraction
classification
hierarchy
caller enrichment
export
console UX
tests and hardening

