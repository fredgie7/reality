namespace Reality.Biology;

public interface IBiologicalEvolution
{
    EvolutionReport Advance(Population population, double environmentOptimum);
}

public sealed record EvolutionReport(int Generation, int PopulationSize, double MeanTrait);

// A simple inherited quantitative trait is NOT a model of genomes, species or real ecosystems.
public sealed class Organism
{
    public Organism(double trait) => Trait = Math.Clamp(trait, 0, 1);
    public double Trait { get; }
}

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

public sealed class DarwinianEvolution : IBiologicalEvolution
{
    private readonly Random _random;

    public DarwinianEvolution(int seed) => _random = new Random(seed);

    public EvolutionReport Advance(Population population, double environmentOptimum)
    {
        ArgumentNullException.ThrowIfNull(population);
        if (!double.IsFinite(environmentOptimum) || environmentOptimum is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(environmentOptimum));
        if (population.Organisms.Count == 0)
            throw new InvalidOperationException("Cannot evolve an empty population.");

        // Fixed-size toy model: fitness-weighted parental sampling = selection.
        // Random draws = sampling drift. Small trait perturbations = mutation.
        // This is NOT a demonstration of speciation or real genetic recombination.
        var parents = population.Organisms.ToArray();
        var weights = parents.Select(p => Math.Exp(-8 * Math.Pow(p.Trait - environmentOptimum, 2))).ToArray();
        var total = weights.Sum();
        var children = new List<Organism>(parents.Length);

        for (var i = 0; i < parents.Length; i++)
        {
            var ticket = _random.NextDouble() * total;
            var selected = parents.Length - 1;
            for (var j = 0; j < weights.Length; j++)
            {
                ticket -= weights[j];
                if (ticket <= 0)
                {
                    selected = j;
                    break;
                }
            }

            var trait = parents[selected].Trait;
            if (_random.NextDouble() < 0.15)
                trait += (_random.NextDouble() - 0.5) * 0.20;
            children.Add(new Organism(trait));
        }

        population.Replace(children);
        return new EvolutionReport(population.Generation, children.Count, children.Average(x => x.Trait));
    }
}

// Not every evolutionary mechanism belongs in the toy simulator.
public interface IEvolutionaryProcesses
{
    void Mutation();
    void NaturalSelection();
    void GeneticDrift();
    void GeneFlow();
    void Speciation();
    void Extinction();
}
