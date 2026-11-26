using Reality.Philosophy.Models;

namespace Reality.Investigation.Comparison;

/// <summary>
/// Topic-name matching only; not evidential support, explanatory success, an objective score, or a posterior probability.
/// </summary>
public sealed record TheoryAssessment(
    string TheoryName,
    int StatedAssumptions,
    IReadOnlyList<Explanation> TopicMatchedExplanations,
    IReadOnlyList<Explanation> UnmatchedTopicExplanations,
    IReadOnlyList<Prediction> ProposedPredictions,
    IReadOnlyList<OpenQuestion> OpenQuestions);
