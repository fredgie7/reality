namespace Reality.Consciousness;

public interface IExperience
{
    string FirstPersonDescription { get; }
}

public interface IUnifiedConsciousness : IExperience
{
    string Reflect();
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
        "How can experience be unified, and does the answer depend on an ontology?",
        "Can an observer fully model the system that produced it?"
    };

    public string UnderstandReality() =>
        $"{Reflect()} I can investigate {_world.Physics.Principles.Count} summarized physical principles, but not inspect reality's source.";
}
