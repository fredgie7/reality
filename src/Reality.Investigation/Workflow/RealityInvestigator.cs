using Reality.Core.Epistemology;
using Reality.Core.Observation;
using Reality.Investigation.Comparison;
using Reality.Investigation.Experiments;
using Reality.Investigation.Reasoning;
using Reality.Philosophy.Interfaces;
using Reality.Science.Epistemology;

namespace Reality.Investigation.Workflow;

/// <summary>Coordinates investigation without turning scientific reports into a metaphysical verdict.</summary>
public sealed class RealityInvestigator(IObservableUniverse universe, IReadOnlyList<ITheoryOfReality> theories, ScientificCatalog catalog)
{
    public InvestigationReport InvestigateConsciousness()
    {
        var findings = universe.Findings.Where(finding => finding.Subject == FindingSubjects.NeuralCorrelates || finding.Subject == FindingSubjects.SubjectiveExperience).ToArray();
        var comparisons = new TheoryComparisonService().Compare(theories, catalog);
        var debates = new TheoryDebateService().Review(theories);
        var experiment = new ExperimentReviewService().Review(ConsciousnessExperimentExample.Create());
        return new InvestigationReport("What can neural evidence tell us about consciousness?", findings, ConsciousnessReasoningExample.Create(), comparisons, debates, experiment);
    }
}
