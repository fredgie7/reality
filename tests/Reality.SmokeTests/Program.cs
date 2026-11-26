using Reality;
using Reality.Biology;
using Reality.Consciousness;
using Reality.Culture;
using Reality.Philosophy;
using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Theories;
using Reality.Philosophy.Theories.Panpsychism;
using Reality.Physics;
using Reality.Physics.Holography;

static void Check(bool value, string label)
{
    if (!value) throw new Exception($"FAIL: {label}");
    Console.WriteLine($"PASS: {label}");
}

var physics = new KnownPhysics();
Check(physics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight), "light-speed bound");
Check(!physics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight + 1), "superluminal signal rejected");
Check(!physics.IsLocallyCausalSignal(double.NaN), "invalid signal speed rejected");

var genetics = new Genetics();
Check(genetics.Replicate("ATGC") == "ATGC", "replication toy");
Check(genetics.Transcribe("ATGGGT") == "AUGGGU", "transcription toy");
Check(genetics.Translate("AUGGGUUAA") == "MG", "translation and stop codon toy");
Check(genetics.Inherit("AAAA", "CCCC", 2) == "AACC", "inheritance toy");
Check(genetics.Mutate("AAAA", 1, 'G') == "AGAA", "mutation toy");

var spacetime = new Spacetime();
Check(spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight) == 1, "light travel");
Check(Math.Abs(spacetime.ProperTimeForMovingClock(10, KnownPhysics.SpeedOfLight * 0.6) - 8) < 1e-9, "time dilation");
Check(spacetime.SchwarzschildRadiusMeters(1.989e30) > 2000, "Schwarzschild radius");

var population = Population.Create(80, 99);
var evolution = new DarwinianEvolution(42);
for (var i = 1; i <= 12; i++)
{
    var result = evolution.Advance(population, 0.75);
    Check(result.Generation == i && result.PopulationSize == 80 && result.MeanTrait is >= 0 and <= 1, $"evolution {i}");
}
Check(new Reality.Emergence.EmergenceModel().Analyze(new[] { true, true, false }).HasConnectedCluster, "emergence");
Check(new CulturalEvolution().Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false), new CulturalLearner("C", false) }, 2).FinalKnowledgeHolders == 3, "culture");
Check(new NervousSystem().Learn("observation").Contains("Learned from observation"), "nervous system");

var catalog = ScientificCatalog.Create();
Check(catalog.Investigations.Count == 3, "catalog includes explicit epistemic investigations");
Check(catalog.GetInvestigation("dark MATTER")?.FindingSubject == "Dark matter", "investigation lookup is case-insensitive");
Check(catalog.GetInvestigation("General relativity") is null, "missing evidence trail is not fabricated");
Check(catalog.Investigations.All(i => i.Observations.Count > 0 && i.Assumptions.Count > 0 && i.Alternatives.Count > 0 && i.PotentialTests.Count > 0), "investigations expose evidence, inference, assumptions, alternatives and tests");
Check(catalog.Investigations.All(i => i.SourceStatus.Contains("not yet attached")), "unverified study provenance is explicitly disclosed");
try
{
    _ = new ScientificCatalog(new[] { new Finding("Known", "A test", EvidenceStatus.Observed) }, new[] { new ScientificInvestigation("Unknown", new[] { "obs" }, "inference", new[] { "assumption" }, new[] { "alternative" }, new[] { "test" }, "no provenance") });
    throw new Exception("FAIL: orphaned investigation accepted");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: orphaned investigation rejected");
}
IObservableUniverse universe = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
IObservableUniverse second = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
Check(universe.DescribeHistory().SequenceEqual(second.DescribeHistory()), "same observable history regardless of theory");
Check(universe.CreateObserver().DoScience().SequenceEqual(second.CreateObserver().DoScience()), "same observable findings");
Check(universe.DescribeHistory().Count >= 14, "shared chronology");
Check(typeof(IReality).Namespace == "Reality.Ontology.Interfaces", "reality interface follows ontology folder namespace");
Check(typeof(IObservableUniverse).Namespace == "Reality.Observation.Interfaces", "observable interface follows observation interfaces namespace");
Check(typeof(ObservedUniverse).Namespace == "Reality.Observation", "observable model follows observation folder namespace");
Check(typeof(ScientificCatalog).Namespace == "Reality.Epistemology", "scientific catalog belongs to epistemology domain");
Check(typeof(IExperience).Namespace == "Reality.Consciousness.Interfaces", "consciousness interface namespace aligns with folder");
Check(typeof(ILawsOfPhysics).Namespace == "Reality.Physics.Interfaces", "physics interface namespace aligns with folder");
Check(typeof(IHolographicDuality).Namespace == "Reality.Physics.Holography.Interfaces", "holography interface namespace aligns with folder");
Check(typeof(IReality).GetProperties().Select(p => p.Name).SequenceEqual(new[] { "ObservableUniverse" }), "IReality only exposes observable facet");
Check(!typeof(IReality).IsAssignableFrom(typeof(ObservedUniverse)), "observed universe is not actual reality");
Check(!typeof(IReality).IsAssignableFrom(typeof(ITheoryOfReality)), "a theory is not reality");

var theories = TheoryCatalog.All;
Check(theories.Count == 4 && theories.Select(x => x.Name).Distinct().Count() == 4, "four distinct theories");
Check(theories.All(x => x.Assumptions.Count >= 2 && x.OpenQuestions.Count >= 2), "explicit assumptions and problems");
Check(theories.All(x => x.Predictions.Count == 0), "no fabricated discriminating predictions");
Check(TheoryCatalog.Find("pHySiCaLiSm") is PhysicalistTheory, "case-insensitive lookup");
Check(TheoryCatalog.Find("Idealism") is IdealistTheory, "idealist lookup");
Check(TheoryCatalog.Find("Substance dualism") is SubstanceDualistTheory, "dualist lookup");
try { TheoryCatalog.Find("unknown"); throw new Exception("FAIL: unknown theory accepted"); }
catch (ArgumentException) { Console.WriteLine("PASS: unknown theory rejected"); }

var assessments = new TheoryComparisonService().Compare(theories, catalog);
Check(assessments.Count == 4, "all theories assessed");
Check(assessments.All(x => x.CatalogLinkedExplanations.Count >= 1), "claims link to catalog topics");
Check(assessments.All(x => x.UnmatchedExplanations.Count == 0), "no invalid topic references");
Check(assessments.All(x => x.ProposedPredictions.Count == 0), "no invented experimental discriminators");

try { CombinationProblem.Combine(new IExperience[] { new FundamentalExperience("hypothetical") }); throw new Exception("FAIL: combination solved"); }
catch (NotSupportedException) { Console.WriteLine("PASS: combination remains unresolved"); }

IHolographicDuality duality = new CelestialHolography();
Check(duality.CorrespondenceStatus == HolographicCorrespondenceStatus.PartialResults, "qualified holography status");
Check(duality.Bulk is FourDimensionalScatteringDescription && duality.Boundary is CelestialConformalDescription, "physical descriptions kept");
Check(Math.Abs(new CelestialHolography().DemonstrateEnergyMellinTransform(new[] { new EnergyAmplitudeSample(1, 1), new EnergyAmplitudeSample(2, 1), new EnergyAmplitudeSample(3, 1) }, 1).ApproximateValue - 2) < 1e-10, "Mellin demo");
Check(new PhysicalDescriptionStudy().Summarize(duality).Contains("PartialResults"), "study independent of metaphysics");
try { new CelestialHolography().ReconstructFullBulk(); throw new Exception("FAIL: full reconstruction claimed"); }
catch (NotSupportedException) { Console.WriteLine("PASS: full reconstruction unresolved"); }
Console.WriteLine("All smoke checks passed.");
