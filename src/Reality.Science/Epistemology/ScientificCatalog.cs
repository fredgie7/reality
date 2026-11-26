using Reality.Core.Epistemology;
using Reality.Science.Biology;
using Reality.Science.Physics;

using System.Collections.ObjectModel;

namespace Reality.Science.Epistemology;

public sealed class ScientificCatalog
{
    private readonly IReadOnlyList<Finding> _findings;
    private readonly ReadOnlyCollection<ScientificInvestigation> _investigations;

    public ScientificCatalog(IEnumerable<Finding> findings, IEnumerable<ScientificInvestigation>? investigations = null)
    {
        ArgumentNullException.ThrowIfNull(findings);
        _findings = Array.AsReadOnly(findings.ToArray());
        _investigations = Array.AsReadOnly((investigations ?? Array.Empty<ScientificInvestigation>()).ToArray());

        var subjects = _findings.Select(f => f.Subject).ToHashSet(StringComparer.OrdinalIgnoreCase);
        if (_investigations.Any(i => !subjects.Contains(i.FindingSubject)))
            throw new ArgumentException("Every investigation must reference an existing finding.", nameof(investigations));
        if (_investigations.Select(i => i.FindingSubject).Distinct(StringComparer.OrdinalIgnoreCase).Count() != _investigations.Count)
            throw new ArgumentException("An investigation may only appear once per finding.", nameof(investigations));
    }

    public IReadOnlyList<Finding> Findings => _findings;
    public IReadOnlyList<ScientificInvestigation> Investigations => _investigations;

    public ScientificInvestigation? GetInvestigation(string findingSubject)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(findingSubject);
        return _investigations.FirstOrDefault(i => i.FindingSubject.Equals(findingSubject, StringComparison.OrdinalIgnoreCase));
    }

    private static readonly Finding[] DefaultFindings =
    [
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
    ];

    private static readonly ScientificInvestigation[] DefaultInvestigations =
    [
        new ScientificInvestigation(
            "Cosmic expansion",
            [ "Light from distant galaxies often displays systematic redshift correlated with distance.", "Multiple cosmological observations provide independent constraints on expansion history." ],
            "An expanding-universe model quantitatively accounts for these patterns.",
            [ "The chosen physical model connects measured redshift to cosmological scale and distance estimates." ],
            [ "Alternative explanations of redshift and different cosmological models must be compared against the full body of observations." ],
            [ "Test predictions against independent distance measurements and the cosmic microwave background." ],
            "Curated conceptual summary; primary studies and dataset provenance not yet attached."),
        new ScientificInvestigation(
            "Dark matter",
            [ "Galactic rotation, gravitational lensing, and structure formation exhibit gravitational effects not explained by visible matter alone under standard models." ],
            "Additional nonluminous mass is one leading explanation within current cosmological models.",
            [ "Gravitational dynamics are interpreted using a specified theory of gravity and estimated distributions of ordinary matter." ],
            [ "Modified-gravity approaches are investigated, though they face constraints across multiple observational scales." ],
            [ "Compare predicted lensing, structure formation, laboratory searches, and cosmological data across competing models." ],
            "Curated conceptual summary; primary studies and dataset provenance not yet attached."),
        new ScientificInvestigation(
            "Neural correlates",
            [ "Brain activity and reported or behaviorally indicated conscious states covary in reproducible experimental settings." ],
            "Certain neural processes are associated with conscious states; correlation alone does not settle metaphysical identity or causation.",
            [ "Behavioral reports and experimental tasks are imperfect proxies for phenomenal experience." ],
            [ "Competing neural mechanisms and philosophical interpretations may fit the same correlational data." ],
            [ "Compare preregistered predictions across neural models using interventions and independent measurements." ],
            "Curated conceptual summary; primary studies and dataset provenance not yet attached.")
    ];

    public static ScientificCatalog Create() => new(DefaultFindings, DefaultInvestigations);
}
