using Reality.Philosophy.Models;

namespace Reality.Investigation.Comparison;

/// <summary>Arguments associated with a named theory, without a score or verdict.</summary>
public sealed record TheoryDebateReview(string TheoryName, IReadOnlyList<TheoryDebate> Debates);
