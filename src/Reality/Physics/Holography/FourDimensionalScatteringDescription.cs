using Reality.Physics.Holography.Interfaces;
namespace Reality.Physics.Holography;

public sealed class FourDimensionalScatteringDescription : IPhysicalDescription
{
    public string Name => "4D momentum-space scattering";
    public string Domain => "Asymptotically flat four-dimensional spacetime";
    public IReadOnlyList<string> Observables { get; } = new[]
    {
        "Asymptotic particle states",
        "External energy-momenta and directions",
        "Scattering amplitudes"
    };
    public string ResearchStatus => "Well-developed scattering formalism; a complete quantum theory of gravity is unresolved.";
}
