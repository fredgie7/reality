# Reality — the universe is running in production

> Physics documents observable behavior. Philosophy questions the architecture. Consciousness is an instance running inside the system it is trying to understand. Source code unavailable.

**Reality** is an open-ended C# 12 / .NET 8 project for exploring **what reality is, how it behaves, and how different philosophical accounts might explain its underlying nature**.

The architecture is **not committed to a single ontology**. Four candidate interpretations now implement `IReality`: `PanpsychistReality`, `PhysicalistReality`, `IdealistReality`, and `SubstanceDualistReality`. They are *conceptual models*, not demonstrated descriptions of the source code of existence.

This project is an educational analogy, not a numerical simulation, a theory of everything, or evidence in favor of any particular metaphysical position.

## Run

Requires .NET 8 SDK and no third-party dependencies.

```bash
dotnet run --project src/Reality/Reality.csproj
dotnet run --project src/Reality/Reality.csproj -- physicalism
dotnet run --project src/Reality/Reality.csproj -- idealism
dotnet run --project src/Reality/Reality.csproj -- substance-dualism
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

Running without an argument starts with panpsychism, our original example. Pass a model slug to select a different interpretation. Unknown model names are rejected with the available options.

## The idea

```csharp
IReality reality = RealityFactory.Create("idealism", physics, cosmos, chemistry, evolution, knowledge);

// The publicly observable world is unchanged by our choice of interpretation.
// Each implementation supplies an alternative set of metaphysical assumptions.
// TODO: Determine which interpretation, if any, describes reality.
```

The universe is already running in production. The source code is unavailable. Our code models ways of asking what its implementation might be.

## Candidate implementations

| Implementation | Proposal | An unresolved question |
| --- | --- | --- |
| `PanpsychistReality` | Experience is fundamental and widespread | How (or whether) simpler experiential aspects relate to unified subjects |
| `PhysicalistReality` | The mental is physical or wholly fixed by physical facts | How physical processes account for subjective experience |
| `IdealistReality` | Mind or experience is metaphysically fundamental | How a stable, shared physical world is explained |
| `SubstanceDualistReality` | Mental and physical substances are ontologically distinct | Whether and how mental and physical substances interact |

These are **broad families of views**, not exhaustive definitions. For example, physicalism has reductive and nonreductive variants, and idealism has multiple distinct formulations. Each class includes TODOs about its own unresolved questions; none is presented as established science.

## Architecture

| Component | Responsibility |
| --- | --- |
| `IReality` | Common contract for any candidate explanation of reality |
| `RealityBase` | Shared, ontology-independent cosmology, physics, evolution and observer construction |
| `Implementations/*Reality.cs` | Four interchangeable candidate ontologies |
| `RealityFactory` | Explicit registry and selection of the candidate implementations |
| `Implementations/Panpsychism/CombinationProblem.cs` | Panpsychism-specific open problem |
| `ILawsOfPhysics` / `KnownPhysics` | Representative physical principles and open problems |
| `CosmicHistory` / `ChemistryModel` | Simplified conceptual progression of cosmic history |
| `IBiologicalEvolution` / `DarwinianEvolution` | Seeded toy evolution with inheritance, selection, drift and mutation |
| `INervousSystem` / `HumanConsciousness` | Simplified cognition and first-person reflection |
| `ITheoryOfConsciousness` / `TheoryComparison` | Side-by-side philosophy comparison |
| `ScientificCatalog` | Scientific findings and explicit epistemic status |

## Add an implementation

Create a class that implements `IReality` (usually by extending `RealityBase`), define its `Name` and `MetaphysicalAssumptions`, then register it in `RealityFactory.AvailableModels` and `RealityFactory.Create`. Add it to `TheoryComparison` when appropriate and verify it with the smoke checks.

```csharp
public sealed class AnotherReality : RealityBase
{
    public AnotherReality(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
        : base(physics, cosmos, chemistry, evolution, knowledge) { }

    public override string Name => "Another hypothesis";
    public override IReadOnlyList<string> MetaphysicalAssumptions => new[]
    {
        "An explicitly labeled assumption to examine."
    };
}
```

## Scientific and philosophical limits

- The physical and biological models are educational summaries, not numerical simulations of the universe or biology.
- The four implementations reuse the same observable scientific timeline. Selecting an ontology does **not** change the experimentally established results.
- Panpsychism, physicalism, idealism and dualism are philosophical views, not empirically confirmed runtime implementations.
- The evolution example is a simplistic inherited-trait model, not a real genome or ecosystem.
- Subjective consciousness, quantum gravity, dark matter, dark energy, and abiogenesis include substantial unanswered questions of different kinds.
- The panpsychist combination problem is deliberately unresolved; combining C# objects would not demonstrate unified subjective experience.
- Conservation laws in curved spacetime require care; global energy conservation is not always defined.

## Verification

Package-free smoke checks test the four implementations' substitutability, their shared observable chronology, the theory registry, invalid model handling, physics boundaries, toy evolution invariants, and the explicitly unresolved combination problem. GitHub Actions builds the .NET 8 project and runs the checks on pull requests.

**Physics describes the API. Philosophy questions the architecture. Consciousness is the runtime asking how the runtime works.**
