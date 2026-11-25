namespace Reality.Implementations;

/// <summary>
/// Explicit, dependency-free registry of candidate ontologies.
/// Selecting an interpretation changes assumptions, not shared observations.
/// </summary>
public static class RealityFactory
{
    public static IReadOnlyList<string> AvailableModels { get; } = new[]
    {
        "panpsychism",
        "physicalism",
        "idealism",
        "substance-dualism"
    };

    public static IReality Create(string model)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model);

        return model.Trim().ToLowerInvariant() switch
        {
            "panpsychism" => new PanpsychistReality(),
            "physicalism" => new PhysicalistReality(),
            "idealism" => new IdealistReality(),
            "substance-dualism" => new SubstanceDualistReality(),
            _ => throw new ArgumentException($"Unknown reality model '{model}'. Valid options: {string.Join(", ", AvailableModels)}.", nameof(model))
        };
    }
}
