using Reality.Core.Epistemology;
using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Models;


namespace Reality.Philosophy.Theories;

public sealed class PhysicalistTheory : ITheoryOfReality
{
    public string Name => "Physicalism";
    public string CoreClaim => "All facts are physical or wholly fixed by physical facts.";
    public IReadOnlyList<Assumption> Assumptions { get; } = [
        new Assumption("The physical facts exhaust or determine all the facts."),
        new Assumption("An additional nonphysical substance is not required."),
        new Assumption("The view may be reductive or nonreductive; this example does not choose.")
    ];
    public IReadOnlyList<Explanation> Explanations { get; } = [
        new Explanation("Neural correlates", "Interprets neural dependence as consistent with mental states being physical or physically fixed."),
        new Explanation("Subjective experience", "Locates any account of first-person experience within the physical domain; the explanatory question remains.")
    ];
    public IReadOnlyList<OpenQuestion> OpenQuestions { get; } = [
        new OpenQuestion("How should phenomenal character be related to physical descriptions?"),
        new OpenQuestion("Which version of physicalism is being defended?"),
        new OpenQuestion("What evidence could discriminate physicalist variants from alternatives?")
    ];
    public IReadOnlyList<Prediction> Predictions { get; } = [];
    /// <summary>Variant-specific objections and possible replies; neither is a verdict.</summary>
    public IReadOnlyList<TheoryDebate> Debates { get; } = [
        new TheoryDebate("knowledge-argument",
            "Physicalism; especially reductive accounts",
            "The knowledge argument asks whether complete physical information can leave out knowledge of what an experience is like.",
            "Some physicalists distinguish learning a new phenomenal concept or ability from discovering an additional nonphysical fact.",
            "Can that response explain the apparent epistemic gap without assuming the metaphysical conclusion?",
            "https://plato.stanford.edu/entries/qualia-knowledge/"),
        new TheoryDebate("phenomenal-explanation",
            "Physicalist accounts of phenomenal character",
            "Descriptions of neural or functional mechanisms may not by themselves explain why those mechanisms have a first-person character.",
            "Nonreductive and a posteriori physicalists dispute whether explanatory derivability is required for physical determination.",
            "Which specific physicalist account explains the relationship and what would distinguish it from rival interpretations?",
            "https://plato.stanford.edu/entries/physicalism/")
    ];

}
