using Reality.Core.Consciousness;
using Reality.Core.Epistemology;
using Reality.Core.Observation;
using Reality.Science.Epistemology;
using Reality.Science.Physics;


namespace Reality.Science.Consciousness;

/// <summary>
/// An illustrative human observer with both first-person experience and
/// reflective capabilities. The interface combination does not explain
/// phenomenal unity, establish that reflection is required for experience,
/// or demonstrate that this software has subjective experience.
/// </summary>
public sealed class HumanConsciousness : IUnifiedConsciousness, IObserver
{
    private readonly KnownPhysics _physics;
    private readonly ScientificCatalog _catalog;
    private readonly NervousSystem _nervousSystem;

    internal HumanConsciousness(KnownPhysics physics, ScientificCatalog catalog, NervousSystem nervousSystem)
    {
        _physics = physics;
        _catalog = catalog;
        _nervousSystem = nervousSystem;
    }

    // Experiential description belongs to IExperience; reflection belongs to IObserver.
    public string FirstPersonDescription => "Something it is like to experience; known firsthand, not reduced to this string.";
    public string Experience() => FirstPersonDescription;
    public string Reflect() => "I am a model-building observer embedded within the reality I study.";

    public IReadOnlyList<Finding> DoScience()
    {
        _nervousSystem.Remember("Scientific models are revisable.");
        return _catalog.Findings;
    }

    public IReadOnlyList<string> DoPhilosophy() => [
        "Why does anything exist?",
        "Are physical laws governing rules or descriptions?",
        "Is subjective experience fundamental, emergent, or something else?",
        "What could count as evidence for different metaphysical accounts?",
        "How can experience be unified, and does the answer depend on an ontology?",
        "Can an observer fully model the system that produced it?"
    ];

    public string UnderstandReality() =>
        $"{Reflect()} I can investigate {_physics.Principles.Count} summarized physical principles, but not inspect reality's source.";
}
