# Reality — the universe is running in production

A **C# 12 / .NET 8** conceptual model of physics, cosmology, chemistry, evolution, neuroscience, human consciousness and philosophy.

> Physics documents observable behavior. Philosophy questions the architecture. Consciousness is an instance running inside the system it is trying to understand. Source code unavailable.

This project is an **educational analogy**, not a physical simulation, a theory of everything or scientific evidence for panpsychism.

## Run

```bash
dotnet run --project src/Reality/Reality.csproj
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

Requires the .NET 8 SDK. No third-party packages.

## Architecture

| Component | Responsibility |
| --- | --- |
| `IReality` / `PanpsychistReality` | Compose the conceptual universe; panpsychism is a selected hypothesis, not a result |
| `ILawsOfPhysics` / `KnownPhysics` | Representative tested physical principles and unanswered questions |
| `CosmicHistory` | Illustrative cosmic chronology |
| `ChemistryModel` | Atoms, bonds and chemical complexity |
| `IBiologicalEvolution` / `DarwinianEvolution` | Seeded, fixed-size quantitative-trait toy evolution with selection, mutation and drift |
| `INervousSystem` / `NervousSystem` | Deliberately simplified information processing |
| `HumanConsciousness` | First-person perspective, science, philosophical reflection |
| `ITheoryOfConsciousness` / `TheoryComparison` | Competing metaphysical explanations |
| `ScientificCatalog` | Confidence labels separating evidence from conjecture |
| `CombinationProblem` | Intentional unimplemented philosophical gap |

## Important distinctions

- Physics and evolutionary biology are empirically supported scientific frameworks. Their summarized methods here are *analogies*, not numerical implementations.
- Mutation is not directed toward need; the toy model samples offspring with fitness-weighted reproduction and random trait changes. It does **not** model full genomes, actual populations, gene flow, speciation or extinction.
- The origin of life is a separate research problem from biological evolution once heredity exists.
- Human neural processes are studied empirically; the nature of first-person experience remains contested.
- Panpsychism, idealism, physicalism and substance dualism are philosophical positions, not interchangeable scientific theories with confirmed implementations.
- Physical conservation laws require care in curved spacetime; global energy conservation is not always defined.
- The combination problem is intentionally **not** solved by joining a collection of `IExperience` objects.

## TODOs / unresolved questions

- Quantum gravity and quantum measurement interpretations
- Matter-antimatter asymmetry, dark matter, dark energy, abiogenesis
- Relationship of neural processes to phenomenal experience
- The panpsychist combination problem
- Whether physical laws govern reality or describe observed regularities
- Whether any internal observer can obtain a complete account of reality

## Design note

`IReality` **has** an `ILawsOfPhysics` dependency rather than inheriting from it. That deliberately leaves open whether laws are constitutive of reality or descriptions of its behavior.

## Verification

A package-free smoke-check console project checks physics boundary cases, deterministic toy evolution invariants, coverage of the conceptual timeline and explicit handling of the combination problem. GitHub Actions builds and runs the checks on pushes and pull requests.
