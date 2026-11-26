using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Models;


namespace Reality.Philosophy.Theories;

public sealed class IdealistTheory : ITheoryOfReality
{
    public string Name => "Idealism";
    public string CoreClaim => "Mind or experience is metaphysically fundamental.";
    public IReadOnlyList<Assumption> Assumptions { get; } = [
        new Assumption("Mind, experience, or a mental structure is fundamental."),
        new Assumption("The physical domain is understood through that underlying mental reality."),
        new Assumption("The common world is not simply invented by any individual's mind.")
    ];
    public IReadOnlyList<Explanation> Explanations { get; } = [
        new Explanation("Subjective experience", "Treats experience as metaphysically basic, not as a solved scientific derivation."),
        new Explanation("Cosmic expansion", "Must accommodate the same intersubjectively observed cosmology and mathematical regularities.")
    ];
    public IReadOnlyList<OpenQuestion> OpenQuestions { get; } = [
        new OpenQuestion("What secures the stability of a shared world?"),
        new OpenQuestion("How are individual subjects related to the proposed underlying mind?"),
        new OpenQuestion("Which version of idealism, if any, generates distinctive observations?")
    ];
    public IReadOnlyList<Prediction> Predictions { get; } = [];
    /// <summary>Variant-specific objections and possible replies; neither is a verdict.</summary>
    public IReadOnlyList<TheoryDebate> Debates { get; } = [
        new TheoryDebate("shared-world",
            "Metaphysical idealism; not every version makes the same commitments",
            "How does a fundamentally mental reality explain a stable, shared empirical world that is not controlled by any one observer?",
            "Some idealist accounts distinguish individual minds from an order or structure that is not dependent on an individual person's choices.",
            "What constitutes that common order, and why do different observers encounter consistent regularities?",
            "https://plato.stanford.edu/entries/idealism/"),
        new TheoryDebate("objective-regularities",
            "Metaphysical idealism",
            "The objective success of mathematical physics calls for an account of regularities that persist independently of individual observations.",
            "An idealist may treat those regularities as features of an underlying mental order rather than inventions of finite human minds.",
            "Can a specified idealist variant explain the detailed regularities without merely restating them?",
            "https://plato.stanford.edu/entries/idealism/")
    ];

}
