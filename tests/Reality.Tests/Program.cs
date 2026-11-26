using Reality.Core.Consciousness;
using Reality.Core.Epistemology;
using Reality.Core.Observation;
using Reality.Core.Ontology;
using Reality.Investigation.Workflow;
using Reality.Investigation.Comparison;
using Reality.Investigation.Reasoning;
using Reality.Philosophy.Catalog;
using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Models;
using Reality.Philosophy.Theories;
using Reality.Philosophy.Theories.Panpsychism;
using Reality.Science.Biology;
using Reality.Science.Consciousness;
using Reality.Science.Culture;
using Reality.Science.Emergence;
using Reality.Science.Epistemology;
using Reality.Science.Observation;
using Reality.Science.Physics;
using Reality.Science.Physics.Holography;
using Reality.Science.Physics.Holography.Interfaces;
using Reality.Science.Physics.Interfaces;

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
Check(new Reality.Science.Emergence.EmergenceModel().Analyze([ true, true, false ]).HasConnectedCluster, "emergence");
Check(new CulturalEvolution().Transmit([ new CulturalLearner("A", true), new CulturalLearner("B", false), new CulturalLearner("C", false) ], 2).FinalKnowledgeHolders == 3, "culture");
Check(new NervousSystem().Learn("observation").Contains("Learned from observation"), "nervous system");

var reasoning = ConsciousnessReasoningExample.Create();
var inference = reasoning.GetNode(ConsciousnessReasoningExample.MainInferenceId);
Check(inference.Kind == ReasoningNodeKind.Inference, "consciousness example has an explicit inference");
Check(reasoning.Incoming(inference.Id).Count == 3, "inference links to observations and a stated assumption");
var incomingReasons = reasoning.TraceReasons(inference.Id);
Check(incomingReasons.Count == 5, "reasoning trace reaches two observation sources and the methodological assumption");
Check(incomingReasons.Any(link => reasoning.GetNode(link.FromId).SourceUrl?.Contains("doi.org") == true), "reasoning trace exposes publication provenance");
Check(reasoning.Connections.Count(link => link.Relation == ReasoningRelation.Challenges) == 2, "empirical challenges are distinguished from disproof");
Check(reasoning.Connections.Count(link => link.Relation == ReasoningRelation.RaisesQuestion) == 2, "graph retains separate neural and metaphysical open questions");
try
{
    _ = new ReasoningGraph([new ReasoningNode("a", ReasoningNodeKind.Inference, "claim")], [new ReasoningConnection("missing", "a", ReasoningRelation.Supports, "justification")]);
    throw new Exception("FAIL: graph accepted missing endpoint");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: graph rejects missing endpoints");
}
try
{
    _ = new ReasoningGraph([new ReasoningNode("x", ReasoningNodeKind.Inference, "first"), new ReasoningNode("x", ReasoningNodeKind.Inference, "second")], []);
    throw new Exception("FAIL: graph accepted duplicate node IDs");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: graph rejects duplicate IDs");
}
var cycle = new ReasoningGraph(
    [new ReasoningNode("a", ReasoningNodeKind.Inference, "first"), new ReasoningNode("b", ReasoningNodeKind.Assumption, "second")],
    [new ReasoningConnection("a", "b", ReasoningRelation.Supports, "first link"), new ReasoningConnection("b", "a", ReasoningRelation.RequiresAssumption, "second link")]);
Check(cycle.TraceReasons("a").Count == 2, "trace terminates on cycles");

var catalog = ScientificCatalog.Create();
var report = new RealityInvestigator(new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog), TheoryCatalog.All, catalog).InvestigateConsciousness();
Check(report.Reasoning.Nodes.Count > 5 && report.TheoryAssessments.Count == 4, "investigation composes science and philosophy without changing findings");
Check(report.RelevantFindings.Count == 2 && report.RelevantFindings.Any(x => x.Subject == "Subjective experience"), "investigation preserves the epistemic gap");
Check(catalog.Investigations.Count == 3, "catalog includes explicit epistemic investigations");
Check(catalog.GetInvestigation("dark MATTER")?.FindingSubject == "Dark matter", "investigation lookup is case-insensitive");
Check(catalog.GetInvestigation("General relativity") is null, "missing evidence trail is not fabricated");
Check(catalog.Investigations.All(i => i.Observations.Count > 0 && i.Assumptions.Count > 0 && i.Alternatives.Count > 0 && i.PotentialTests.Count > 0), "investigations expose evidence, inference, assumptions, alternatives and tests");
Check(catalog.Investigations.All(i => i.SourceStatus.Contains("not yet attached")), "unverified study provenance is explicitly disclosed");
try
{
    _ = new ScientificCatalog([ new Finding("Known", "A test", EvidenceStatus.Observed) ], [ new ScientificInvestigation("Unknown", [ "obs" ], "inference", [ "assumption" ], [ "alternative" ], [ "test" ], "no provenance") ]);
    throw new Exception("FAIL: orphaned investigation accepted");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: orphaned investigation rejected");
}
var universe = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
var second = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog);
Check(universe.DescribeHistory().SequenceEqual(second.DescribeHistory()), "same observable history regardless of theory");
Check(universe.CreateObserver().DoScience().SequenceEqual(second.CreateObserver().DoScience()), "same observable findings");
Check(universe.DescribeHistory().Count >= 14, "shared chronology");
Check(typeof(IObservableUniverse).GetMethod("CreateObserver")?.ReturnType == typeof(IObserver), "Core observer contract does not depend on scientific implementation");
Check(typeof(IExperience).IsAssignableFrom(typeof(IUnifiedConsciousness)), "unified experience still derives from experience");
Check(typeof(IUnifiedConsciousness).GetMethod("Reflect") is null, "unified experience does not require reflection");
Check(typeof(IObserver).GetMethod("Reflect") is not null, "reflection belongs to the observer contract");
var humanObserver = universe.CreateObserver();
Check(humanObserver is IUnifiedConsciousness, "illustrative human observer may model unified experience");
Check(humanObserver.Reflect().Contains("observer"), "human observer retains reflective behavior");
Check(typeof(IReality).Namespace == "Reality.Core.Ontology", "reality interface follows ontology folder namespace");
Check(typeof(IObservableUniverse).Namespace == "Reality.Core.Observation", "observable interface follows observation interfaces namespace");
Check(typeof(ObservedUniverse).Namespace == "Reality.Science.Observation", "observable model follows observation folder namespace");
Check(typeof(ScientificCatalog).Namespace == "Reality.Science.Epistemology", "scientific catalog belongs to epistemology domain");
Check(typeof(IExperience).Namespace == "Reality.Core.Consciousness", "consciousness interface namespace aligns with folder");
Check(typeof(ILawsOfPhysics).Namespace == "Reality.Science.Physics.Interfaces", "physics interface namespace aligns with folder");
Check(typeof(IHolographicDuality).Namespace == "Reality.Science.Physics.Holography.Interfaces", "holography interface namespace aligns with folder");
Check(typeof(IReality).GetProperties().Select(p => p.Name).SequenceEqual([ "ObservableUniverse" ]), "IReality only exposes observable facet");
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

try { CombinationProblem.Combine([ new FundamentalExperience("hypothetical") ]); throw new Exception("FAIL: combination solved"); }
catch (NotSupportedException) { Console.WriteLine("PASS: combination remains unresolved"); }

var duality = new CelestialHolography();
Check(duality.CorrespondenceStatus == HolographicCorrespondenceStatus.PartialResults, "qualified holography status");
Check(duality.Bulk is FourDimensionalScatteringDescription && duality.Boundary is CelestialConformalDescription, "physical descriptions kept");
Check(Math.Abs(new CelestialHolography().DemonstrateEnergyMellinTransform([ new EnergyAmplitudeSample(1, 1), new EnergyAmplitudeSample(2, 1), new EnergyAmplitudeSample(3, 1) ], 1).ApproximateValue - 2) < 1e-10, "Mellin demo");
Check(new PhysicalDescriptionStudy().Summarize(duality).Contains("PartialResults"), "study independent of metaphysics");
try { new CelestialHolography().ReconstructFullBulk(); throw new Exception("FAIL: full reconstruction claimed"); }
catch (NotSupportedException) { Console.WriteLine("PASS: full reconstruction unresolved"); }
Console.WriteLine("All smoke checks passed.");
