using Reality.Philosophy.Models;

namespace Reality.Philosophy.Interfaces;

/// <summary>
/// A proposed metaphysical explanation of the same observable world.
/// Neither compatibility nor explanatory claims imply empirical confirmation.
/// </summary>
public interface ITheoryOfReality
{
    string Name { get; }
    string CoreClaim { get; }
    IReadOnlyList<Assumption> Assumptions { get; }
    IReadOnlyList<Explanation> Explanations { get; }
    IReadOnlyList<OpenQuestion> OpenQuestions { get; }
    IReadOnlyList<Prediction> Predictions { get; }
    IReadOnlyList<TheoryDebate> Debates { get; }
}
