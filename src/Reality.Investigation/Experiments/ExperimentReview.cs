namespace Reality.Investigation.Experiments;

/// <summary>A plan and its recorded evaluations; an empty evaluation list is not failure.</summary>
public sealed record ExperimentReview(ExperimentPlan Plan, IReadOnlyList<PredictionEvaluation> Evaluations);
