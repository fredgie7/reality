using Reality.Philosophy.Interfaces;

namespace Reality.Philosophy.Theories;

public sealed class PhysicalistTheory : ITheoryOfReality
{
    public string Name => "Physicalism";
    public string CoreClaim => "All facts are physical or wholly fixed by physical facts.";
    public IReadOnlyList<Assumption> Assumptions { get; } = new[]
    {
        new Assumption("The physical facts exhaust or determine all the facts."),
        new Assumption("An additional nonphysical substance is not required."),
        new Assumption("The view may be reductive or nonreductive; this example does not choose.")
    };
    public IReadOnlyList<Explanation> Explanations { get; } = new[]
    {
        new Explanation("Neural correlates", "Interprets neural dependence as consistent with mental states being physical or physically fixed."),
        new Explanation("Subjective experience", "Locates any account of first-person experience within the physical domain; the explanatory question remains.")
    };
    public IReadOnlyList<OpenQuestion> OpenQuestions { get; } = new[]
    {
        new OpenQuestion("How should phenomenal character be related to physical descriptions?"),
        new OpenQuestion("Which version of physicalism is being defended?"),
        new OpenQuestion("What evidence could discriminate physicalist variants from alternatives?")
    };
    public IReadOnlyList<Prediction> Predictions { get; } = Array.Empty<Prediction>();
}
