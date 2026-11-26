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

    // TODO: Discover the actual implementation. Source code unavailable.
}
