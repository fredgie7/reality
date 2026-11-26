namespace Reality.Science.Emergence;

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
    // TODO: Identify which collective properties this model can actually predict.
}
