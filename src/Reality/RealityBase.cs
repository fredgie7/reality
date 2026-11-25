using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
using Reality.Emergence;
using Reality.Physics;

namespace Reality;

/// <summary>
/// Reusable observable models, independent of the selected ontology.
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
        Spacetime = new Spacetime();
        Genetics = new Genetics();
        Emergence = new EmergenceModel();
        Culture = new CulturalEvolution();
        NervousSystem = new NervousSystem();
    }

    public abstract string Name { get; }
    public abstract IReadOnlyList<string> MetaphysicalAssumptions { get; }
    public ILawsOfPhysics Physics { get; }
    public ISpacetime Spacetime { get; }
    public IBiologicalEvolution Evolution { get; }
    public IGenetics Genetics { get; }
    public IEmergence Emergence { get; }
    public ICulturalEvolution Culture { get; }
    public INervousSystem NervousSystem { get; }

    public virtual IReadOnlyList<Event> Evolve()
    {
        // Conceptual chronology, NOT a numerical simulation.
        // Some processes overlap; changing metaphysics does not change empirical history.
        return _cosmos.Events.Concat(_chemistry.Events)
            .Concat(new[]
            {
                new Event("Biology", "Origin of replicating life: unresolved history; evolution requires heredity."),
                new Event("Genetics", "Heritable genetic information propagates through cellular machinery, with variation."),
                new Event("Evolution", "Populations diversify through mutation, selection, drift and gene flow."),
                new Event("Emergence", "Interactions among components give rise to collective properties."),
                new Event("Neuroscience", "Some lineages evolve nervous systems supporting learning and cognition."),
                new Event("Culture", "Social learning transmits knowledge beyond genetic inheritance."),
                new Event("Consciousness", "Human observers begin modeling the system that produced them.")
            }).ToArray();
    }

    public virtual HumanConsciousness CreateObserver() => new(this, _knowledge, NervousSystem);
}
