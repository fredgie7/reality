namespace Reality.Biology;

public sealed class Population
{
    private readonly List<Organism> _organisms;
    private Population(IEnumerable<Organism> organisms) => _organisms = organisms.ToList();

    public IReadOnlyList<Organism> Organisms => _organisms;
    public int Generation { get; private set; }

    public static Population Create(int size, int seed)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
        var random = new Random(seed);
        return new Population(Enumerable.Range(0, size).Select(_ => new Organism(random.NextDouble())));
    }

    internal void Replace(IEnumerable<Organism> next)
    {
        _organisms.Clear();
        _organisms.AddRange(next);
        Generation++;
    }
}
