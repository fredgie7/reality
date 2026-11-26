using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
using Reality.Emergence;
using Reality.Physics;

namespace Reality;

/// <summary>
/// A conceptual model of the universe we observe, not a necessary definition
/// of existence. Toy educational models remain concrete until a genuine
/// common abstraction is needed.
/// </summary>
public sealed class ObservedUniverse : IObservableUniverse
{
    private readonly CosmicHistory _cosmos;
    private readonly ChemistryModel _chemistry;

    public ObservedUniverse(KnownPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, DarwinianEvolution evolution, ScientificCatalog knowledge)
    {
        Physics = physics;
        _cosmos = cosmos;
        _chemistry = chemistry;
        Evolution = evolution;
        Knowledge = knowledge;
        Spacetime = new Spacetime();
        Genetics = new Genetics();
        Emergence = new EmergenceModel();
        Culture = new CulturalEvolution();
        NervousSystem = new NervousSystem();
    }

    public KnownPhysics Physics { get; }
    public Spacetime Spacetime { get; }
    public DarwinianEvolution Evolution { get; }
    public Genetics Genetics { get; }
    public EmergenceModel Emergence { get; }
    public CulturalEvolution Culture { get; }
    public NervousSystem NervousSystem { get; }
    public ScientificCatalog Knowledge { get; }

    public IReadOnlyList<Event> DescribeHistory()
    {
        // Conceptual chronology, not a numerical simulation or causal proof.
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

    public HumanConsciousness CreateObserver() => new(Physics, Knowledge, NervousSystem);
}
