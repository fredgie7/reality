using Reality.Core.Epistemology;
using Reality.Investigation.Comparison;
using Reality.Investigation.Reasoning;

namespace Reality.Investigation.Workflow;

/// <summary>An inventory of evidence and competing interpretations, not a verdict about ontology.</summary>
public sealed record InvestigationReport(string Question, IReadOnlyList<Finding> RelevantFindings, ReasoningGraph Reasoning, IReadOnlyList<TheoryAssessment> TheoryAssessments);
