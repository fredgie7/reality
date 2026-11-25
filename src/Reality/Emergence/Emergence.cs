namespace Reality.Emergence;

public sealed record EmergentPattern(int ActiveComponents, int AdjacentActivePairs, bool HasConnectedCluster);

/// <summary>
/// Demonstrates a collective property (adjacent connected activation) absent
/// from any isolated boolean. No claim about phenomenal consciousness follows.
/// </summary>
public sealed class EmergenceModel
{
    public EmergentPattern Analyze(IReadOnlyList<bool> components)
    {
        ArgumentNullException.ThrowIfNull(components);
        var active = components.Count(x => x);
        var pairs = 0;
        for (var i = 1; i < components.Count; i++)
            if (components[i - 1] && components[i]) pairs++;
        return new EmergentPattern(active, pairs, pairs > 0);
    }

    // TODO: Distinguish weak/strong emergence, explanation and reduction.
    // TODO: Does emergence explain experience, or only observable behavior?
}
