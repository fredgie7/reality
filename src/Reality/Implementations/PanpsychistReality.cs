namespace Reality.Implementations;

/// <summary>
/// Our FIRST example of IReality, not the definition of reality.
/// Panpsychism proposes that experience is fundamental and widespread.
/// </summary>
public sealed class PanpsychistReality : RealityBase
{
    public override string Name => "Panpsychism";

    public override IReadOnlyList<string> MetaphysicalAssumptions { get; } = new[]
    {
        "Fundamental physical entities may have intrinsic experiential aspects.",
        "Macroscopic consciousness must be reconciled with fundamental experience.",
        "This interpretation is a philosophical hypothesis, not a demonstrated property of matter."
    };

    // TODO: Determine whether fundamental experience exists.
    // TODO: Explain how (or whether) microexperience relates to human experience.
    // TODO: Discover the current implementation. Source code unavailable.
}
