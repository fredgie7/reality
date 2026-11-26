using Reality.Consciousness;

namespace Reality;

/// <summary>
/// A revisable description of observable phenomena, not the totality of existence.
/// </summary>
public interface IObservableUniverse
{
    ScientificCatalog Knowledge { get; }
    IReadOnlyList<Event> DescribeHistory();
    HumanConsciousness CreateObserver();
}
