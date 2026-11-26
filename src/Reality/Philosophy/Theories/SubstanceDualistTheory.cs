using Reality.Philosophy.Interfaces;

namespace Reality.Philosophy.Theories;

public sealed class SubstanceDualistTheory : ITheoryOfReality
{
    public string Name => "Substance dualism";
    public string CoreClaim => "Mental and physical substances are ontologically distinct.";
    public IReadOnlyList<Assumption> Assumptions { get; } = [
        new Assumption("Mental and physical substances are fundamentally different."),
        new Assumption("Consciousness is not identical to a purely physical substance."),
        new Assumption("The nature of interaction, if any, needs a specified model.")
    ];
    public IReadOnlyList<Explanation> Explanations { get; } = [
        new Explanation("Subjective experience", "Attributes experience to a distinct mental substance; this alone does not explain its structure."),
        new Explanation("Neural correlates", "Must account for correlations between mental and neural states, possibly through interaction or another relation.")
    ];
    public IReadOnlyList<OpenQuestion> OpenQuestions { get; } = [
        new OpenQuestion("Can mental and physical substances causally interact, and how?"),
        new OpenQuestion("How is the account consistent with well-tested physical constraints?"),
        new OpenQuestion("What result could distinguish the specific dualist model under consideration?")
    ];
    public IReadOnlyList<Prediction> Predictions { get; } = [];
}
