namespace Reality.Physics.Holography;

// A research-level proposed relationship between physical descriptions.
// Not an IReality implementation.
public interface IHolographicDuality
{
    IPhysicalDescription Bulk { get; }
    IPhysicalDescription Boundary { get; }
    bool IsCompleteDualityEstablished { get; }
    string ExplainRelationship();
    CelestialTransformResult DemonstrateEnergyMellinTransform(IReadOnlyList<EnergyAmplitudeSample> samples, double conformalDimension);
    void ReconstructFullBulk();
}
