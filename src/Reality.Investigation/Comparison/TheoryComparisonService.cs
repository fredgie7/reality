using Reality.Philosophy.Interfaces;
using Reality.Science.Epistemology;


namespace Reality.Investigation.Comparison;

/// <summary>
/// Compares claims against catalog identifiers without treating interpretation
/// as independent evidence. No scoring, truth ranking, or automatic validation.
/// </summary>
public sealed class TheoryComparisonService
{
    public IReadOnlyList<TheoryAssessment> Compare(IEnumerable<ITheoryOfReality> theories, ScientificCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(theories);
        ArgumentNullException.ThrowIfNull(catalog);
        var subjects = catalog.Findings.Select(x => x.Subject).ToHashSet(StringComparer.OrdinalIgnoreCase);

        return theories.Select(theory =>
        {
            ArgumentNullException.ThrowIfNull(theory);
            var linked = theory.Explanations.Where(x => subjects.Contains(x.FindingSubject)).ToArray();
            var unmatched = theory.Explanations.Where(x => !subjects.Contains(x.FindingSubject)).ToArray();
            return new TheoryAssessment(theory.Name, theory.Assumptions.Count, linked, unmatched, theory.Predictions.ToArray(), theory.OpenQuestions.ToArray());
        }).ToArray();
    }
}
