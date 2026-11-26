namespace Reality.Investigation.Experiments;

/// <summary>
/// A conditional prediction attributed to a specified model variant.
/// It does not follow that its parent metaphysical theory is established.
/// </summary>
public sealed record HypothesisPrediction(string Id, string ModelVariant, string Conditions, string ExpectedObservation, string PotentialCounterObservation);
