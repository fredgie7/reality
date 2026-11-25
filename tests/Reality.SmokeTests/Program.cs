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
var models = RealityFactory.AvailableModels
    .Select(name => RealityFactory.Create(name, new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog))
    .ToArray();

Check(models.Length == 4, "all four reality interpretations registered");
Check(models.Select(x => x.Name).Distinct().Count() == 4, "each ontology is distinguishable by name");
Check(models.All(x => x.MetaphysicalAssumptions.Count >= 3), "every implementation explicitly states its assumptions");
Check(models.All(x => x.Evolve().Count >= 10), "each model includes the complete shared chronology");
Check(models.Skip(1).All(x => x.Evolve().SequenceEqual(models[0].Evolve())), "models share empirical cosmic and biological chronology");
Check(models.Skip(1).All(x => x.Physics.Principles.Count == models[0].Physics.Principles.Count), "models preserve the same physical principles");
Check(models.Skip(1).All(x => x.CreateObserver().DoScience().SequenceEqual(models[0].CreateObserver().DoScience())), "observers discover identical scientific findings");
Check(models.All(x => x.CreateObserver().DoPhilosophy().Count > 0), "observers can examine philosophical questions in each model");
Check(!catalog.Findings.Any(x => x.Subject == "Panpsychism"), "shared scientific catalog does not privilege an ontology");
Check(new TheoryComparison().Theories.Count == models.Length, "theory comparison covers all implementations");
Check(RealityFactory.Create("PHYSICALISM", physics, new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(9), catalog) is PhysicalistReality, "model selection is case-insensitive");
Check(RealityFactory.Create("idealism", physics, new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(9), catalog) is IdealistReality, "idealism resolves to the correct implementation");
Check(RealityFactory.Create("substance-dualism", physics, new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(9), catalog) is SubstanceDualistReality, "dualism resolves to the correct implementation");

try
{
    RealityFactory.Create("not-a-theory", physics, new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(9), catalog);
    throw new Exception("FAIL: unknown model should be rejected");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: unknown model rejected");
}

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
