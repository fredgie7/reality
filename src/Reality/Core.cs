using Reality.Biology;
using Reality.Consciousness;
using Reality.Physics;

namespace Reality;

public enum EvidenceStatus
{
    EstablishedModel,
    Observed,
    ActiveResearch,
    PhilosophicalHypothesis,
    OpenQuestion
}

public sealed record Finding(string Subject, string Description, EvidenceStatus Confidence);
public sealed record Event(string Domain, string Description);

/// <summary>
/// A possible implementation of reality. Shared observable models are dependencies;
/// metaphysical assumptions belong to the implementation, not this contract.
/// </summary>
public interface IReality
{
    string Name { get; }
    IReadOnlyList<string> MetaphysicalAssumptions { get; }
    ILawsOfPhysics Physics { get; }
    IBiologicalEvolution Evolution { get; }
    IReadOnlyList<Event> Evolve();
    HumanConsciousness CreateObserver();
}

public sealed class ScientificCatalog
{
    private readonly IReadOnlyList<Finding> _findings;
    public ScientificCatalog(IEnumerable<Finding> findings) => _findings = findings.ToArray();
    public IReadOnlyList<Finding> Findings => _findings;

    public static ScientificCatalog Create() => new(new[]
    {
        new Finding("General relativity", "Describes gravity through spacetime geometry.", EvidenceStatus.EstablishedModel),
        new Finding("Quantum mechanics", "Highly predictive framework for microscopic phenomena.", EvidenceStatus.EstablishedModel),
        new Finding("Standard Model", "Describes known elementary particles and electromagnetic, weak and strong interactions.", EvidenceStatus.EstablishedModel),
        new Finding("Thermodynamics", "Isolated macroscopic systems overwhelmingly tend toward higher entropy.", EvidenceStatus.EstablishedModel),
        new Finding("Cosmic expansion", "Cosmological observations support an expanding universe.", EvidenceStatus.Observed),
        new Finding("Dark matter", "Multiple gravitational observations point to unexplained mass or a missing account of gravity.", EvidenceStatus.ActiveResearch),
        new Finding("Dark energy", "Expansion accelerates; the responsible physics is unsettled.", EvidenceStatus.ActiveResearch),
        new Finding("Origin of life", "Abiogenesis pathways remain active research.", EvidenceStatus.ActiveResearch),
        new Finding("Evolution", "Mutation, selection, drift and gene flow change populations over generations.", EvidenceStatus.EstablishedModel),
        new Finding("Neural correlates", "Neural activity systematically relates to reported conscious states.", EvidenceStatus.Observed),
        new Finding("Subjective experience", "Why experience accompanies physical processes remains debated.", EvidenceStatus.OpenQuestion)
    });
}

/// <summary>
/// Reusable physical chronology and observer construction. Does not choose an ontology.
/// Subclasses supply their own metaphysical hypotheses without replacing shared science.
/// </summary>
public abstract class RealityBase : IReality
{
    private readonly CosmicHistory _cosmos;
    private readonly ChemistryModel _chemistry;
    private readonly ScientificCatalog _knowledge;

    protected RealityBase(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
    {
        Physics = physics;
        _cosmos = cosmos;
        _chemistry = chemistry;
        Evolution = evolution;
        _knowledge = knowledge;
    }

    public abstract string Name { get; }
    public abstract IReadOnlyList<string> MetaphysicalAssumptions { get; }
    public ILawsOfPhysics Physics { get; }
    public IBiologicalEvolution Evolution { get; }

    public virtual IReadOnlyList<Event> Evolve()
    {
        // Conceptual chronology, NOT a numerical simulation.
        // The observable history does not change merely because we change metaphysics.
        return _cosmos.Events.Concat(_chemistry.Events)
            .Concat(new[]
            {
                new Event("Biology", "Origin of replicating life: unresolved history; evolution requires heredity."),
                new Event("Evolution", "Populations diversify through mutation, selection, drift and gene flow."),
                new Event("Neuroscience", "Some lineages evolve nervous systems supporting learning and cognition."),
                new Event("Consciousness", "Human observers begin modeling the system that produced them.")
            }).ToArray();
    }

    public virtual HumanConsciousness CreateObserver() => new(this, _knowledge, new NervousSystem());
}
