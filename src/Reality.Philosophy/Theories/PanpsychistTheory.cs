using Reality.Core.Epistemology;
using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Models;


namespace Reality.Philosophy.Theories;

/// <summary>One broad family of panpsychist hypotheses, not an established fact.</summary>
public sealed class PanpsychistTheory : ITheoryOfReality
{
    public string Name => "Panpsychism";
    public string CoreClaim => "At least some fundamental physical entities have intrinsic experiential aspects.";
    public IReadOnlyList<Assumption> Assumptions { get; } = [
        new Assumption("Fundamental physical entities may have experiential aspects."),
        new Assumption("Those aspects are not adequately captured by an exclusively structural description."),
        new Assumption("Any relation to unified human experience requires a separate account.")
    ];
    public IReadOnlyList<Explanation> Explanations { get; } = [
        new Explanation("Subjective experience", "Proposes that experiential aspects are basic, without deriving human subjectivity or solving combination."),
        new Explanation("Neural correlates", "Allows neural organization to shape conscious states; does not uniquely predict observed correlations.")
    ];
    public IReadOnlyList<OpenQuestion> OpenQuestions { get; } = [
        new OpenQuestion("Do fundamental entities possess experiential aspects?"),
        new OpenQuestion("How, if at all, do such aspects relate to unified subjects? (Combination problem)"),
        new OpenQuestion("Can any version yield a genuinely distinguishing empirical test?")
    ];
    public IReadOnlyList<Prediction> Predictions { get; } = [];
    /// <summary>Variant-specific objections and possible replies; neither is a verdict.</summary>
    public IReadOnlyList<TheoryDebate> Debates { get; } = [
        new TheoryDebate("subject-combination",
            "Constitutive micropsychism",
            "How could many micro-level subjects jointly constitute a single macro-level subject?",
            "Non-constitutive forms of panpsychism need not posit that macro-subjects are constituted by micro-subjects; they face different explanatory demands.",
            "What explains human unity on the selected panpsychist variant, without merely changing the location of the problem?",
            "https://plato.stanford.edu/entries/panpsychism/"),
        new TheoryDebate("cosmopsychism",
            "Constitutive cosmopsychism",
            "Beginning with one cosmic subject may reverse the traditional combination problem but raises the problem of individual subjects.",
            "Cosmopsychist accounts propose that individual subjects are grounded in a cosmic subject rather than built by summing micro-subjects.",
            "How do distinct individual perspectives arise from or depend on an encompassing cosmic subject?",
            "https://plato.stanford.edu/entries/panpsychism/supplement.html")
    ];


}
