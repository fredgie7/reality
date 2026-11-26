namespace Reality.Philosophy;

/// <summary>
/// Descriptive comparison only; no objective score or posterior probability.
/// </summary>
public sealed record TheoryAssessment(
    string TheoryName,
    int StatedAssumptions,
    IReadOnlyList<Explanation> CatalogLinkedExplanations,
    IReadOnlyList<Explanation> UnmatchedExplanations,
    IReadOnlyList<Prediction> ProposedPredictions,
    IReadOnlyList<OpenQuestion> OpenQuestions);
