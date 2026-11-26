namespace Reality.Science.Emergence;

/// <summary>
/// Demonstrates a collective property (adjacent connected activation) absent
/// from any isolated boolean; it makes no claim about other phenomena.
/// </summary>
public sealed record EmergentPattern(int ActiveComponents, int AdjacentActivePairs, bool HasConnectedCluster);
