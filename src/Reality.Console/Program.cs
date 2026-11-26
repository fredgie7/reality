using Reality.Investigation.Workflow;
using Reality.Investigation.Experiments;
using Reality.Investigation.Reasoning;
using Reality.Philosophy.Catalog;
using Reality.Philosophy.Interfaces;
using Reality.Science.Biology;
using Reality.Science.Culture;
using Reality.Science.Epistemology;
using Reality.Science.Observation;
using Reality.Science.Physics;
using Reality.Science.Physics.Holography;

var catalog = ScientificCatalog.Create();
var observable = new ObservedUniverse(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(seed: 42), catalog);
IReadOnlyList<ITheoryOfReality> selected;
try
{
    selected = args.Length == 0 || args[0].Equals("all", StringComparison.OrdinalIgnoreCase) ? TheoryCatalog.All : [TheoryCatalog.Find(args[0])];
}
catch (ArgumentException ex)
{
    Console.Error.WriteLine(ex.Message);
    Console.Error.WriteLine("Usage: dotnet run --project src/Reality.Console/Reality.Console.csproj -- [all|Panpsychism|Physicalism|Idealism|\"Substance dualism\"]");
    Environment.ExitCode = 1;
    return;
}
var investigation = new RealityInvestigator(observable, selected, catalog).InvestigateConsciousness();
Console.WriteLine("REALITY :: production diagnostics");
Console.WriteLine("Implementation: unknown | Observable models: revisable | Observer: inside the system");
Console.WriteLine();
foreach (var stage in observable.DescribeHistory())
    Console.WriteLine($"[{stage.Domain}] {stage.Description}");

Console.WriteLine();
Console.WriteLine("SCIENTIFIC FINDINGS");
foreach (var finding in observable.Knowledge.Findings)
    Console.WriteLine($"[{finding.Status}] {finding.Subject}: {finding.Description}");

Console.WriteLine();
Console.WriteLine("PHILOSOPHICAL THEORIES (not alternate scientific universes)");
foreach (var assessment in investigation.TheoryAssessments)
{
    var theory = selected.First(x => x.Name == assessment.TheoryName);
    Console.WriteLine($"> {theory.Name}: {theory.CoreClaim}");
    Console.WriteLine($"  Assumptions: {assessment.StatedAssumptions} | Topic-matched interpretations (not evidential support): {assessment.TopicMatchedExplanations.Count} | Proposed predictions: {assessment.ProposedPredictions.Count}");
    foreach (var explanation in assessment.TopicMatchedExplanations)
        Console.WriteLine($"  INTERPRETATION [{explanation.FindingSubject}]: {explanation.Account}");
    foreach (var question in assessment.OpenQuestions)
        Console.WriteLine($"  OPEN: {question.Description}");
    foreach (var debate in investigation.TheoryDebates.First(x => x.TheoryName == theory.Name).Debates)
    {
        Console.WriteLine($"  DEBATE [{debate.VariantScope}] {debate.Id}");
        Console.WriteLine($"    OBJECTION: {debate.Objection}");
        Console.WriteLine($"    POSSIBLE RESPONSE (not settled): {debate.PossibleResponse}");
        Console.WriteLine($"    STILL OPEN: {debate.RemainingQuestion}");
        Console.WriteLine($"    PHILOSOPHICAL SOURCE: {debate.SourceUrl}");
    }
    if (assessment.ProposedPredictions.Count == 0)
        Console.WriteLine("  No distinguishing empirical prediction has been specified.");
}

Console.WriteLine();
Console.WriteLine("ILLUSTRATIVE SCIENTIFIC MODELS (not evidence for any ontology)");
Console.WriteLine($"GENETICS: ATGGGT -> {observable.Genetics.Transcribe("ATGGGT")} -> {observable.Genetics.Translate("AUGGGU")}");
Console.WriteLine($"SPACETIME: {observable.Spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight):F1}s per light-second.");
Console.WriteLine($"EMERGENCE: {observable.Emergence.Analyze([true, true, false]).AdjacentActivePairs} connected active pair.");
var spread = observable.Culture.Transmit([new CulturalLearner("A", true), new CulturalLearner("B", false)], 1);
Console.WriteLine($"CULTURE: {spread.InitialKnowledgeHolders} to {spread.FinalKnowledgeHolders} learners.");
Console.WriteLine($"OBSERVER: {observable.CreateObserver().Reflect()}");
Console.WriteLine($"HOLOGRAPHY: {new PhysicalDescriptionStudy().Summarize(new CelestialHolography())}");
Console.WriteLine();
Console.WriteLine("HOW WE KNOW (selected investigations)");
foreach (var study in observable.Knowledge.Investigations)
{
    Console.WriteLine($"> {study.FindingSubject}");
    foreach (var observation in study.Observations)
        Console.WriteLine($"  OBSERVED: {observation}");
    Console.WriteLine($"  INFERRED: {study.Inference}");
    foreach (var assumption in study.Assumptions)
        Console.WriteLine($"  ASSUMPTION: {assumption}");
    foreach (var alternative in study.Alternatives)
        Console.WriteLine($"  ALTERNATIVE: {alternative}");
    foreach (var test in study.PotentialTests)
        Console.WriteLine($"  FURTHER TEST: {test}");
    Console.WriteLine($"  SOURCE STATUS: {study.SourceStatus}");
    if (study.SourceStatus == Reality.Core.Epistemology.SourceProvenanceStatus.NotAttached)
        Console.WriteLine("  SOURCE NOTE: Primary study references and datasets have not been attached.");
    if (!string.IsNullOrWhiteSpace(study.SourceNotes))
        Console.WriteLine($"  SOURCE NOTE: {study.SourceNotes}");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("REASONING GRAPH: WHY CLAIMS ABOUT CONSCIOUSNESS ARE LIMITED");
var reasoning = investigation.Reasoning;
var conclusion = reasoning.GetNode(ConsciousnessReasoningExample.MainInferenceId);
Console.WriteLine($"INFERENCE: {conclusion.Description}");
foreach (var link in reasoning.TraceReasons(conclusion.Id))
{
    var premise = reasoning.GetNode(link.FromId);
    Console.WriteLine($"  {link.Relation} [{premise.Kind}]: {premise.Description}");
    Console.WriteLine($"    WHY: {link.Justification}");
    if (premise.SourceUrl is not null)
        Console.WriteLine($"    SOURCE: {premise.SourceUrl}");
}
foreach (var question in reasoning.Connections.Where(link => link.FromId == conclusion.Id && link.Relation == ReasoningRelation.RaisesQuestion))
    Console.WriteLine($"  UNRESOLVED: {reasoning.GetNode(question.ToId).Description}");

Console.WriteLine();
Console.WriteLine("EXPERIMENT DESIGN: CONDITIONAL PREDICTIONS (NO NEW RESULTS CLAIMED)");
var experiment = investigation.Experiment;
Console.WriteLine($"> {experiment.Plan.Question}");
Console.WriteLine($"  STATUS: {experiment.Plan.Status} | Evaluated observations: {experiment.Evaluations.Count}");
Console.WriteLine($"  PROCEDURE: {experiment.Plan.Procedure}");
Console.WriteLine($"  CONTROLS: {experiment.Plan.ControlledFactors}");
Console.WriteLine($"  MEASURE: {experiment.Plan.Measurement}");
foreach (var prediction in experiment.Plan.Predictions)
{
    Console.WriteLine($"  MODEL VARIANT: {prediction.ModelVariant}");
    Console.WriteLine($"    IF: {prediction.Conditions}");
    Console.WriteLine($"    EXPECTED: {prediction.ExpectedObservation}");
    Console.WriteLine($"    POTENTIAL CHALLENGE: {prediction.PotentialCounterObservation}");
    var assessment = experiment.Evaluations.FirstOrDefault(x => x.PredictionId == prediction.Id);
    Console.WriteLine($"    ASSESSMENT: {assessment?.Assessment ?? PredictionAssessment.NotEvaluated}");
}
Console.WriteLine($"  LIMITS: {experiment.Plan.InterpretationLimits}");
Console.WriteLine($"  REFERENCE (inspiration, not a new result): {experiment.Plan.SourceUrl}");

Console.WriteLine("TODO: Discover the actual implementation. Source code unavailable.");

// A double-clicked console window should remain readable, but automation and
// redirected output must never block waiting for user input.
if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
{
    Console.WriteLine();
    Console.Write("Press Enter to exit...");
    Console.ReadLine();
}
