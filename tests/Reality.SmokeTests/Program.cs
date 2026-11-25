using Reality;
using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
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

var population = Population.Create(80, 99);
var evolution = new DarwinianEvolution(42);
for (var generation = 1; generation <= 12; generation++)
{
    var result = evolution.Advance(population, 0.75);
    Check(result.Generation == generation && result.PopulationSize == 80, $"evolution generation {generation}");
    Check(result.MeanTrait is >= 0 and <= 1, "trait within model bounds");
}

var genetics = new Genetics();
Check(genetics.Replicate("ATGC") == "ATGC", "DNA replication preserves coding sequence");
Check(genetics.Transcribe("ATGGGT") == "AUGGGU", "DNA transcription");
Check(genetics.Translate("AUGGGUUAA") == "MG", "illustrative translation and stop codon");
Check(genetics.Inherit("AAAA", "CCCC", 2) == "AACC", "simplified inheritance");
Check(genetics.Mutate("AAAA", 1, 'G') == "AGAA", "point mutation");

var spacetime = new Spacetime();
Check(Math.Abs(spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight) - 1) < 1e-10, "light-travel time");
Check(Math.Abs(spacetime.ProperTimeForMovingClock(10, KnownPhysics.SpeedOfLight * 0.6) - 8) < 1e-9, "special relativistic proper time");
Check(spacetime.SchwarzschildRadiusMeters(1.989e30) > 2000, "Schwarzschild radius positive and plausible");

var emergence = new Reality.Emergence.EmergenceModel();
var pattern = emergence.Analyze(new[] { true, true, false, true });
Check(pattern.ActiveComponents == 3 && pattern.AdjacentActivePairs == 1, "collective pattern detected");

var culture = new CulturalEvolution();
var diffusion = culture.Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false), new CulturalLearner("C", false) }, 2);
Check(diffusion.InitialKnowledgeHolders == 1 && diffusion.FinalKnowledgeHolders == 3, "synchronous cultural diffusion");

var nervousSystem = new NervousSystem();
Check(nervousSystem.Learn("experience").Contains("Learned from experience"), "nervous system learning abstraction");
Check(nervousSystem.ChooseBehavior("expected result").Contains("expected result"), "behavior selection abstraction");

var catalog = ScientificCatalog.Create();
var models = RealityFactory.AvailableModels
    .Select(name => RealityFactory.Create(name, new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog))
    .ToArray();

Check(models.Length == 4, "four reality interpretations registered");
Check(models.Select(x => x.Name).Distinct().Count() == 4, "distinct ontologies");
Check(models.All(x => x.Evolve().Count >= 14), "chronology includes shared subsystems");
Check(models.Skip(1).All(x => x.Evolve().SequenceEqual(models[0].Evolve())), "models share observable chronology");
Check(models.Skip(1).All(x => x.CreateObserver().DoScience().SequenceEqual(models[0].CreateObserver().DoScience())), "models share scientific findings");
Check(models.All(x => x.Genetics.Transcribe("ATG") == "AUG"), "genetics available across all interpretations");
Check(models.All(x => x.Spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight) == 1), "spacetime available across all interpretations");
Check(models.All(x => x.Emergence.Analyze(new[] { true, true }).HasConnectedCluster), "emergence available across all interpretations");
Check(models.All(x => x.Culture.Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false) }, 1).FinalKnowledgeHolders == 2), "culture available across all interpretations");
Check(models.All(x => x.NervousSystem.Perceive("signal").Stimulus == "signal"), "nervous system available across all interpretations");
Check(models.All(x => x.MetaphysicalAssumptions.Count >= 3), "ontology-specific assumptions remain distinct");
Check(!catalog.Findings.Any(x => x.Subject == "Panpsychism"), "science catalog is ontology-neutral");
Check(new TheoryComparison().Theories.Count == models.Length, "theory comparison matches available implementations");

try
{
    CombinationProblem.Combine(new IExperience[] { new FundamentalExperience("hypothetical") });
    throw new Exception("FAIL: combination problem must remain unresolved");
}
catch (NotSupportedException)
{
    Console.WriteLine("PASS: panpsychist combination problem remains unresolved");
}

Console.WriteLine("All smoke checks passed.");
