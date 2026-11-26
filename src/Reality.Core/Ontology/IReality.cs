using Reality.Core.Observation;

namespace Reality.Core.Ontology;

/// <summary>
/// The underlying reality, whose full implementation is not available to an observer.
/// It exposes only an observable facet. This repository does not claim to instantiate it.
/// </summary>
public interface IReality
{
    IObservableUniverse ObservableUniverse { get; }
}
