namespace Reality;

/// <summary>
/// A transparent, curated reasoning trail attached to one scientific finding.
/// This is not automatically verified research provenance or a proof of the inference.
/// </summary>
public sealed record ScientificInvestigation(
    string FindingSubject,
    IReadOnlyList<string> Observations,
    string Inference,
    IReadOnlyList<string> Assumptions,
    IReadOnlyList<string> Alternatives,
    IReadOnlyList<string> PotentialTests,
    string SourceStatus);
