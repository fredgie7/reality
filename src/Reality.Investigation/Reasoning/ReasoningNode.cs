namespace Reality.Investigation.Reasoning;

/// <summary>A claim or provenance entry. SourceUrl is optional; absence must not imply verification.</summary>
public sealed record ReasoningNode(string Id, ReasoningNodeKind Kind, string Description, string? SourceUrl = null);
