using Reality;
using Reality.Biology;
using Reality.Consciousness;
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
    Check(result.MeanTrait is >= 0 and <= 1, "trait within physical model bounds");
}

var world = new PanpsychistReality(physics, new CosmicHistory(), new ChemistryModel(), evolution, ScientificCatalog.Create());
Check(world.Evolve().Count >= 10, "cosmic-to-consciousness conceptual timeline");
Check(world.CreateObserver().DoScience().Any(x => x.Confidence == EvidenceStatus.PhilosophicalHypothesis), "hypotheses clearly labeled");
Check(new TheoryComparison().Theories.Count == 4, "four theories represented");

try
{
    CombinationProblem.Combine(new IExperience[] { new FundamentalExperience("hypothetical") });
    throw new Exception("FAIL: combination cannot pretend to be implemented");
}
catch (NotSupportedException)
{
    Console.WriteLine("PASS: combination problem explicitly unresolved");
}

Console.WriteLine("All smoke checks passed.");
