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

public interface IReality
{
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
        new Finding("Subjective experience", "Why experience accompanies physical processes remains debated.", EvidenceStatus.OpenQuestion),
        new Finding("Panpsychism", "Experience is proposed to be fundamental and widespread.", EvidenceStatus.PhilosophicalHypothesis),
        new Finding("Combination problem", "How minimal subjects could constitute a unified subject remains unresolved.", EvidenceStatus.OpenQuestion)
    });
}

public sealed class PanpsychistReality : IReality
{
    private readonly CosmicHistory _cosmos;
    private readonly ChemistryModel _chemistry;
    private readonly ScientificCatalog _knowledge;

    public PanpsychistReality(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
    {
        Physics = physics;
        _cosmos = cosmos;
        _chemistry = chemistry;
        Evolution = evolution;
        _knowledge = knowledge;
    }

    public ILawsOfPhysics Physics { get; }
    public IBiologicalEvolution Evolution { get; }

    public IReadOnlyList<Event> Evolve()
    {
        // Conceptual chronology, NOT a numerical universe simulation.
        // Processes overlap, and biological evolution begins only after replicating life exists.
        return _cosmos.Events.Concat(_chemistry.Events)
            .Concat(new[]
            {
                new Event("Biology", "Origin of replicating life: unresolved history; evolution requires heredity."),
                new Event("Evolution", "Populations diversify through mutation, selection, drift and gene flow."),
                new Event("Neuroscience", "Some lineages evolve nervous systems supporting learning and cognition."),
                new Event("Consciousness", "Human observers begin modeling the system that produced them.")
            }).ToArray();
    }

    public HumanConsciousness CreateObserver() => new(this, _knowledge, new NervousSystem());

    // Panpsychism is the SELECTED philosophical model, not an empirical result.
    // TODO: Determine whether fundamental experience exists.
    // TODO: Discover how separate experiences could constitute one subject.
}
