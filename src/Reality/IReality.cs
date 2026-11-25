using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
using Reality.Emergence;
using Reality.Physics;

namespace Reality;

/// <summary>
/// A possible implementation of reality. Shared observable models are dependencies;
/// metaphysical assumptions belong to the implementation, not this contract.
/// </summary>
public interface IReality
{
    string Name { get; }
    IReadOnlyList<string> MetaphysicalAssumptions { get; }
    ILawsOfPhysics Physics { get; }
    ISpacetime Spacetime { get; }
    IBiologicalEvolution Evolution { get; }
    IGenetics Genetics { get; }
    IEmergence Emergence { get; }
    ICulturalEvolution Culture { get; }
    INervousSystem NervousSystem { get; }
    IReadOnlyList<Event> Evolve();
    HumanConsciousness CreateObserver();
}
