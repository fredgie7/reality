# Reality — the universe is running in production

> Physics documents the observable API. Philosophy asks what implements it. Consciousness is a system process investigating the system. Source code unavailable.

A .NET 8 / C# 12 educational exploration of **how observers within reality build scientific models and compare different accounts of what reality fundamentally is**.

## The central design choice

**One observable universe; multiple interpretations.** `IReality` describes an actual reality whose source code is unavailable and whose *observable facet* is `IObservableUniverse`. We do **not** claim to instantiate the actual `IReality`. `ObservedUniverse` is an explicitly revisable conceptual model of empirical science, separate from `ITheoryOfReality`.

```text
IReality (unknown actual implementation)
  └── IObservableUniverse (observer-accessible facet)
        └── ObservedUniverse
              ├── Physics, spacetime, cosmology and chemistry
              ├── Biology, genetics and evolution
              ├── Neuroscience and human consciousness
              ├── Emergence and cultural evolution
              └── Celestial holography research example

ITheoryOfReality (philosophical accounts, never instances of IReality)
  ├── PanpsychistTheory
  ├── PhysicalistTheory
  ├── IdealistTheory
  └── SubstanceDualistTheory

TheoryCatalog → TheoryComparisonService → TheoryAssessment
ScientificCatalog → Findings + EvidenceStatus
```

The project's C# **file convention is strict**: every class, interface, enum and record gets its own file. Interfaces are separated into their domain's `Interfaces` folder, such as `Philosophy/Interfaces/ITheoryOfReality.cs` or `Physics/Holography/Interfaces/IHolographicDuality.cs`. Namespaces follow domains and are not unnecessarily deepened for the interface folder.

## Run

Requires .NET 8 SDK. No third-party packages.

```bash
dotnet run --project src/Reality/Reality.csproj
dotnet run --project src/Reality/Reality.csproj -- Physicalism
dotnet run --project src/Reality/Reality.csproj -- Idealism
dotnet run --project src/Reality/Reality.csproj -- "Substance dualism"
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

Without arguments, every registered theory is examined against the **same** scientific findings. Selecting a theory never changes physical observations.

## Evidence is not interpretation

- `Finding` and `EvidenceStatus` summarize scientific models, observations, open problems and active research.
- `Assumption` is something a philosophical theory proposes.
- `Explanation` links an interpretive claim to the subject of an actual scientific finding; this link is **not a demonstration that the theory explains it successfully**.
- `OpenQuestion` names a limitation or a question not yet resolved.
- `Prediction` and `PredictionTestability` allow an account to propose a possible empirical discriminator; the present broad theories have **none specified**.
- `TheoryComparisonService` produces structured inventories, **not** truth probabilities, scores, or rankings.

```csharp
IObservableUniverse observed = new ObservedUniverse(
    new KnownPhysics(), new CosmicHistory(), new ChemistryModel(),
    new DarwinianEvolution(42), ScientificCatalog.Create());

var assessments = new TheoryComparisonService().Compare(TheoryCatalog.All, observed.Knowledge);
```

## Preserved scientific demonstrations

The simplified DNA examples, inheritance and evolutionary selection, nervous-system strings, emergent boolean patterns, cultural diffusion, light travel and inertial time dilation, and conceptual cosmic history are useful **teaching examples**, not exhaustive simulations. The existing celestial holography study survives unchanged; its numerical Mellin transform is an illustrative real-valued quadrature, not a completed flat-space quantum-gravity duality.

## Extend the investigation

Implement `ITheoryOfReality` in `Philosophy/Theories/YourTheory.cs`, record assumptions, explanatory claims that refer to catalog subjects, open questions and any genuinely proposed predictions. Register it in `TheoryCatalog`; tests should verify the comparison. Do **not** modify `ObservedUniverse` merely to make the preferred metaphysics work.

Next meaningful directions include research provenance and citations, philosophical argument/objection maps, fine-grained versions of each broad ontology, and evaluating what could genuinely distinguish competing accounts.

## Test

CI builds the .NET 8 console and runs the smoke checks, covering scientific models, observer invariants, interpretation/evidence separation, comparisons, and holography.

**TODO: Discover the actual implementation. Source code unavailable.**
