namespace Reality.Investigation.Reasoning;

/// <summary>FromId points toward ToId; the justification states why that link was proposed.</summary>
public sealed record ReasoningConnection(string FromId, string ToId, ReasoningRelation Relation, string Justification);
