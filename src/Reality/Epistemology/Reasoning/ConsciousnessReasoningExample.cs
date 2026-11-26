namespace Reality.Epistemology.Reasoning;

/// <summary>
/// A published experimental comparison, represented as claims rather than a
/// simulation of brains or an endorsement of either theory.
/// Publication: Nature (2025), doi:10.1038/s41586-025-08888-1.
/// </summary>
public static class ConsciousnessReasoningExample
{
    public const string MainInferenceId = "neural-content-inference";

    public static ReasoningGraph Create() => new(
    [
        new ReasoningNode("nature-2025", ReasoningNodeKind.Publication,
            "Melloni et al., Adversarial testing of global neuronal workspace and integrated information theories of consciousness (Nature, 2025).",
            "https://doi.org/10.1038/s41586-025-08888-1"),
        new ReasoningNode("neural-observation", ReasoningNodeKind.ReportedObservation,
            "The 2025 preregistered collaboration reported consciousness-related content signals in visual, ventrotemporal and inferior frontal regions across measured participants."),
        new ReasoningNode("duration-observation", ReasoningNodeKind.ReportedObservation,
            "The study reported sustained responses in occipital and lateral temporal cortex reflecting the duration of presented stimuli."),
        new ReasoningNode("report-assumption", ReasoningNodeKind.Assumption,
            "Task conditions, subjective reports, and neural measurements provide operational indicators of conscious perception; none is a direct measurement of phenomenal experience itself."),
        new ReasoningNode(MainInferenceId, ReasoningNodeKind.Inference,
            "Specified patterns of brain activity covary with conscious visual content in the study; this does not by itself establish the metaphysical nature of consciousness."),
        new ReasoningNode("gnwt", ReasoningNodeKind.ScientificModel,
            "Global Neuronal Workspace Theory proposes widespread access and broadcasting of conscious information."),
        new ReasoningNode("iit", ReasoningNodeKind.ScientificModel,
            "Integrated Information Theory emphasizes the intrinsic causal structure of a system as relevant to consciousness."),
        new ReasoningNode("limitations", ReasoningNodeKind.OpenQuestion,
            "Which versions of these neural theories best explain the full results, and which predictions can separate them in new experiments?"),
        new ReasoningNode("ontology-gap", ReasoningNodeKind.OpenQuestion,
            "What, if anything, do these neural correlations establish about whether consciousness is fundamentally physical, mental or otherwise?")
    ],
    [
        new ReasoningConnection("nature-2025", "neural-observation", ReasoningRelation.Documents,
            "The publication reports these measured neural patterns."),
        new ReasoningConnection("nature-2025", "duration-observation", ReasoningRelation.Documents,
            "The publication reports sustained sensory-region activity related to stimulus duration."),
        new ReasoningConnection("neural-observation", MainInferenceId, ReasoningRelation.Supports,
            "Neural content signatures support a bounded association claim, not a causal or ontological identity."),
        new ReasoningConnection("duration-observation", MainInferenceId, ReasoningRelation.Supports,
            "Sustained responses provide a second reported neural correlate."),
        new ReasoningConnection("report-assumption", MainInferenceId, ReasoningRelation.RequiresAssumption,
            "The inference depends on how conscious perception was operationalized."),
        new ReasoningConnection("neural-observation", "gnwt", ReasoningRelation.Challenges,
            "The 2025 adversarial study challenged some specific preregistered GNWT predictions; it did not universally refute GNWT."),
        new ReasoningConnection("duration-observation", "iit", ReasoningRelation.Challenges,
            "The 2025 adversarial study challenged some specific preregistered IIT predictions; it did not universally refute IIT."),
        new ReasoningConnection(MainInferenceId, "limitations", ReasoningRelation.RaisesQuestion,
            "Observed correlates leave competing neural accounts under further investigation."),
        new ReasoningConnection(MainInferenceId, "ontology-gap", ReasoningRelation.RaisesQuestion,
            "The step from observable neural correlation to ultimate ontology is not established.")
    ]);
}
