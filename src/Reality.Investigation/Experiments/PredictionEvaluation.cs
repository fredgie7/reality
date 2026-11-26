namespace Reality.Investigation.Experiments;

/// <summary>
/// An explicitly justified human-curated assessment of an observation against
/// one conditional prediction; not an automated inference or a proof.
/// </summary>
public sealed record PredictionEvaluation(string ExperimentId, string PredictionId, PredictionAssessment Assessment, string Rationale, RecordedObservation Observation);
