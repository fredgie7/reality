using Reality.Philosophy.Interfaces;

namespace Reality.Investigation.Comparison;

/// <summary>
/// Validates the structure and references of curated debates, not their logical soundness.
/// A possible reply is never evidence that an objection has been resolved.
/// </summary>
public sealed class TheoryDebateService
{
    public static IReadOnlyList<TheoryDebateReview> Review(IEnumerable<ITheoryOfReality> theories)
    {
        ArgumentNullException.ThrowIfNull(theories);
        return theories.Select(theory =>
        {
            ArgumentNullException.ThrowIfNull(theory);
            var debates = theory.Debates.ToArray();
            if (debates.Any(debate => debate is null || string.IsNullOrWhiteSpace(debate.Id) || string.IsNullOrWhiteSpace(debate.VariantScope) || string.IsNullOrWhiteSpace(debate.Objection) || string.IsNullOrWhiteSpace(debate.PossibleResponse) || string.IsNullOrWhiteSpace(debate.RemainingQuestion) || !Uri.TryCreate(debate.SourceUrl, UriKind.Absolute, out var url) || url.Scheme != Uri.UriSchemeHttps))
                throw new ArgumentException($"Theory '{theory.Name}' contains an incomplete or unsourced debate.", nameof(theories));
            if (debates.Select(debate => debate.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count() != debates.Length)
                throw new ArgumentException($"Theory '{theory.Name}' contains duplicate debate IDs.", nameof(theories));
            return new TheoryDebateReview(theory.Name, debates);
        }).ToArray();
    }
}
