using Reality.Science.Physics.Holography.Interfaces;

namespace Reality.Science.Physics.Holography;

public sealed class CelestialConformalDescription : IPhysicalDescription
{
    public string Name => "Celestial conformal representation";
    public string Domain => "Two-dimensional celestial sphere of asymptotic null directions";
    public IReadOnlyList<string> Observables { get; } = [
        "Mellin-transformed scattering data",
        "Conformal weights and positions on the celestial sphere",
        "Asymptotic symmetry constraints"
    ];
    public string ResearchStatus => "Active research; a complete flat-space gravitational dual is not established.";
}
