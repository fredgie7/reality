namespace Reality.Investigation.Experiments;

/// <summary>
/// A proposed or documented method for contrasting conditional predictions.
/// Status does not assert that data were collected or that an ontology is true.
/// </summary>
public sealed record ExperimentPlan(
    string Id,
    string Question,
    string Procedure,
    string ControlledFactors,
    string Measurement,
    IReadOnlyList<HypothesisPrediction> Predictions,
    string InterpretationLimits,
    ExperimentStatus Status,
    string? SourceUrl = null);
