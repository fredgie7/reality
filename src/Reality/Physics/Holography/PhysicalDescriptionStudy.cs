using Reality.Physics.Holography.Interfaces;
namespace Reality.Physics.Holography;

/// <summary>
/// Compares mathematical descriptions without selecting or requiring an ontology.
/// </summary>
public sealed class PhysicalDescriptionStudy
{
    public string Summarize(IHolographicDuality duality)
    {
        ArgumentNullException.ThrowIfNull(duality);

        return $"{duality.Name}: compare {duality.Bulk.Name} with {duality.Boundary.Name}. " +
            $"Correspondence status: {duality.CorrespondenceStatus}. " +
            "A physical correspondence does not by itself determine the underlying ontology.";
    }
}
