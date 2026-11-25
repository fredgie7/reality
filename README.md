# Reality — the universe is running in production

> Physics documents observable behavior. Philosophy questions the architecture. Consciousness is an instance running inside the system it is trying to understand. Source code unavailable.

**Reality** is an open-ended C# 12 / .NET 8 project for exploring **what reality is, how it behaves, and how different philosophical accounts might explain its underlying nature**.

It is deliberately **not committed to any single ontology**. We begin with `PanpsychistReality`, but this is just the *first proposed implementation* of `IReality`. Future implementations might explore physicalism, idealism, dualism, neutral monism, or entirely different frameworks. No one of them is presumed true because it happens to be the one we instantiate.

The code is an **educational, philosophical and scientific analogy**, not a literal universe simulator, a theory of everything or evidence for a particular metaphysical position.

## The idea

```csharp
IReality reality = new PanpsychistReality(physics, cosmos, chemistry, evolution, knowledge);

// Physics describes what the system demonstrably does.
// The implementation represents a possible explanation of what it is.
// TODO: Discover which implementation, if any, corresponds to reality.
```

The important distinction is between **observable scientific models**, which any viable interpretation must address, and **metaphysical assumptions**, which belong to each interpretation. A different `IReality` is not a different set of established observations.

## Getting started

Requires the .NET 8 SDK; there are no third-party dependencies.

```bash
dotnet run --project src/Reality/Reality.csproj
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

The console currently selects `PanpsychistReality` in `Program.cs`, solely as our starting example.

## Architecture

| Component | Responsibility |
| --- | --- |
| `IReality` | General contract for any candidate explanation of reality |
| `RealityBase` | Reusable, ontology-independent physics, cosmic chronology, evolution and observer setup |
| `Implementations/PanpsychistReality.cs` | First candidate ontology; all panpsychist assumptions live here |
| `Implementations/Panpsychism/CombinationProblem.cs` | Unresolved question specific to panpsychist interpretations |
| `ILawsOfPhysics` / `KnownPhysics` | Representative physical principles and outstanding scientific problems |
| `CosmicHistory` / `ChemistryModel` | Illustrative timeline from cosmology through chemistry |
| `IBiologicalEvolution` / `DarwinianEvolution` | Seeded toy model of inherited traits, selection, mutation and drift |
| `INervousSystem` / `HumanConsciousness` | Simplified cognition and an observer exploring its own origin |
| `ITheoryOfConsciousness` / `TheoryComparison` | Comparison of philosophical positions without endorsing one |
| `ScientificCatalog` | Shared observational and scientific claims with explicit epistemic status |

## How to add another reality

Create a class implementing `IReality`. In most cases, derive from `RealityBase` to reuse common scientific models, then provide your interpretation's own `Name` and `MetaphysicalAssumptions`. For example:

```csharp
public sealed class AnotherReality : RealityBase
{
    public AnotherReality(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
        : base(physics, cosmos, chemistry, evolution, knowledge) { }

    public override string Name => "Another proposed reality";
    public override IReadOnlyList<string> MetaphysicalAssumptions => new[]
    {
        "An explicitly labeled philosophical assumption to investigate."
    };
}
```

Then assign an instance of that class to the `IReality` variable in `Program.cs`. This changes the interpretation without changing the underlying empirical chronology. No additional implementation has been asserted as true or fully modeled.

## What is established, and what isn't?

- Physics and evolutionary biology are empirically supported scientific frameworks. The methods in this project are conceptual summaries rather than numerical implementations.
- Biological evolution acts on heritable variation across generations; it has no predetermined direction. Our fixed-size toy model is not a genome, ecology, speciation or origin-of-life simulation.
- The origin of life predates the biological evolution of already-reproducing populations and is an independent research question.
- Human neural processes are empirically investigated; the metaphysics of subjective experience remains controversial.
- Panpsychism, physicalism, idealism and dualism are philosophical positions, **not confirmed runtime classes**. They differ in commitments and should be evaluated critically.
- Physical conservation laws have contextual requirements; e.g., global energy need not be well-defined in arbitrary curved spacetime.

## Open questions

- Quantum gravity, quantum measurement, dark matter, dark energy and abiogenesis
- What subjective experience is and how it relates to neural activity
- Whether mind is fundamental, emergent, dual, or described by an as-yet-unimagined ontology
- Which assumptions have empirical consequences, and which might be observationally indistinguishable
- Whether physical laws govern reality or simply describe regularities
- Whether any observer inside the system can completely understand it
- For panpsychism specifically: whether minimal experience exists and, if so, how unified subjects could arise

## Engineering philosophy

**Prefer composition over ontological inheritance.** `IReality` *has* an `ILawsOfPhysics` dependency rather than deriving from it. The science modules should not make philosophical decisions. The ontology modules should not rewrite established observations to suit their hypotheses.

Keep uncertain ideas visibly uncertain. A `TODO` is a question, not a scientific discovery.

## Verification

A package-free smoke-check project validates physics boundary cases, basic evolutionary invariants, the shared chronology, and **substitutability of two independent `IReality` implementations**. GitHub Actions builds and runs the smoke checks for pull requests.

The universe is running in production. We have good API documentation for many behaviors. We're still debating the architecture — and the source code is unavailable.
