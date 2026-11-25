namespace Reality.Physics.Holography;

/// <summary>
/// Relates a mathematical-description study to any IReality implementation
/// WITHOUT making the proposed holographic duality part of the ontology.
/// </summary>
public sealed class PhysicalDescriptionStudy
{
    public string Summarize(IReality reality, IHolographicDuality duality)
    {
        ArgumentNullException.ThrowIfNull(reality);
        ArgumentNullException.ThrowIfNull(duality);
        return $"Within {reality.Name}, compare {duality.Bulk.Name} with {duality.Boundary.Name}. " +
            $"Descriptions do not choose the ontology. Complete duality established: {duality.IsCompleteDualityEstablished}.";
    }
}
