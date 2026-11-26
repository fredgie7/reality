namespace Reality.Investigation.Experiments;

/// <summary>
/// A sourced observation. It is not automatically an interpretation of a hypothesis.
/// </summary>
public sealed record RecordedObservation(string ExperimentId, string Description, string SourceUrl);
