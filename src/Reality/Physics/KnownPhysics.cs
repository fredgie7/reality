using Reality.Physics.Interfaces;
namespace Reality.Physics;

public sealed class KnownPhysics : ILawsOfPhysics
{
    public const double SpeedOfLight = 299_792_458;
    public const double PlanckConstant = 6.62607015e-34;
    public const double GravitationalConstant = 6.67430e-11;

    public IReadOnlyList<PhysicalPrinciple> Principles { get; } = new[]
    {
        new PhysicalPrinciple("Relativity", "Locally, causal influence cannot propagate faster than light.", "Quantum gravity"),
        new PhysicalPrinciple("Quantum mechanics", "Quantum states predict probabilities of outcomes.", "Measurement interpretations"),
        new PhysicalPrinciple("Energy conservation", "Time-translation symmetry yields a conserved energy in suitable systems.", "Global energy in arbitrary curved spacetime"),
        new PhysicalPrinciple("Momentum conservation", "Spatial translation symmetry yields conserved momentum in suitable systems.", "Global momentum in arbitrary curved spacetime"),
        new PhysicalPrinciple("Second law", "Entropy overwhelmingly increases in isolated macroscopic systems.", "Low-entropy early universe")
    };

    public bool IsLocallyCausalSignal(double speedMetersPerSecond) =>
        double.IsFinite(speedMetersPerSecond) && speedMetersPerSecond >= 0 && speedMetersPerSecond <= SpeedOfLight;
}
