namespace Reality.Philosophy.Models;

/// <summary>
/// A sourced philosophical objection, a possible response, and an outstanding question.
/// This is a map of arguments, not an empirical verdict or endorsement of a variant.
/// </summary>
public sealed record TheoryDebate(string Id, string VariantScope, string Objection, string PossibleResponse, string RemainingQuestion, string SourceUrl);
