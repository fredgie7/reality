# Reality — the universe is running in production

> Physics documents observable behavior. Philosophy questions the architecture. Consciousness is an instance running inside the system it is trying to understand. Source code unavailable.

**Reality** is an open-ended C# 12 / .NET 8 project for exploring **what reality is, how it behaves, and how different philosophical accounts might explain its underlying nature**.

Its architecture is **not committed to any ontology**. Scientific models of our observed universe are composed separately rather than required by the root ontology interface. Four implementations of `IReality` currently represent panpsychism, physicalism, idealism, and substance dualism. These are competing hypotheses, not confirmed implementations of existence.

This is an educational analogy, not a comprehensive physical, biological, or sociological simulator.

## Run

Requires the .NET 8 SDK and no third-party packages.

```bash
dotnet run --project src/Reality/Reality.csproj -- panpsychism
dotnet run --project src/Reality/Reality.csproj -- physicalism
dotnet run --project src/Reality/Reality.csproj -- idealism
dotnet run --project src/Reality/Reality.csproj -- substance-dualism
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

Without arguments, the console selects panpsychism as the historical starting example.

## Architecture

```text
IReality                       (minimal philosophical contract)
  ├── PanpsychistReality
  ├── PhysicalistReality
  ├── IdealistReality
  └── SubstanceDualistReality

ObservedUniverse               (separate shared scientific study)
  ├── KnownPhysics + Spacetime
  ├── Genetics + DarwinianEvolution
  ├── NervousSystem + HumanConsciousness
  ├── EmergenceModel
  ├── CulturalEvolution
  └── ScientificCatalog

IHolographicDuality            (independent physical-description research)
  └── CelestialHolography
```

`IReality` contains only a model's **name and explicit metaphysical assumptions**. It does not require physics, spacetime, genetics, biology, observers, or a timeline. `ObservedUniverse` separately composes the models used to investigate our empirically observed universe; all four candidate ontologies can be compared with that same observational model without inheriting scientific requirements.

The science modules describe **observable regularities and illustrative mechanisms**. The candidate reality classes contain **metaphysical assumptions** about what underlies them. Switching models must not silently change the observations.

## Shared subsystems

| Contract | Educational capability | Important limitation |
| --- | --- | --- |
| `IGenetics` | Replication, transcription, limited translation, recombination and point mutation | Tiny example codon dictionary; excludes most real cellular biology |
| `INervousSystem` | Perception, memory, learning, prediction, emotional arousal and behavioral decisions | String-based conceptual model, not a neural simulation |
| `IEmergence` | Detects a collective property in a small interacting system | Does not establish strong emergence or explain phenomenal experience |
| `ISpacetime` | Light-travel time, constant-speed special-relativistic time dilation, Schwarzschild radius | No general-purpose metric or cosmological solver |
| `ICulturalEvolution` | Stepwise diffusion of an idea across neighboring learners | Does not model real social networks, institutions or innovation |
| `IBiologicalEvolution` | Seeded trait inheritance with selection, mutation and drift | Not a genome, ecosystem, speciation or origin-of-life model |

These are deliberately **concrete educational models** composed by `ObservedUniverse`, not an artificial set of one-implementation interfaces. New contracts should be introduced only when multiple meaningful implementations share a substitutable behavior.

## Quick examples

```csharp
IReality reality = RealityFactory.Create("physicalism");
var observed = new ObservedUniverse(physics, cosmos, chemistry, evolution, knowledge);

string rna = observed.Genetics.Transcribe("ATGGGT");
string protein = observed.Genetics.Translate(rna);   // MG (illustrative codon table)
double properSeconds = observed.Spacetime.ProperTimeForMovingClock(10, KnownPhysics.SpeedOfLight * 0.6);
var connectivity = observed.Emergence.Analyze(new[] { true, true, false });
var diffusion = observed.Culture.Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false) }, 1);
string learning = observed.NervousSystem.Learn("something observed");
```

## Celestial holography: where does it fit?

The physics research program known as **celestial holography** does **not** constitute a fifth `IReality` implementation. Our existing ontologies (panpsychism, physicalism, idealism, substance dualism) concern what fundamentally exists; celestial holography concerns how **asymptotically flat scattering data** may be represented in a conformal basis.

```text
IReality                        Candidate ontology
  ├── PanpsychistReality
  ├── PhysicalistReality
  ├── IdealistReality
  └── SubstanceDualistReality
            |
            v
   Shared observable physics and scientific models
            |
            +-- IPhysicalDescription: FourDimensionalScatteringDescription
            |                     |
            |              IHolographicDuality
            |                     |
            +-- IPhysicalDescription: CelestialConformalDescription
```

The two `IPhysicalDescription` classes describe different mathematical viewpoints on certain scattering observables, **not two different universes**. `IHolographicDuality` represents a proposed relationship. `PhysicalDescriptionStudy` can study that correspondence alongside **any** `IReality` without modifying the ontology:

```csharp
IReality reality = RealityFactory.Create("idealism");
IHolographicDuality duality = new CelestialHolography();
Console.WriteLine(new PhysicalDescriptionStudy().Summarize(reality, duality));
```

### Interface design: capabilities, not implementations

`IHolographicDuality` is deliberately small. It exposes only the **name**, the two `IPhysicalDescription` viewpoints, the correspondence's research status, open questions, and a plain-language relationship description. No celestial-specific types or numeric methods appear in the interface.

```csharp
public interface IHolographicDuality
{
    string Name { get; }
    IPhysicalDescription Bulk { get; }
    IPhysicalDescription Boundary { get; }
    bool IsCompleteDualityEstablished { get; }
    IReadOnlyList<string> OpenQuestions { get; }
    string ExplainRelationship();
}
```

`CelestialHolography` independently adds `DemonstrateEnergyMellinTransform` and `ReconstructFullBulk` as **concrete-class capabilities**. Future AdS/CFT, dS/CFT, Kerr/CFT, JT gravity or higher-spin models will not have to fake celestial Mellin data or implement unsupported bulk-reconstruction methods merely to satisfy a shared contract. If genuinely common operations emerge later, we can introduce separate capability interfaces instead of expanding this one prematurely.

The numerical example intentionally computes **only** a trapezoidal, finite-energy, real-weight Mellin integral for toy scalar amplitude samples:

```csharp
var samples = new[]
{
    new EnergyAmplitudeSample(1, 1),
    new EnergyAmplitudeSample(2, 1),
    new EnergyAmplitudeSample(3, 1)
};
var result = duality.DemonstrateEnergyMellinTransform(samples, conformalDimension: 1);
// result.ApproximateValue == 2: integral of constant 1 over [1, 3].
```

This is **not** a multi-particle celestial scattering amplitude, a complete two-dimensional conformal field theory, or a proof of holographic quantum gravity. `ReconstructFullBulk()` deliberately throws `NotSupportedException`: full reconstruction remains an open research problem. The simplified transformation is a demonstrator for the Mellin *mathematical operation*, not a claimed derivation of the complete dictionary.

### Research background

- Pasterski, Shao, and Strominger (2017), [Flat space amplitudes and conformal symmetry of the celestial sphere](https://doi.org/10.1103/PhysRevD.96.065026).
- [Celestial holography: An asymptotic symmetry perspective](https://doi.org/10.1016/j.physrep.2024.04.003) (Physics Reports, 2024).
- Sleight and Taronna (2024), [Celestial Holography Revisited](https://doi.org/10.1103/PhysRevLett.133.241601).
- [Topics in celestial holography: A bottom-up perspective](https://doi.org/10.1016/j.physrep.2026.08.001) (Physics Reports, 2026).

**Our analogy:** `IReality` asks what the underlying implementation *is*. `IPhysicalDescription` asks how measurable behavior is mathematically *represented*. `IHolographicDuality` asks when two representations may encode corresponding information. A useful change of basis does not select an ontology.

## Candidate interpretations

| Implementation | Core proposal | Unresolved challenge |
| --- | --- | --- |
| `PanpsychistReality` | Experience is fundamental and widespread | How experiential aspects might compose unified awareness |
| `PhysicalistReality` | Mental facts are physical or fixed by physical facts | Explaining subjective experience from physical descriptions |
| `IdealistReality` | Mind or experience is metaphysically fundamental | Explaining the stable intersubjective world |
| `SubstanceDualistReality` | Mental and physical substances are distinct | Interaction and physical constraints |

Panpsychism-specific questions remain inside `Implementations/Panpsychism/`. Add more models via `RealityFactory` without altering the scientific catalog.

## Scientific and philosophical limits

- Physics and evolutionary biology are empirically well-supported, but our code is deliberately not a simulation of all their mechanisms.
- Some methods are conceptual demonstrations and do not imply that DNA literally executes code or that complex patterns entail consciousness.
- The DNA examples accept a coding-strand sequence and demonstrate only a small portion of the genetic code.
- Physical time dilation examples apply to idealized inertial motion; spacetime geometry in general relativity is far richer.
- Cultural diffusion examples do not establish that ideas evolve by exactly the same mechanisms as genes.
- Neither the project nor the scientific evidence selects a uniquely confirmed metaphysical implementation.

## Future TODOs

- More complete genetics, developmental biology, epigenetics and ecology
- Synaptic plasticity, richer predictive processing and learning systems
- Weak versus strong emergence and the explanatory gap
- General relativistic geometry, black holes and cosmological expansion
- Language, cumulative culture, science and institutional evolution
- A richer interface between comparative philosophy, research questions and empirical tests

## Verification

The dependency-free smoke-check console project validates the scientific modules, ontology substitutability, and the ability to implement `IReality` without constructing any scientific models. GitHub Actions builds and runs checks on feature-branch pushes and pull requests.

**The universe runs in production. We're a subsystem reverse-engineering its behavior while trying to discover its architecture. Source code unavailable.**

## Interface design: only shared capabilities

We removed toy-specific interfaces `IBiologicalEvolution`, `IGenetics`, `INervousSystem`, `IEmergence`, `ICulturalEvolution`, `ISpacetime`, and the unimplemented `IEvolutionaryProcesses`. Their concrete educational implementations and runnable demonstrations remain.

We retained `ILawsOfPhysics` for the common description of physical principles, but moved the `KnownPhysics`-specific local speed-of-light check off that interface. `IPhysicalDescription` and `IHolographicDuality` remain general descriptions, while `IExperience` and `IUnifiedConsciousness` capture distinct first-person/reflection capabilities. `ITheoryOfConsciousness` remains a descriptive theory contract.

No interface is required merely because a concrete class exists. A further interface should represent a demonstrated need for polymorphism, not the current toy implementation's public API.

The observable universe is the subject of our study, not the definition of all conceivable realities. TODO: Discover the actual implementation.
