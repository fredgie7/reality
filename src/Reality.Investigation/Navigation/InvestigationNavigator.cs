using System.Text;
using Reality.Core.Epistemology;
using Reality.Investigation.Experiments;
using Reality.Investigation.Workflow;
using Reality.Philosophy.Interfaces;
using Reality.Science.Epistemology;

namespace Reality.Investigation.Navigation;

/// <summary>
/// Read-only inspection of curated science, competing interpretations and proposed
/// experiments. No command assigns a metaphysical verdict or changes research data.
/// </summary>
public sealed class InvestigationNavigator(ScientificCatalog catalog, IReadOnlyList<ITheoryOfReality> theories, InvestigationReport report)
{
    public NavigationResult Execute(string? input)
    {
        var commandLine = input?.Trim() ?? string.Empty;
        if (commandLine.Length == 0)
            return new NavigationResult("Type 'help' to see the available commands.");
        var separator = commandLine.IndexOf(' ');
        var command = separator < 0 ? commandLine : commandLine[..separator];
        var argument = separator < 0 ? string.Empty : commandLine[(separator + 1)..].Trim();
        switch (command.ToLowerInvariant())
        {
            case NavigationCommands.Help:
                return new NavigationResult(Help());
            case NavigationCommands.Findings:
                return new NavigationResult(ListFindings());
            case NavigationCommands.Finding:
                return new NavigationResult(ShowFinding(argument));
            case NavigationCommands.Theories:
                return new NavigationResult(ListTheories());
            case NavigationCommands.Theory:
                return new NavigationResult(ShowTheory(argument));
            case NavigationCommands.Evidence:
                return new NavigationResult(ListEvidence());
            case NavigationCommands.Trace:
                return new NavigationResult(TraceEvidence(argument));
            case NavigationCommands.Experiments:
                return new NavigationResult(ShowExperiment());
            case NavigationCommands.Report:
                return new NavigationResult(ShowReport());
            case NavigationCommands.Quit:
            case NavigationCommands.Exit:
                return new NavigationResult("Investigation closed. Questions remain open.", true);
            default:
                return new NavigationResult($"Unknown command '{command}'. Type 'help' for available commands.");
        }
    }

    private static string Help() =>
        """
        COMMANDS
          help                 Show this menu
          findings             List scientific findings
          finding <subject>    Inspect a finding and its provenance
          theories             List the selected metaphysical theories
          theory <name>        Inspect a theory, objections and possible replies
          evidence             List reasoning-graph nodes with IDs
          trace <node-id>      Follow a claim's upstream reasons and sources
          experiments          Inspect conditional predictions and study status
          report               Summarize the investigation and its limits
          quit                 Exit the investigation

        Example: finding Neural correlates
        Example: theory Substance dualism
        Example: trace neural-content-inference
        """;

    private string ListFindings()
    {
        var output = new StringBuilder("SCIENTIFIC FINDINGS (status is not a confidence score)").AppendLine();
        foreach (var finding in catalog.Findings)
            output.AppendLine($"  [{finding.Status}] {finding.Subject}");
        output.Append("Use 'finding <subject>' for details and source status.");
        return output.ToString();
    }

    private string ShowFinding(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            return "Usage: finding <subject>. Use 'findings' to list available subjects.";
        var finding = catalog.Findings.FirstOrDefault(x => x.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase));
        if (finding is null)
            return $"No finding named '{subject}'. Use 'findings' to list available subjects.";

        var output = new StringBuilder().AppendLine($"FINDING: {finding.Subject}").AppendLine($"  STATUS: {finding.Status}").AppendLine($"  DESCRIPTION: {finding.Description}");
        var study = catalog.GetInvestigation(finding.Subject);
        if (study is null)
            return output.Append("  EVIDENCE TRAIL: Not curated for this finding; no provenance is implied.").ToString();

        output.AppendLine($"  SOURCE PROVENANCE: {study.SourceStatus}");
        if (study.SourceStatus == SourceProvenanceStatus.NotAttached)
            output.AppendLine("  CAUTION: Primary study references and datasets are not attached.");
        if (!string.IsNullOrWhiteSpace(study.SourceNotes))
            output.AppendLine($"  SOURCE NOTES: {study.SourceNotes}");
        foreach (var observation in study.Observations)
            output.AppendLine($"  OBSERVATION: {observation}");
        output.AppendLine($"  INFERENCE: {study.Inference}");
        foreach (var assumption in study.Assumptions)
            output.AppendLine($"  ASSUMPTION: {assumption}");
        foreach (var alternative in study.Alternatives)
            output.AppendLine($"  ALTERNATIVE: {alternative}");
        foreach (var test in study.PotentialTests)
            output.AppendLine($"  POTENTIAL TEST: {test}");
        return output.ToString().TrimEnd();
    }

    private string ListTheories()
    {
        var output = new StringBuilder("SELECTED METAPHYSICAL THEORIES (none is verified)").AppendLine();
        foreach (var theory in theories)
            output.AppendLine($"  {theory.Name}: {theory.CoreClaim}");
        output.Append("Use 'theory <name>' to inspect assumptions and debates.");
        return output.ToString();
    }

    private string ShowTheory(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Usage: theory <name>. Use 'theories' to list selected theories.";
        var theory = theories.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (theory is null)
            return $"Theory '{name}' is not selected. Use 'theories' to list available choices.";
        var output = new StringBuilder().AppendLine($"THEORY: {theory.Name}").AppendLine($"  CORE CLAIM: {theory.CoreClaim}");
        foreach (var assumption in theory.Assumptions)
            output.AppendLine($"  ASSUMPTION: {assumption.Description}");
        foreach (var explanation in theory.Explanations)
            output.AppendLine($"  TOPIC INTERPRETATION [{explanation.FindingSubject}]: {explanation.Account}");
        foreach (var debate in theory.Debates)
        {
            output.AppendLine($"  DEBATE [{debate.Id}] — {debate.VariantScope}");
            output.AppendLine($"    OBJECTION: {debate.Objection}");
            output.AppendLine($"    POSSIBLE RESPONSE (not a solution): {debate.PossibleResponse}");
            output.AppendLine($"    UNRESOLVED: {debate.RemainingQuestion}");
            output.AppendLine($"    PHILOSOPHICAL REFERENCE: {debate.SourceUrl}");
        }
        foreach (var question in theory.OpenQuestions)
            output.AppendLine($"  OPEN QUESTION: {question.Description}");
        output.AppendLine(theory.Predictions.Count == 0
            ? "  EMPIRICAL DISCRIMINATORS: None currently specified for this broad ontology."
            : $"  PROPOSED PREDICTIONS: {theory.Predictions.Count} (not automatically verified).");
        return output.ToString().TrimEnd();
    }

    private string ListEvidence()
    {
        var output = new StringBuilder("REASONING GRAPH NODES (IDs are not truth claims)").AppendLine();
        foreach (var node in report.Reasoning.Nodes)
            output.AppendLine($"  [{node.Kind}] {node.Id}: {node.Description}");
        output.Append("Use 'trace <node-id>' to inspect the upstream premises and sources.");
        return output.ToString();
    }

    private string TraceEvidence(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return "Usage: trace <node-id>. Use 'evidence' to list IDs.";
        var node = report.Reasoning.Nodes.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (node is null)
            return $"Unknown evidence node '{id}'. Use 'evidence' to list IDs.";
        var output = new StringBuilder().AppendLine($"CLAIM [{node.Kind}]: {node.Description}");
        if (node.SourceUrl is not null)
            output.AppendLine($"  SOURCE: {node.SourceUrl}");
        var links = report.Reasoning.TraceReasons(node.Id);
        if (links.Count == 0)
            output.AppendLine("  UPSTREAM REASONS: No incoming links are recorded; this does not establish verification.");
        foreach (var link in links)
        {
            var premise = report.Reasoning.GetNode(link.FromId);
            output.AppendLine($"  {link.Relation} [{premise.Kind}] {premise.Id}: {premise.Description}");
            output.AppendLine($"    JUSTIFICATION: {link.Justification}");
            if (premise.SourceUrl is not null)
                output.AppendLine($"    SOURCE: {premise.SourceUrl}");
        }
        output.Append("  NOTE: Tracing connections does not validate an inference or settle ontology.");
        return output.ToString();
    }

    private string ShowExperiment()
    {
        var review = report.Experiment;
        var plan = review.Plan;
        var output = new StringBuilder().AppendLine($"EXPERIMENT: {plan.Question}").AppendLine($"  STATUS: {plan.Status}").AppendLine($"  PROCEDURE: {plan.Procedure}").AppendLine($"  CONTROLS: {plan.ControlledFactors}").AppendLine($"  MEASUREMENT: {plan.Measurement}");
        foreach (var prediction in plan.Predictions)
        {
            output.AppendLine($"  PREDICTION [{prediction.Id}] {prediction.ModelVariant}");
            output.AppendLine($"    CONDITIONS: {prediction.Conditions}");
            output.AppendLine($"    EXPECTED: {prediction.ExpectedObservation}");
            output.AppendLine($"    POSSIBLE CHALLENGE: {prediction.PotentialCounterObservation}");
            var evaluation = review.Evaluations.FirstOrDefault(x => x.PredictionId == prediction.Id);
            output.AppendLine($"    ASSESSMENT: {evaluation?.Assessment ?? PredictionAssessment.NotEvaluated}");
            if (evaluation is not null)
            {
                output.AppendLine($"    RECORDED OBSERVATION: {evaluation.Observation.Description}");
                output.AppendLine($"    OBSERVATION SOURCE: {evaluation.Observation.SourceUrl}");
                output.AppendLine($"    INTERPRETATION RATIONALE: {evaluation.Rationale}");
            }
        }
        output.AppendLine($"  INTERPRETATION LIMITS: {plan.InterpretationLimits}");
        if (plan.SourceUrl is not null)
            output.AppendLine($"  INSPIRATION SOURCE (not new evidence): {plan.SourceUrl}");
        return output.ToString().TrimEnd();
    }

    private string ShowReport()
    {
        var output = new StringBuilder().AppendLine($"INVESTIGATION: {report.Question}");
        output.AppendLine($"  RELEVANT SCIENTIFIC FINDINGS: {report.RelevantFindings.Count}");
        foreach (var finding in report.RelevantFindings)
            output.AppendLine($"    [{finding.Status}] {finding.Subject}");
        output.AppendLine($"  COMPETING THEORY ACCOUNTS: {report.TheoryAssessments.Count}");
        foreach (var assessment in report.TheoryAssessments)
            output.AppendLine($"    {assessment.TheoryName}: {assessment.TopicMatchedExplanations.Count} topic matches (not empirical support); {assessment.OpenQuestions.Count} open questions");
        output.AppendLine($"  PHILOSOPHICAL DEBATES: {report.TheoryDebates.Sum(x => x.Debates.Count)} (no verdicts)");
        output.AppendLine($"  REASONING NODES: {report.Reasoning.Nodes.Count}");
        output.AppendLine($"  EXPERIMENT STATUS: {report.Experiment.Plan.Status}; {report.Experiment.Evaluations.Count} evaluated observations");
        output.Append("  LIMIT: Neither topic matches nor experimental signatures establish ultimate ontology.");
        return output.ToString();
    }
}
