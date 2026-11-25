using Reality.Philosophy;

namespace Reality.Consciousness;

public interface IExperience
{
    string FirstPersonDescription { get; }
}

public interface IUnifiedConsciousness : IExperience
{
    string Reflect();
}

public sealed record FundamentalExperience(string FirstPersonDescription) : IExperience
{
    // This is a hypothetical object under panpsychism, not a detected entity.
}

public sealed class HumanConsciousness : IUnifiedConsciousness
{
    private readonly IReality _world;
    private readonly ScientificCatalog _catalog;
    private readonly INervousSystem _nervousSystem;

    internal HumanConsciousness(IReality world, ScientificCatalog catalog, INervousSystem nervousSystem)
    {
        _world = world;
        _catalog = catalog;
        _nervousSystem = nervousSystem;
    }

    public string FirstPersonDescription => "Something it is like to experience; known firsthand, not reduced to this string.";
    public string Experience() => FirstPersonDescription;
    public string Reflect() => "I am a model-building observer embedded within the reality I study.";

    public IReadOnlyList<Finding> DoScience()
    {
        _nervousSystem.Remember("Scientific models are revisable.");
        return _catalog.Findings;
    }

    public IReadOnlyList<string> DoPhilosophy() => new[]
    {
        "Why does anything exist?",
        "Are physical laws governing rules or descriptions?",
        "Is subjective experience fundamental, emergent, or something else?",
        "What could count as evidence for different metaphysical accounts?",
        "How could multiple minimal experiences form a single subject?",
        "Can an observer fully model the system that produced it?"
    };

    public string UnderstandReality() =>
        $"{Reflect()} I can test {_world.Physics.Principles.Count} summarized physical principles, but not inspect reality's source.";
}

public static class CombinationProblem
{
    public static IUnifiedConsciousness Combine(IEnumerable<IExperience> experiences)
    {
        ArgumentNullException.ThrowIfNull(experiences);
        // TODO: Discover the actual implementation, IF combination is possible.
        // Merely aggregating objects cannot establish a unified subjective subject.
        throw new NotSupportedException("Combination problem unresolved: source code unavailable.");
    }
}
