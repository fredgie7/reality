using Reality.Core.Epistemology;

namespace Reality.Philosophy.Study;

public sealed class PhilosophyOfScience
{
    public static string RevisitAssumptions(Finding finding) =>
        $"Recheck '{finding.Subject}' as evidence changes; status: {finding.Status}.";

    public static string InvestigateEmergence() =>
        "Complex organization can account for collective behavior; extending an explanation to other phenomena requires independent argument.";

    public static string ExamineLimitsOfKnowledge() =>
        "An internal observer does not automatically have access to the implementation that generated it.";
}
