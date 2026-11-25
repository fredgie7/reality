namespace Reality;

public sealed class ScientificCatalog
{
    private readonly IReadOnlyList<Finding> _findings;
    public ScientificCatalog(IEnumerable<Finding> findings) => _findings = findings.ToArray();
    public IReadOnlyList<Finding> Findings => _findings;

    public static ScientificCatalog Create() => new(new[]
    {
        new Finding("General relativity", "Describes gravity through spacetime geometry.", EvidenceStatus.EstablishedModel),
        new Finding("Quantum mechanics", "Highly predictive framework for microscopic phenomena.", EvidenceStatus.EstablishedModel),
        new Finding("Standard Model", "Describes known elementary particles and electromagnetic, weak and strong interactions.", EvidenceStatus.EstablishedModel),
        new Finding("Thermodynamics", "Isolated macroscopic systems overwhelmingly tend toward higher entropy.", EvidenceStatus.EstablishedModel),
        new Finding("Cosmic expansion", "Cosmological observations support an expanding universe.", EvidenceStatus.Observed),
        new Finding("Dark matter", "Multiple gravitational observations point to unexplained mass or a missing account of gravity.", EvidenceStatus.ActiveResearch),
        new Finding("Dark energy", "Expansion accelerates; the responsible physics is unsettled.", EvidenceStatus.ActiveResearch),
        new Finding("Origin of life", "Abiogenesis pathways remain active research.", EvidenceStatus.ActiveResearch),
        new Finding("Evolution", "Mutation, selection, drift and gene flow change populations over generations.", EvidenceStatus.EstablishedModel),
        new Finding("Genetics", "DNA replication, transcription and inheritance transmit genetic information.", EvidenceStatus.EstablishedModel),
        new Finding("Spacetime", "Relativity describes physical intervals, causal structure and time dilation.", EvidenceStatus.EstablishedModel),
        new Finding("Cultural transmission", "Humans can pass on learned information socially.", EvidenceStatus.Observed),
        new Finding("Neural correlates", "Neural activity systematically relates to reported conscious states.", EvidenceStatus.Observed),
        new Finding("Subjective experience", "Why experience accompanies physical processes remains debated.", EvidenceStatus.OpenQuestion)
    });
}
