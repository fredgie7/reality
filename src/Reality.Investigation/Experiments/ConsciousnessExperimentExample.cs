namespace Reality.Investigation.Experiments;

/// <summary>
/// An illustrative NEW proposed preregistration-style replication design,
/// inspired by the 2025 Cogitate comparison. Not the original study protocol,
/// an actual preregistration, or an assertion of experimental outcomes.
/// </summary>
public static class ConsciousnessExperimentExample
{
    public const string ProposalId = "proposed-neural-theory-replication";
    public const string GnwtPredictionId = "gnwt-offset-ignition";
    public const string IitPredictionId = "iit-posterior-synchrony";

    public static ExperimentPlan Create() => new(
        ProposalId,
        "Would prospectively specified neural signatures discriminate particular GNWT and IIT predictions?",
        "Design an independent, preregistered visual-perception study with independently defined onset/offset and posterior-connectivity analyses; preregister sampling and exclusion rules.",
        "Stimulus visibility and duration, task/report demands, attention, recording coverage, statistical thresholds and analysis windows must be specified before data collection.",
        "Time-resolved prefrontal activity around offset and sustained content-specific posterior synchronization, with uncertainty and power reported separately.",
        [
            new HypothesisPrediction(
                GnwtPredictionId,
                "A specified GNWT variant with an explicit offset-ignition commitment",
                "If the selected GNWT variant predicts prefrontal ignition at offset under the preregistered task and attention conditions",
                "A reproducible prefrontal ignition signature at the preregistered offset interval",
                "No such signature under adequate power, coverage and the specified task conditions"),
            new HypothesisPrediction(
                IitPredictionId,
                "A specified IIT variant with an explicit sustained posterior-synchrony commitment",
                "If the selected IIT variant predicts content-specific sustained posterior synchronization for the preregistered stimuli",
                "Sustained content-specific synchronization within the preregistered posterior network",
                "No predicted synchronization under adequate power, coverage and the specified conditions")
        ],
        "The signatures test distinct conditional predictions and may both occur, neither occur, or remain inconclusive. These are not automatically mutually exclusive alternatives and cannot alone determine consciousness's underlying ontology.",
        ExperimentStatus.Proposed,
        "https://doi.org/10.1038/s41586-025-08888-1");
}
