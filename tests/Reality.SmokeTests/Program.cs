using Reality;
using Reality.Biology;
using Reality.Consciousness;
using Reality.Implementations;
using Reality.Implementations.Panpsychism;
using Reality.Philosophy;
using Reality.Physics;

static void Check(bool condition, string description)
{
    if (!condition) throw new Exception($"FAIL: {description}");
    Console.WriteLine($"PASS: {description}");
}

var physics = new KnownPhysics();
Check(physics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight), "light-speed boundary permitted");
Check(!physics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight + 1), "superluminal local signal rejected");
Check(!physics.IsLocallyCausalSignal(double.NaN), "invalid speed rejected");

var evolution = new DarwinianEvolution(42);
var population = Population.Create(80, 99);
for (var generation = 1; generation <= 12; generation++)
{
    var result = evolution.Advance(population, 0.75);
    Check(result.Generation == generation && result.PopulationSize == 80, $"evolution generation {generation}");
    Check(result.MeanTrait is >= 0 and <= 1, "trait within model bounds");
}

var catalog = ScientificCatalog.Create();
IReality firstModel = new PanpsychistReality(physics, new CosmicHistory(), new ChemistryModel(), evolution, catalog);
IReality alternative = new TestReality(physics, new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);

Check(firstModel.Evolve().Count >= 10, "shared cosmic-to-consciousness timeline");
Check(firstModel.Name == "Panpsychism", "first implementation identifies its ontology");
Check(firstModel.MetaphysicalAssumptions.Count > 0, "implementation owns its metaphysical assumptions");
Check(alternative.Name == "Alternative example", "a second IReality implementation can be instantiated");
Check(firstModel.Evolve().SequenceEqual(alternative.Evolve()), "alternate ontology reuses observable timeline");
Check(alternative.CreateObserver().DoScience().Count == firstModel.CreateObserver().DoScience().Count, "observer is implementation-agnostic");
Check(!catalog.Findings.Any(x => x.Subject == "Panpsychism"), "shared scientific catalog does not privilege one ontology");
Check(new TheoryComparison().Theories.Count == 4, "four philosophical theories represented");

try
{
    CombinationProblem.Combine(new IExperience[] { new FundamentalExperience("hypothetical") });
    throw new Exception("FAIL: combination cannot pretend to be implemented");
}
catch (NotSupportedException)
{
    Console.WriteLine("PASS: panpsychist combination problem explicitly unresolved");
}

Console.WriteLine("All smoke checks passed.");

// A test-only implementation proves the interface is not tied to panpsychism.
// It makes no claim that this is a scientifically viable metaphysical model.
sealed class TestReality : RealityBase
{
    public TestReality(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
        : base(physics, cosmos, chemistry, evolution, knowledge) { }

    public override string Name => "Alternative example";
    public override IReadOnlyList<string> MetaphysicalAssumptions => new[] { "Hypothetical alternative for testing polymorphism." };
}
