namespace Reality;

/// <summary>
/// Optional convenience base for the example ontologies. Observations are
/// passed to the study separately; they are not an IReality requirement.
/// </summary>
public abstract class RealityBase : IReality
{
    public abstract string Name { get; }
    public abstract IReadOnlyList<string> MetaphysicalAssumptions { get; }
}
