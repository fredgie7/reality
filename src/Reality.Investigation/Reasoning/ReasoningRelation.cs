namespace Reality.Investigation.Reasoning;

/// <summary>Directed relationships are claims requiring justification, never automated proofs.</summary>
public enum ReasoningRelation
{
    Documents,
    Supports,
    Challenges,
    RequiresAssumption,
    RaisesQuestion
}
