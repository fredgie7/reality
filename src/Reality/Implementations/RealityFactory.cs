using Reality.Biology;
using Reality.Physics;

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

    public static IReality Create(string model, ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model);

        return model.Trim().ToLowerInvariant() switch
        {
            "panpsychism" => new PanpsychistReality(physics, cosmos, chemistry, evolution, knowledge),
            "physicalism" => new PhysicalistReality(physics, cosmos, chemistry, evolution, knowledge),
            "idealism" => new IdealistReality(physics, cosmos, chemistry, evolution, knowledge),
            "substance-dualism" => new SubstanceDualistReality(physics, cosmos, chemistry, evolution, knowledge),
            _ => throw new ArgumentException($"Unknown reality model '{model}'. Valid options: {string.Join(", ", AvailableModels)}.", nameof(model))
        };
    }
}
