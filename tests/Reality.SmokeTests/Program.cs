using Reality;
using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
using Reality.Implementations;
using Reality.Implementations.Panpsychism;
using Reality.Philosophy;
using Reality.Physics;
using Reality.Physics.Holography;

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
var observed = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
var anotherObserved = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
IReality minimalReality = new MetadataOnlyReality();
Check(minimalReality.Name == "No observable universe required", "IReality can be implemented without scientific subsystems");
Check(typeof(IReality).GetProperties().Select(p => p.Name).OrderBy(x => x).SequenceEqual(new[] { "MetaphysicalAssumptions", "Name" }), "IReality does not impose observable-universe components");
Check(observed.DescribeHistory().Count >= 14, "observed universe retains full timeline");
Check(observed.Physics.Principles.Count > 0, "observed universe retains physical principles");
var models = RealityFactory.AvailableModels
    .Select(name => RealityFactory.Create(name))
    .ToArray();

Check(models.Length == 4, "four reality interpretations registered");
Check(models.Select(x => x.Name).Distinct().Count() == 4, "distinct ontologies");
Check(observed.DescribeHistory().Count >= 14, "chronology includes shared subsystems");
Check(observed.DescribeHistory().SequenceEqual(anotherObserved.DescribeHistory()), "models share observable chronology");
Check(observed.CreateObserver().DoScience().SequenceEqual(anotherObserved.CreateObserver().DoScience()), "models share scientific findings");
Check(observed.Genetics.Transcribe("ATG") == "AUG", "genetics available across all interpretations");
Check(observed.Spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight) == 1, "spacetime available across all interpretations");
Check(observed.Emergence.Analyze(new[] { true, true }).HasConnectedCluster, "emergence available across all interpretations");
Check(observed.Culture.Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false) }, 1).FinalKnowledgeHolders == 2, "culture available across all interpretations");
Check(observed.NervousSystem.Perceive("signal").Stimulus == "signal", "nervous system available across all interpretations");
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


IHolographicDuality duality = new CelestialHolography();
var celestial = new CelestialHolography();
Check(duality.Name == "Celestial holography", "generic duality exposes theory name");
Check(duality.OpenQuestions.Count > 0, "generic duality exposes open problems");
Check(duality.CorrespondenceStatus == HolographicCorrespondenceStatus.PartialResults, "celestial correspondence has qualified research status");
Check(!typeof(IHolographicDuality).GetProperties().Any(x => x.Name == "IsCompleteDualityEstablished"), "generic interface does not imply binary scientific certainty");
Check(!typeof(PhysicalDescriptionStudy).GetMethods().Where(x => x.Name == "Summarize").SelectMany(x => x.GetParameters()).Any(x => x.ParameterType == typeof(IReality)), "physical-description study has no ontology dependency");
Check(typeof(IHolographicDuality).GetMethods().All(x => !x.GetParameters().Any(p => p.ParameterType == typeof(EnergyAmplitudeSample) || p.ParameterType == typeof(IReadOnlyList<EnergyAmplitudeSample>))), "generic interface has no celestial data types");
Check(typeof(IHolographicDuality).GetMethods().All(x => x.Name != nameof(CelestialHolography.ReconstructFullBulk)), "generic interface does not impose bulk reconstruction");
Check(duality.Bulk is FourDimensionalScatteringDescription, "bulk scattering description present");
Check(duality.Boundary is CelestialConformalDescription, "celestial description present");
var energySamples = new[] { new EnergyAmplitudeSample(1, 1), new EnergyAmplitudeSample(2, 1), new EnergyAmplitudeSample(3, 1) };
Check(Math.Abs(celestial.DemonstrateEnergyMellinTransform(energySamples, 1).ApproximateValue - 2) < 1e-10, "toy Mellin transform for Delta 1");
Check(Math.Abs(celestial.DemonstrateEnergyMellinTransform(energySamples, 2).ApproximateValue - 4) < 1e-10, "toy Mellin transform for Delta 2");
Check(new PhysicalDescriptionStudy().Summarize(duality).Contains(duality.Name), "physical-description study uses the correspondence only");
Check(new PhysicalDescriptionStudy().Summarize(duality).Contains("PartialResults"), "study communicates qualified research status");
try
{
    celestial.DemonstrateEnergyMellinTransform(new[] { new EnergyAmplitudeSample(2, 1), new EnergyAmplitudeSample(1, 1) }, 1);
    throw new Exception("FAIL: out-of-order samples accepted");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: unordered samples rejected");
}
try
{
    celestial.ReconstructFullBulk();
    throw new Exception("FAIL: unsupported full reconstruction succeeded");
}
catch (NotSupportedException)
{
    Console.WriteLine("PASS: full reconstruction explicitly unresolved");
}

Console.WriteLine("All smoke checks passed.");

sealed class MetadataOnlyReality : IReality
{
    public string Name => "No observable universe required";
    public IReadOnlyList<string> MetaphysicalAssumptions => new[] { "A purely hypothetical example." };
}
