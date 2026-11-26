# Reality
### The universe is running in production. We are inside it.

> **What if conscious observers, themselves products of an unknown implementation, attempted to reconstruct that implementation using only the information available from within it?**

That is the question at the heart of **Reality**.

We did not design the universe. We cannot step outside it, examine its source code, or compare its behavior with an independently accessible implementation. We are participants in the very system we are trying to understand.

And yet the system has produced organisms capable of observing it, constructing models, testing explanations, and asking what — if anything — underlies everything they observe.

This repository is a **C# 12 / .NET 8 exploration of science, consciousness, philosophy and the limits of knowledge from inside reality**. The code is an analogy: it does *not* assume reality is literally software or a designed simulation.

```csharp
// TODO: Discover the actual implementation.
// Source code unavailable.
```

## The solution tells the story

Open `Reality.sln` in Visual Studio 2022. The six projects are intentionally named after the steps of the investigation:

| Project | Fundamental question | Responsibility |
| --- | --- | --- |
| **Reality.Core** | What concepts are needed to describe the investigation? | Contracts for underlying reality, observable phenomena, observers, findings, and evidence vocabulary |
| **Reality.Science** | What do observations reveal about the universe? | Physics, spacetime, cosmology, genetics, evolution, neuroscience, emergence, culture, and the scientific catalog |
| **Reality.Philosophy** | What could ultimately explain what we observe? | Panpsychism, physicalism, idealism, dualism, and their assumptions and unresolved questions |
| **Reality.Investigation** | What conclusions does the evidence actually support? | Reasoning graph, research provenance, traceable inferences, and comparisons of interpretations |
| **Reality.Console** | How does an observer interact with the investigation? | Executable entry point; presents research, theories and the educational science models |
| **Reality.Tests** | Do our models preserve their rules and boundaries? | Dependency, behavioral, scientific, reasoning, and architectural smoke checks |

### Dependencies express epistemic boundaries

```text
                       Reality.Console
                         /    |    \
                        v     v     v
       Reality.Investigation  Reality.Science  Reality.Philosophy
              |    \              |             |
              |     +-------------+             |
              |                    \            |
              +---------------------+-----------+
                                    v
                                Reality.Core

Reality.Tests -> all four libraries
```

This is a conceptual sketch. The enforceable project-reference graph is:

```text
Core           -> (no project dependencies)
Science        -> Core
Philosophy     -> Core
Investigation  -> Core, Science, Philosophy
Console        -> Core, Science, Philosophy, Investigation
Tests          -> Core, Science, Philosophy, Investigation
```

Core cannot depend on a scientific or philosophical implementation. Science cannot reference Philosophy or Investigation. Philosophy cannot depend on a particular scientific implementation. Only Investigation combines their claims, and Console serves as the observer's composition root.

**There is deliberately no `Reality.Implementation` project.** The real implementation of the universe remains unknown.

### Contracts versus concrete models

- `Reality.Core.Ontology.IReality` represents an *unknown* underlying reality.
- `Reality.Core.Observation.IObservableUniverse` describes what observers can investigate, without returning concrete scientific implementation types.
- `Reality.Core.Observation.IObserver` is the minimal observer boundary.
- `Reality.Science.Observation.ObservedUniverse` is an intentionally revisable educational model, **not** an `IReality` implementation.
- `Reality.Science.Consciousness.HumanConsciousness` is one toy observer implementation.
- `IExperience` describes first-person experience, while `IUnifiedConsciousness` is deliberately a hypothetical marker for phenomenal unity, **not** a requirement to reflect or report. `IObserver` separately owns reflective cognition and scientific inquiry. The illustrative `HumanConsciousness` implements both contracts, without claiming that reflection produces consciousness or solves the combination problem.
- `Reality.Philosophy.Interfaces.ITheoryOfReality` describes interpretations; no theory pretends to instantiate reality.
- `Reality.Investigation.Workflow.RealityInvestigator` assembles shared findings, an evidence graph and the philosophical inventories.

## Scientific knowledge versus interpretation

Our investigations distinguish **reported observations**, **methodological assumptions**, **inferences**, **scientific models**, **philosophical interpretations**, and **unanswered questions**.

The scientific catalog includes findings and illustrative reasoning trails about cosmic expansion, dark matter, and neural correlates. Most do not yet include independent primary-source provenance; that gap is explicit.

The first graph example uses a [2025 *Nature* preregistered comparison of GNWT and IIT](https://doi.org/10.1038/s41586-025-08888-1). It traces a deliberately limited neural inference back to its reported observations, source, and assumptions, and marks challenges and unresolved questions. Neither this study nor our graph determines the fundamental nature of consciousness.

The four current philosophical perspectives are **panpsychism, physicalism, idealism and substance dualism**. These are broad ontological accounts, distinct from more specific neural theories such as Global Neuronal Workspace Theory and Integrated Information Theory.

**An observation is not automatically an inference. An inference is not automatically a complete explanation. An explanation is not automatically a proof of ultimate ontology.**

## Run

Requirements: .NET 8 SDK (C# 12), Visual Studio 2022 or another compatible editor. The solution uses no third-party NuGet packages.

```bash
dotnet build Reality.sln
dotnet run --project src/Reality.Console/Reality.Console.csproj
dotnet run --project src/Reality.Console/Reality.Console.csproj -- Physicalism
dotnet run --project src/Reality.Console/Reality.Console.csproj -- Idealism
dotnet run --project src/Reality.Console/Reality.Console.csproj -- "Substance dualism"
dotnet run --project tests/Reality.Tests/Reality.Tests.csproj
```

By default, Console compares the available theories against **the same observable scientific findings**, shows educational demonstrations and traces the consciousness example's reasoning. When launched interactively it offers **Press Enter to exit**; redirected output and CI do not block.

## Source conventions and clean builds

- **One class, record, enum or interface per `.cs` file.**
- Core contracts live directly under their meaningful domain folders (`Ontology/`, `Observation/`, `Consciousness/`); specialized interfaces in other projects use domain-specific `Interfaces/` folders.
- Namespaces match the complete project-plus-folder hierarchy.
- `Program.cs` is the only C# source file at the Console and Tests project roots; domain classes live in named folders.
- `Directory.Build.props` standardizes .NET 8, C# 12, nullability, warnings as errors and code-style enforcement across all six projects.
- `.editorconfig` keeps Visual Studio analyzers enabled rather than suppressing their suggestions.
- GitHub Actions validates the project-reference graph and file layout, compiles the complete solution, and executes smoke checks.

The scientific simulations are intentionally small teaching examples, not a physics engine, brain simulation, complete genetics model or demonstrated quantum-gravity duality. The underlying questions remain open.

## Continue the investigation

Possible next steps: attach robust research provenance and original data to each inference; distinguish scientific mechanisms from metaphysical theories in greater detail; compare preregistered predictions; trace objections and alternatives; and investigate the observational limitations of the observers themselves.

An observer within the system might discover extraordinary regularities, yet still lack a way to inspect the ultimate implementation.

> **What can a system know about itself when its source code is unavailable?**

```csharp
// TODO: Discover the actual implementation.
// Source code unavailable.
```
