namespace Reality.Science.Culture;

public sealed class CulturalEvolution
{
    public static CulturalReport Transmit(IReadOnlyList<CulturalLearner> learners, int generations)
    {
        ArgumentNullException.ThrowIfNull(learners);
        ArgumentOutOfRangeException.ThrowIfNegative(generations);
        var knowledge = learners.Select(x => x.KnowsIdea).ToArray();
        var initial = knowledge.Count(x => x);

        for (var generation = 0; generation < generations; generation++)
        {
            var next = (bool[])knowledge.Clone();
            for (var i = 0; i < knowledge.Length; i++)
            {
                // Learn from neighbors in this toy model; do not change the current
                // generation in place, which would incorrectly accelerate diffusion.
                if ((i > 0 && knowledge[i - 1]) || (i + 1 < knowledge.Length && knowledge[i + 1]))
                    next[i] = true;
            }
            knowledge = next;
        }

        return new CulturalReport(generations, initial, knowledge.Count(x => x));
    }

    // TODO: Language, cumulative knowledge, creativity, scientific discovery,
    // social networks, misinformation and correction.
}
