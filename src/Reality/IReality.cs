namespace Reality;

/// <summary>
/// A candidate metaphysical account. Observable physics and biology are not
/// necessary properties of every conceivable reality.
/// </summary>
public interface IReality
{
    string Name { get; }
    IReadOnlyList<string> MetaphysicalAssumptions { get; }
}
