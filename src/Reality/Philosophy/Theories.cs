namespace Reality.Philosophy;

public interface ITheoryOfConsciousness
{
    string Name { get; }
    string CoreClaim { get; }
    string EvidenceStatus { get; }
    string OpenQuestion { get; }
}

public sealed record ConsciousnessTheory(string Name, string CoreClaim, string OpenQuestion) : ITheoryOfConsciousness
{
    public string EvidenceStatus => "Philosophical position, not an empirically established implementation";
}

public sealed class TheoryComparison
{
    public IReadOnlyList<ITheoryOfConsciousness> Theories { get; } = new ITheoryOfConsciousness[]
    {
        new ConsciousnessTheory("Panpsychism", "Experience is fundamental and widespread.", "How do microexperiences relate to human awareness?"),
        new ConsciousnessTheory("Physicalism", "Mental facts are wholly physical or fixed by physical facts.", "How does physical description account for experience?"),
        new ConsciousnessTheory("Idealism", "Mind or experience is metaphysically fundamental.", "How is the shared structured physical world explained?"),
        new ConsciousnessTheory("Substance dualism", "Mental and physical substances are distinct.", "How do they causally interact?")
    };
}

public sealed class PhilosophyOfScience
{
    public string RevisitAssumptions(Finding finding) =>
        $"Recheck '{finding.Subject}' as evidence changes; status: {finding.Confidence}.";

    public string InvestigateEmergence() =>
        "Complex organization may explain new system behavior, but subjective unity needs its own argument.";

    public string ExamineLimitsOfKnowledge() =>
        "An internal observer does not automatically have access to the implementation that generated it.";
}
