namespace Reality.Investigation.Reasoning;

/// <summary>
/// A curated representation of the 2025 preregistered adversarial comparison,
/// with both supportive and challenging findings retained. The authors' interpretation
/// of the GNWT offset result has also been disputed by GNWT proponents.
/// Sources: doi:10.1038/s41586-025-08888-1 and doi:10.1093/nc/niaf037.
/// </summary>
public static class ConsciousnessReasoningExample
{
    public const string MainInferenceId = "neural-content-inference";

    public static ReasoningGraph Create() => new(
    [
        new ReasoningNode("nature-2025", ReasoningNodeKind.Publication,
            "Cogitate Consortium, Adversarial testing of global neuronal workspace and integrated information theories of consciousness (Nature, 2025).",
            "https://doi.org/10.1038/s41586-025-08888-1"),
        new ReasoningNode("gnwt-response-2025", ReasoningNodeKind.Publication,
            "Published GNWT-proponent response to the adversarial study (Neuroscience of Consciousness, 2025).",
            "https://doi.org/10.1093/nc/niaf037"),
        new ReasoningNode("neural-observation", ReasoningNodeKind.ReportedObservation,
            "The study reported conscious-content information in visual, ventrotemporal and inferior frontal cortex."),
        new ReasoningNode("duration-observation", ReasoningNodeKind.ReportedObservation,
            "The study reported sustained activity in occipital and lateral temporal cortex reflecting stimulus duration."),
        new ReasoningNode("offset-observation", ReasoningNodeKind.ReportedObservation,
            "The study generally did not find the preregistered onset-and-offset ignition pattern in prefrontal recordings."),
        new ReasoningNode("prefrontal-limitation", ReasoningNodeKind.ReportedObservation,
            "The study found limited prefrontal representation of some measured dimensions of conscious content."),
        new ReasoningNode("posterior-synchrony-observation", ReasoningNodeKind.ReportedObservation,
            "The study did not find sustained content-specific synchronization within posterior cortex as predicted in its IIT test."),
        new ReasoningNode("report-assumption", ReasoningNodeKind.Assumption,
            "Task conditions, behavioral reports and neural measurements serve as operational indicators of conscious perception; they do not directly measure phenomenal experience."),
        new ReasoningNode(MainInferenceId, ReasoningNodeKind.Inference,
            "Measured neural patterns relate to conscious visual-content indicators in the study; this does not establish the metaphysical nature of consciousness."),
        new ReasoningNode("gnwt", ReasoningNodeKind.ScientificModel,
            "Global Neuronal Workspace Theory proposes widespread access and broadcasting of conscious information."),
        new ReasoningNode("iit", ReasoningNodeKind.ScientificModel,
            "Integrated Information Theory emphasizes intrinsic causal organization in its account of consciousness."),
        new ReasoningNode("gnwt-offset-dispute", ReasoningNodeKind.OpenQuestion,
            "GNWT proponents dispute whether ignition at unattended stimulus offset is a central prediction; which preregistered outcomes decisively discriminate variants remains contested."),
        new ReasoningNode("limitations", ReasoningNodeKind.OpenQuestion,
            "Which specific neural theory variants best explain the complete, partly supportive and partly challenging results?"),
        new ReasoningNode("ontology-gap", ReasoningNodeKind.OpenQuestion,
            "What, if anything, do these neural correlations establish about whether consciousness is fundamentally physical, mental or otherwise?")
    ],
    [
        new ReasoningConnection("nature-2025", "neural-observation", ReasoningRelation.Documents,
            "The publication reports decoded content-related neural activity."),
        new ReasoningConnection("nature-2025", "duration-observation", ReasoningRelation.Documents,
            "The publication reports sustained sensory-region responses."),
        new ReasoningConnection("nature-2025", "offset-observation", ReasoningRelation.Documents,
            "The publication reports generally absent predicted prefrontal offset ignition."),
        new ReasoningConnection("nature-2025", "prefrontal-limitation", ReasoningRelation.Documents,
            "The publication reports limits to decoding some content dimensions in prefrontal regions."),
        new ReasoningConnection("nature-2025", "posterior-synchrony-observation", ReasoningRelation.Documents,
            "The publication reports the absence of the preregistered sustained posterior synchronization prediction."),
        new ReasoningConnection("gnwt-response-2025", "gnwt-offset-dispute", ReasoningRelation.Documents,
            "The published response argues offset ignition is not a core GNWT prediction in these unattended conditions."),
        new ReasoningConnection("neural-observation", MainInferenceId, ReasoningRelation.Supports,
            "The measured content signatures support an association, not ontological identity."),
        new ReasoningConnection("duration-observation", MainInferenceId, ReasoningRelation.Supports,
            "Sustained sensory activity supplies another measured association."),
        new ReasoningConnection("report-assumption", MainInferenceId, ReasoningRelation.RequiresAssumption,
            "The inference depends on how conscious perception was operationalized."),
        new ReasoningConnection("offset-observation", "gnwt", ReasoningRelation.Challenges,
            "The preregistered GNWT offset-ignition prediction was not generally observed; whether this tests a core prediction is disputed."),
        new ReasoningConnection("prefrontal-limitation", "gnwt", ReasoningRelation.Challenges,
            "Limited prefrontal representation challenges some preregistered GNWT content predictions."),
        new ReasoningConnection("posterior-synchrony-observation", "iit", ReasoningRelation.Challenges,
            "The preregistered sustained posterior-synchronization prediction was not supported."),
        new ReasoningConnection("offset-observation", "gnwt-offset-dispute", ReasoningRelation.RaisesQuestion,
            "An experimental mismatch does not alone settle the theoretical status of the prediction."),
        new ReasoningConnection(MainInferenceId, "limitations", ReasoningRelation.RaisesQuestion,
            "The results include predictions supported, challenged and left inconclusive."),
        new ReasoningConnection(MainInferenceId, "ontology-gap", ReasoningRelation.RaisesQuestion,
            "From neural association to ultimate ontology is a separate inference.")
    ]);
}
