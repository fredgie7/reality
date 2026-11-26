using Reality.Philosophy.Models;

namespace Reality.Investigation.Reasoning;

/// <summary>The epistemic role of a claim, not a measure of its truth.</summary>
public enum ReasoningNodeKind
{
    Publication,
    ReportedObservation,
    Assumption,
    Inference,
    ScientificModel,
    OpenQuestion
}
