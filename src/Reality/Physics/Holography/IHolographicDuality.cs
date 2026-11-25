namespace Reality.Physics.Holography;

/// <summary>
/// Shared metadata describing a proposed correspondence between two physical
/// descriptions. Individual theories own their specialized calculations,
/// dictionaries, reconstruction procedures, and open mathematical problems.
/// </summary>
public interface IHolographicDuality
{
    string Name { get; }
    IPhysicalDescription Bulk { get; }
    IPhysicalDescription Boundary { get; }
    HolographicCorrespondenceStatus CorrespondenceStatus { get; }
    IReadOnlyList<string> OpenQuestions { get; }
    string ExplainRelationship();
}
