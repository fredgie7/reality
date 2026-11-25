namespace Reality.Implementations;

/// <summary>
/// A physicalist interpretation: mental phenomena are physical or entirely
/// fixed by the physical facts. This class represents a philosophical view,
/// not a proof that any particular account of consciousness is correct.
/// </summary>
public sealed class PhysicalistReality : RealityBase
{
    public override string Name => "Physicalism";

    public override IReadOnlyList<string> MetaphysicalAssumptions { get; } = new[]
    {
        "All facts about reality are physical facts, or are wholly determined by physical facts.",
        "Mental states do not require a fundamentally nonphysical substance.",
        "Explaining how physical processes relate to subjective experience remains a philosophical and scientific challenge."
    };

    // TODO: Clarify whether this implementation assumes reductive or nonreductive physicalism.
    // TODO: Explain the relationship between neural mechanisms and first-person experience.
    // TODO: Identify what empirical results could distinguish competing physicalist accounts.
}
