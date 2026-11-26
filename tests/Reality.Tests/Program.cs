using Reality.Core.Epistemology;
using Reality.Core.Observation;
using Reality.Core.Ontology;
using Reality.Investigation.Workflow;
using Reality.Investigation.Comparison;
using Reality.Investigation.Experiments;
using Reality.Investigation.Reasoning;
using Reality.Investigation.Navigation;
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

Check(KnownPhysics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight), "light-speed bound");
Check(!KnownPhysics.IsLocallyCausalSignal(KnownPhysics.SpeedOfLight + 1), "superluminal signal rejected");
Check(!KnownPhysics.IsLocallyCausalSignal(double.NaN), "invalid signal speed rejected");

Check(Genetics.Replicate("ATGC") == "ATGC", "replication toy");
Check(Genetics.Transcribe("ATGGGT") == "AUGGGU", "transcription toy");
Check(Genetics.Translate("AUGGGUUAA") == "MG", "translation and stop codon toy");
Check(Genetics.Inherit("AAAA", "CCCC", 2) == "AACC", "inheritance toy");
Check(Genetics.Mutate("AAAA", 1, 'G') == "AGAA", "mutation toy");

Check(Spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight) == 1, "light travel");
Check(Math.Abs(Spacetime.ProperTimeForMovingClock(10, KnownPhysics.SpeedOfLight * 0.6) - 8) < 1e-9, "time dilation");
Check(Spacetime.SchwarzschildRadiusMeters(1.989e30) > 2000, "Schwarzschild radius");

var population = Population.Create(80, 99);
var evolution = new DarwinianEvolution(42);
for (var i = 1; i <= 12; i++)
{
    var result = evolution.Advance(population, 0.75);
    Check(result.Generation == i && result.PopulationSize == 80 && result.MeanTrait is >= 0 and <= 1, $"evolution {i}");
}
Check(EmergenceModel.Analyze([ true, true, false ]).HasConnectedCluster, "emergence");
Check(CulturalEvolution.Transmit([ new CulturalLearner("A", true), new CulturalLearner("B", false), new CulturalLearner("C", false) ], 2).FinalKnowledgeHolders == 3, "culture");
Check(new NervousSystem().Learn("observation").Contains("Learned from observation"), "nervous system");

var reasoning = ConsciousnessReasoningExample.Create();
var inference = reasoning.GetNode(ConsciousnessReasoningExample.MainInferenceId);
Check(inference.Kind == ReasoningNodeKind.Inference, "consciousness example has an explicit inference");
Check(reasoning.Incoming(inference.Id).Count == 3, "inference links to observations and a stated assumption");
var incomingReasons = reasoning.TraceReasons(inference.Id);
Check(incomingReasons.Count == 5, "reasoning trace reaches two observation sources and the methodological assumption");
Check(incomingReasons.Any(link => reasoning.GetNode(link.FromId).SourceUrl?.Contains("doi.org") == true), "reasoning trace exposes publication provenance");
Check(reasoning.Connections.Count(link => link.Relation == ReasoningRelation.Challenges) == 3, "three study-specific challenges represented without claiming disproof");
Check(reasoning.Connections.Any(link => link.FromId == "offset-observation" && link.ToId == "gnwt" && link.Relation == ReasoningRelation.Challenges), "GNWT challenge traces to missing offset ignition");
Check(reasoning.Connections.Any(link => link.FromId == "prefrontal-limitation" && link.ToId == "gnwt" && link.Relation == ReasoningRelation.Challenges), "GNWT challenge traces to limited prefrontal content representation");
Check(reasoning.Connections.Any(link => link.FromId == "posterior-synchrony-observation" && link.ToId == "iit" && link.Relation == ReasoningRelation.Challenges), "IIT challenge traces to missing sustained posterior synchronization");
Check(reasoning.Connections.All(link => link.Relation != ReasoningRelation.Challenges || link.FromId is not "neural-observation" and not "duration-observation"), "supportive observations are not mislabeled as theory challenges");
Check(reasoning.Incoming("gnwt-offset-dispute").Any(link => reasoning.GetNode(link.FromId).SourceUrl?.Contains("10.1093/nc/niaf037") == true), "published GNWT objection remains visible");
Check(reasoning.Connections.Count(link => link.Relation == ReasoningRelation.RaisesQuestion) == 3, "graph retains separate neural and metaphysical open questions");
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
Check(report.RelevantFindings.Count == 2 && report.RelevantFindings.Any(x => x.Subject == FindingSubjects.SubjectiveExperience), "investigation preserves the epistemic gap");
Check(report.TheoryDebates.Count == 4 && report.TheoryDebates.SelectMany(x => x.Debates).Count() == 8, "investigation includes eight sourced debates without inventing scores");
var navigator = new InvestigationNavigator(catalog, TheoryCatalog.All, report);
Check(navigator.Execute(NavigationCommands.Help).Output.Contains("trace <node-id>"), "navigation help documents evidence tracing");
Check(navigator.Execute(NavigationCommands.Findings).Output.Contains(FindingSubjects.NeuralCorrelates), "finding browser lists real catalog entries");
Check(navigator.Execute($"finding {FindingSubjects.CosmicExpansion}").Output.Contains("Primary study references and datasets are not attached"), "finding details preserve provenance warnings");
Check(navigator.Execute($"finding {FindingSubjects.GeneralRelativity}").Output.Contains("Not curated"), "missing scientific investigation is not fabricated");
Check(navigator.Execute("finding not-a-topic").Output.Contains("No finding named"), "unknown findings receive safe feedback");
Check(navigator.Execute(NavigationCommands.Theories).Output.Contains("Substance dualism"), "theory browser lists selected perspectives");
Check(navigator.Execute("theory Physicalism").Output.Contains("POSSIBLE RESPONSE (not a solution)"), "theory details expose objections, replies and unresolved questions");
Check(navigator.Execute("theory Physicalism").Output.Contains("None currently specified"), "theory browsing does not invent metaphysical predictions");
Check(navigator.Execute(NavigationCommands.Evidence).Output.Contains("neural-content-inference"), "evidence browser lists graph identifiers");
Check(navigator.Execute("trace neural-content-inference").Output.Contains("https://doi.org/"), "reason tracing includes upstream publication provenance");
Check(navigator.Execute("trace missing-node").Output.Contains("Unknown evidence node"), "unknown graph nodes are handled");
Check(navigator.Execute(NavigationCommands.Experiments).Output.Contains("NotEvaluated"), "experiment browser preserves absence of study outcomes");
Check(navigator.Execute(NavigationCommands.Report).Output.Contains("not empirical support"), "summary distinguishes topic matching from evidence");
Check(navigator.Execute("invalidcommand").Output.Contains("Unknown command"), "unknown commands show guidance");
Check(navigator.Execute(NavigationCommands.Quit).ShouldExit, "quit ends the interactive session");
Check(!navigator.Execute(NavigationCommands.Help).ShouldExit, "normal navigation continues");
Check(new InvestigationNavigator(catalog, [TheoryCatalog.Find("Physicalism")], new RealityInvestigator(new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(42), catalog), [TheoryCatalog.Find("Physicalism")], catalog).InvestigateConsciousness()).Execute(NavigationCommands.Theories).Output.Contains("Physicalism"), "selected theory navigation can be scoped");

var proposal = ConsciousnessExperimentExample.Create();
var proposedReview = ExperimentReviewService.Review(proposal);
Check(proposal.Status == ExperimentStatus.Proposed && proposedReview.Evaluations.Count == 0, "proposed study contains no fabricated observations or outcomes");
Check(proposal.Predictions.Count == 2 && proposal.Predictions.Select(p => p.Id).Distinct().Count() == 2, "conditional predictions have stable distinct IDs");
Check(proposal.Predictions.All(p => !string.IsNullOrWhiteSpace(p.PotentialCounterObservation)), "each conditional prediction specifies what could challenge it");
Check(proposedReview.Plan.InterpretationLimits.Contains("not automatically mutually exclusive"), "different neural signatures do not imply exhaustive alternatives");
Check(report.Experiment.Plan.Id == proposal.Id && report.Experiment.Evaluations.Count == 0, "investigation includes unevaluated design without changing theory predictions");
try
{
    _ = ExperimentReviewService.Review(proposal, [new PredictionEvaluation(proposal.Id, proposal.Predictions[0].Id, PredictionAssessment.ConsistentWithPrediction, "fabricated", new RecordedObservation(proposal.Id, "fabricated", "https://example.com"))]);
    throw new Exception("FAIL: proposed study accepted observations");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: proposed study rejects claimed results");
}
try
{
    _ = ExperimentReviewService.Review(proposal with { Predictions = [proposal.Predictions[0], proposal.Predictions[0]] });
    throw new Exception("FAIL: duplicate prediction IDs accepted");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: duplicate prediction IDs rejected");
}
var publishedFixture = proposal with { Status = ExperimentStatus.Published };
var observationFixture = new RecordedObservation(proposal.Id, "Illustrative synthetic observation; not real research data", "https://example.com/research");
var evaluatedFixture = ExperimentReviewService.Review(publishedFixture, [new PredictionEvaluation(proposal.Id, proposal.Predictions[0].Id, PredictionAssessment.Inconclusive, "Synthetic fixture demonstrates an explicit interpretation with provenance, not a scientific conclusion.", observationFixture)]);
Check(evaluatedFixture.Evaluations.Count == 1 && evaluatedFixture.Evaluations[0].Assessment == PredictionAssessment.Inconclusive, "explicitly justified observation can be recorded without auto-ranking");
try
{
    _ = ExperimentReviewService.Review(publishedFixture, [new PredictionEvaluation(proposal.Id, proposal.Predictions[0].Id, PredictionAssessment.ConsistentWithPrediction, "", observationFixture)]);
    throw new Exception("FAIL: unreasoned assessment accepted");
}
catch (ArgumentException)
{
    Console.WriteLine("PASS: assessment requires rationale");
}

Check(catalog.Investigations.Count == 3, "catalog includes explicit epistemic investigations");
Check(catalog.GetInvestigation("dark MATTER")?.FindingSubject == FindingSubjects.DarkMatter, "investigation lookup is case-insensitive");
Check(catalog.GetInvestigation(FindingSubjects.GeneralRelativity) is null, "missing evidence trail is not fabricated");
Check(catalog.Investigations.All(i => i.Observations.Count > 0 && i.Assumptions.Count > 0 && i.Alternatives.Count > 0 && i.PotentialTests.Count > 0), "investigations expose evidence, inference, assumptions, alternatives and tests");
Check(catalog.Investigations.All(i => i.SourceStatus == SourceProvenanceStatus.NotAttached), "default investigations explicitly lack attached primary sources");
Check(catalog.Investigations.All(i => i.SourceNotes is null), "source notes remain optional and do not duplicate status descriptions");
Check(catalog.Findings.All(finding => !string.IsNullOrWhiteSpace(finding.Subject)), "all built-in scientific subjects retain usable keys");
Check(catalog.GetInvestigation(FindingSubjects.CosmicExpansion)?.FindingSubject == FindingSubjects.CosmicExpansion, "shared subject keys connect catalog investigations");
Check(new Event(EventDomain.Biology, "illustrative").Domain == EventDomain.Biology, "chronology domain is a typed classification");
Check(typeof(Finding).GetProperty("Confidence") is null && typeof(Finding).GetProperty("Status")?.PropertyType == typeof(EvidenceStatus), "finding classification is a status, not a confidence score");
try
{
    _ = new ScientificCatalog([ new Finding("Known", "A test", EvidenceStatus.Observed) ], [ new ScientificInvestigation("Unknown", [ "obs" ], "inference", [ "assumption" ], [ "alternative" ], [ "test" ], SourceProvenanceStatus.NotAttached) ]);
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
Check(universe.DescribeHistory().Select(x => x.Domain).Distinct().Count() == Enum.GetValues<EventDomain>().Length, "chronology includes every declared event domain");
Check(typeof(IObservableUniverse).GetMethod("CreateObserver")?.ReturnType == typeof(IObserver), "Core observer contract does not depend on scientific implementation");
Check(typeof(IReality).Assembly.GetTypes().All(type => type.Name is not "IExperience" and not "IUnifiedConsciousness"), "Core does not expose contracts that imply software instantiates experience");
Check(typeof(HumanObserver).GetInterfaces().SequenceEqual([typeof(IObserver)]), "human observer models only the observer contract");
var humanObserver = universe.CreateObserver();
Check(humanObserver is HumanObserver, "universe constructs the illustrative human observer");
Check(humanObserver.Reflect().Contains("observer"), "human observer retains reflective behavior");
Check(HumanObserver.DescribeExperienceReports().Contains("Humans report"), "observer describes human experience reports without claiming to experience them");
Check(typeof(IReality).Namespace == "Reality.Core.Ontology", "reality interface follows ontology folder namespace");
Check(typeof(IObservableUniverse).Namespace == "Reality.Core.Observation", "observable interface follows observation interfaces namespace");
Check(typeof(ObservedUniverse).Namespace == "Reality.Science.Observation", "observable model follows observation folder namespace");
Check(typeof(ScientificCatalog).Namespace == "Reality.Science.Epistemology", "scientific catalog belongs to epistemology domain");
Check(typeof(ILawsOfPhysics).Namespace == "Reality.Science.Physics.Interfaces", "physics interface namespace aligns with folder");
Check(typeof(IHolographicDuality).Namespace == "Reality.Science.Physics.Holography.Interfaces", "holography interface namespace aligns with folder");
Check(typeof(IReality).GetProperties().Select(p => p.Name).SequenceEqual([ "ObservableUniverse" ]), "IReality only exposes observable facet");
Check(!typeof(IReality).IsAssignableFrom(typeof(ObservedUniverse)), "observed universe is not actual reality");
Check(!typeof(IReality).IsAssignableFrom(typeof(ITheoryOfReality)), "a theory is not reality");

var theories = TheoryCatalog.All;
Check(theories.Count == 4 && theories.Select(x => x.Name).Distinct().Count() == 4, "four distinct theories");
Check(theories.All(x => x.Assumptions.Count >= 2 && x.OpenQuestions.Count >= 2), "explicit assumptions and problems");
Check(theories.All(x => x.Predictions.Count == 0), "no fabricated discriminating predictions");
Check(theories.All(x => x.Debates.Count >= 2), "each broad ontology has multiple explicitly scoped arguments");
Check(theories.SelectMany(x => x.Debates).All(x => !string.IsNullOrWhiteSpace(x.VariantScope) && !string.IsNullOrWhiteSpace(x.Objection) && !string.IsNullOrWhiteSpace(x.PossibleResponse) && !string.IsNullOrWhiteSpace(x.RemainingQuestion)), "debates distinguish variant, objection, possible reply and remaining question");
var debateReviews = TheoryDebateService.Review(theories);
Check(debateReviews.Count == theories.Count && debateReviews.All(x => x.Debates.Count >= 2), "all competing accounts receive a debate review");
Check(debateReviews.SelectMany(x => x.Debates).All(x => Uri.TryCreate(x.SourceUrl, UriKind.Absolute, out var url) && url.Scheme == Uri.UriSchemeHttps), "debates have traceable HTTPS philosophical sources");
Check(TheoryDebateService.Review([TheoryCatalog.Find("Physicalism")]).Count == 1, "selected theory debate remains independently inspectable");
try
{
    _ = TheoryDebateService.Review([new PanpsychistTheory()]);
    Console.WriteLine("PASS: theory debate source checking");
}
catch (ArgumentException)
{
    throw new Exception("FAIL: valid philosophical debate rejected");
}

Check(TheoryCatalog.Find("pHySiCaLiSm") is PhysicalistTheory, "case-insensitive lookup");
Check(TheoryCatalog.Find("Idealism") is IdealistTheory, "idealist lookup");
Check(TheoryCatalog.Find("Substance dualism") is SubstanceDualistTheory, "dualist lookup");
try { TheoryCatalog.Find("unknown"); throw new Exception("FAIL: unknown theory accepted"); }
catch (ArgumentException) { Console.WriteLine("PASS: unknown theory rejected"); }

var assessments = TheoryComparisonService.Compare(theories, catalog);
Check(assessments.Count == 4, "all theories assessed");
Check(assessments.All(x => x.TopicMatchedExplanations.Count >= 1), "explanations match named topics without implying empirical support");
Check(assessments.All(x => x.UnmatchedTopicExplanations.Count == 0), "no invalid topic references");
Check(assessments.All(x => x.ProposedPredictions.Count == 0), "no invented experimental discriminators");
Check(typeof(TheoryAssessment).GetProperty("CatalogLinkedExplanations") is null, "old evidentially ambiguous comparison property is absent");

Check(typeof(FundamentalExperience).GetInterfaces().All(type => type != typeof(IObserver)), "hypothetical panpsychist entities do not implement observer contracts");
Check(typeof(CombinationProblem).GetMethod("Combine")?.ReturnType == typeof(void), "combination problem does not promise a unified-consciousness object");
try { CombinationProblem.Combine([new FundamentalExperience("hypothetical")]); throw new Exception("FAIL: combination solved"); }
catch (NotSupportedException) { Console.WriteLine("PASS: combination remains unresolved"); }

var duality = new CelestialHolography();
Check(duality.CorrespondenceStatus == HolographicCorrespondenceStatus.PartialResults, "qualified holography status");
Check(duality.Bulk is FourDimensionalScatteringDescription && duality.Boundary is CelestialConformalDescription, "physical descriptions kept");
Check(Math.Abs(CelestialHolography.DemonstrateEnergyMellinTransform([ new EnergyAmplitudeSample(1, 1), new EnergyAmplitudeSample(2, 1), new EnergyAmplitudeSample(3, 1) ], 1).ApproximateValue - 2) < 1e-10, "Mellin demo");
Check(PhysicalDescriptionStudy.Summarize(duality).Contains("PartialResults"), "study independent of metaphysics");
try { new CelestialHolography().ReconstructFullBulk(); throw new Exception("FAIL: full reconstruction claimed"); }
catch (NotSupportedException) { Console.WriteLine("PASS: full reconstruction unresolved"); }
Console.WriteLine("All smoke checks passed.");
