using Reality.Core.Epistemology;
using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Models;


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
    /// <summary>Variant-specific objections and possible replies; neither is a verdict.</summary>
    public IReadOnlyList<TheoryDebate> Debates { get; } = [
        new TheoryDebate("interaction",
            "Interactionist substance dualism",
            "If mental and physical substances are fundamentally different, how can they causally affect each other?",
            "Interactionists argue that causation need not be pictured as physical contact between like substances.",
            "What positive account specifies the interaction and its observable consequences?",
            "https://plato.stanford.edu/entries/dualism/"),
        new TheoryDebate("physical-closure",
            "Interactionist substance dualism; not all dualist positions",
            "Nonphysical causes of bodily events appear to challenge physical causal closure and some interpretations of conservation laws.",
            "A dualist can question whether the relevant physical systems are causally closed; this does not establish an interaction mechanism.",
            "How would the proposed influence fit the full body of experimental constraints without an unsupported exception?",
            "https://plato.stanford.edu/entries/dualism/")
    ];

}
