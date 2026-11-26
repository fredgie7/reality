using Reality.Core.Epistemology;
using Reality.Core.Observation;
using Reality.Core.Observation.Interfaces;
using Reality.Science.Biology;
using Reality.Science.Consciousness;
using Reality.Science.Culture;
using Reality.Science.Emergence;
using Reality.Science.Epistemology;
using Reality.Science.Physics;


namespace Reality.Science.Observation;

/// <summary>
/// A conceptual model of the universe we observe, not a necessary definition
/// of existence. Toy educational models remain concrete until a genuine
/// common abstraction is needed.
/// </summary>
public sealed class ObservedUniverse(KnownPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, DarwinianEvolution evolution, ScientificCatalog knowledge) : IObservableUniverse
{
    private readonly CosmicHistory _cosmos = cosmos;
    private readonly ChemistryModel _chemistry = chemistry;

    public KnownPhysics Physics { get; } = physics;
    public Spacetime Spacetime { get; } = new();
    public DarwinianEvolution Evolution { get; } = evolution;
    public Genetics Genetics { get; } = new();
    public EmergenceModel Emergence { get; } = new();
    public CulturalEvolution Culture { get; } = new();
    public NervousSystem NervousSystem { get; } = new();
    public ScientificCatalog Knowledge { get; } = knowledge;
    public IReadOnlyList<Finding> Findings => Knowledge.Findings;

    public IReadOnlyList<Event> DescribeHistory()
    {
        // Conceptual chronology, not a numerical simulation or causal proof.
        return _cosmos.Events.Concat(_chemistry.Events)
            .Concat(
            [
                new Event("Biology", "Origin of replicating life: unresolved history; evolution requires heredity."),
                new Event("Genetics", "Heritable genetic information propagates through cellular machinery, with variation."),
                new Event("Evolution", "Populations diversify through mutation, selection, drift and gene flow."),
                new Event("Emergence", "Interactions among components give rise to collective properties."),
                new Event("Neuroscience", "Some lineages evolve nervous systems supporting learning and cognition."),
                new Event("Culture", "Social learning transmits knowledge beyond genetic inheritance."),
                new Event("Consciousness", "Human observers begin modeling the system that produced them.")
            ]).ToArray();
    }

    public IObserver CreateObserver() => new HumanConsciousness(Physics, Knowledge, NervousSystem);
}
