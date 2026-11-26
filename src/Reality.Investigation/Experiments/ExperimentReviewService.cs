namespace Reality.Investigation.Experiments;

/// <summary>
/// Validates study structure and keeps observation, interpretation, and
/// the untested state distinct. No automatic theory scoring or truth ranking.
/// </summary>
public sealed class ExperimentReviewService
{
    public static ExperimentReview Review(ExperimentPlan plan, IEnumerable<PredictionEvaluation>? evaluations = null)
    {
        ArgumentNullException.ThrowIfNull(plan);
        if (string.IsNullOrWhiteSpace(plan.Id) || string.IsNullOrWhiteSpace(plan.Question) || string.IsNullOrWhiteSpace(plan.Procedure) || string.IsNullOrWhiteSpace(plan.ControlledFactors) || string.IsNullOrWhiteSpace(plan.Measurement) || string.IsNullOrWhiteSpace(plan.InterpretationLimits))
            throw new ArgumentException("An experiment requires an ID, question, procedure, controls, measurement and interpretation limits.", nameof(plan));
        if (!Enum.IsDefined(plan.Status))
            throw new ArgumentException("Invalid experiment status.", nameof(plan));
        if (plan.Predictions is null || plan.Predictions.Count < 2)
            throw new ArgumentException("A competing-predictions experiment requires at least two proposed predictions.", nameof(plan));
        if (plan.Predictions.Any(x => x is null || string.IsNullOrWhiteSpace(x.Id) || string.IsNullOrWhiteSpace(x.ModelVariant) || string.IsNullOrWhiteSpace(x.Conditions) || string.IsNullOrWhiteSpace(x.ExpectedObservation) || string.IsNullOrWhiteSpace(x.PotentialCounterObservation)))
            throw new ArgumentException("Every prediction needs a model, conditions, expected and potential counter-observations.", nameof(plan));
        if (plan.Predictions.Select(x => x.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count() != plan.Predictions.Count)
            throw new ArgumentException("Prediction IDs must be unique within an experiment.", nameof(plan));
        if (plan.SourceUrl is not null && !IsHttpsUrl(plan.SourceUrl))
            throw new ArgumentException("Study inspiration must use an absolute HTTPS source.", nameof(plan));

        var recorded = (evaluations ?? []).ToArray();
        if (recorded.Length > 0 && plan.Status is ExperimentStatus.Proposed or ExperimentStatus.Preregistered)
            throw new ArgumentException("A proposed or preregistered experiment cannot already have evaluated results.", nameof(evaluations));
        foreach (var evaluation in recorded)
        {
            ArgumentNullException.ThrowIfNull(evaluation);
            if (evaluation.ExperimentId != plan.Id || !plan.Predictions.Any(x => x.Id == evaluation.PredictionId) || evaluation.Observation is null || evaluation.Observation.ExperimentId != plan.Id)
                throw new ArgumentException("Each evaluation must reference this plan, one of its predictions, and its observation.", nameof(evaluations));
            if (!Enum.IsDefined(evaluation.Assessment) || evaluation.Assessment == PredictionAssessment.NotEvaluated || string.IsNullOrWhiteSpace(evaluation.Rationale) || string.IsNullOrWhiteSpace(evaluation.Observation.Description) || !IsHttpsUrl(evaluation.Observation.SourceUrl))
                throw new ArgumentException("Reported assessments require a supported classification, rationale, observation and source.", nameof(evaluations));
        }
        return new ExperimentReview(plan, Array.AsReadOnly(recorded));
    }

    private static bool IsHttpsUrl(string value) => Uri.TryCreate(value, UriKind.Absolute, out var url) && url.Scheme == Uri.UriSchemeHttps;
}
