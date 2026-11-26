using Reality.Core.Epistemology;

namespace Reality.Core.Observation.Interfaces;

/// <summary>An observer's accessible operations, without assuming how consciousness is implemented.</summary>
public interface IObserver
{
    string Reflect();
    IReadOnlyList<Finding> DoScience();
}
