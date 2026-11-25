namespace Reality.Implementations;

/// <summary>
/// A broad metaphysical idealist interpretation: mind or experience is
/// fundamental. This is NOT the claim that an individual human mind
/// invents or controls the shared physical world.
/// </summary>
public sealed class IdealistReality : RealityBase
{
    public override string Name => "Idealism";

    public override IReadOnlyList<string> MetaphysicalAssumptions { get; } = new[]
    {
        "Mind, experience, or a mental structure is fundamental to reality.",
        "The physical world is understood in terms of an underlying mental reality, not necessarily any individual's mind.",
        "The apparent independence, order and intersubjective stability of nature require an explanation."
    };

    // TODO: Specify a version of idealism (e.g. objective or analytic idealism).
    // TODO: Explain how stable shared physical regularities arise.
    // TODO: Clarify the relationship between individual minds and the underlying reality.
}
