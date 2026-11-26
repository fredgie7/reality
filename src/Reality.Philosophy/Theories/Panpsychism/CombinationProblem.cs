using Reality.Core.Consciousness.Interfaces;
using Reality.Core.Ontology.Interfaces;


namespace Reality.Philosophy.Theories.Panpsychism;

/// <summary>
/// A panpsychism-specific open problem, not a requirement of every IReality.
/// </summary>
public static class CombinationProblem
{
    public static IUnifiedConsciousness Combine(IEnumerable<IExperience> experiences)
    {
        ArgumentNullException.ThrowIfNull(experiences);
        // TODO: Discover the implementation, if combination is possible.
        // Aggregating objects does not establish a unified subjective subject.
        throw new NotSupportedException("The panpsychist combination problem remains unresolved.");
    }
}

