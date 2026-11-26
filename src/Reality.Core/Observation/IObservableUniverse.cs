using Reality.Core.Epistemology;
using Reality.Core.Observation;

namespace Reality.Core.Observation;

/// <summary>
/// A revisable description of observable phenomena, not the totality of existence.
/// </summary>
public interface IObservableUniverse
{
    IReadOnlyList<Finding> Findings { get; }
    IReadOnlyList<Event> DescribeHistory();
    IObserver CreateObserver();
}
