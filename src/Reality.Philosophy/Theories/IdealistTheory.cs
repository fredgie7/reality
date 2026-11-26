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
}
