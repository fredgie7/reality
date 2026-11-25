namespace Reality.Consciousness;

public interface INervousSystem
{
    Perception Perceive(string stimulus);
    string Remember(string memory);
    string Feel(double arousal);
    string Predict(string observation);
}

public sealed record Perception(string Stimulus, string Representation);

public sealed class NervousSystem : INervousSystem
{
    private readonly List<string> _memories = new();

    public Perception Perceive(string stimulus) => new(stimulus, $"Neural representation of: {stimulus}");
    public string Remember(string memory)
    {
        _memories.Add(memory);
        return $"Stored memory #{_memories.Count}: {memory}";
    }

    public string Feel(double arousal) => arousal switch
    {
        < 0 or > 1 or double.NaN => throw new ArgumentOutOfRangeException(nameof(arousal)),
        < 0.33 => "Low arousal",
        < 0.67 => "Moderate arousal",
        _ => "High arousal"
    };

    public string Predict(string observation) => $"Prediction updated from observed evidence: {observation}";

    // Describes a pedagogical information-processing abstraction.
    // It does NOT implement brains or explain phenomenal experience.
}
