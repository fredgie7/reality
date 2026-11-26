using Reality.Epistemology;
using Reality.Observation;
using Reality.Observation.Interfaces;
using Reality.Biology;
using Reality.Culture;
using Reality.Philosophy;
using Reality.Philosophy.Interfaces;
using Reality.Physics;
using Reality.Physics.Holography;

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
    Console.Error.WriteLine("Usage: dotnet run --project src/Reality/Reality.csproj -- [all|Panpsychism|Physicalism|Idealism|\"Substance dualism\"]");
    Environment.ExitCode = 1;
    return;
}
Console.WriteLine("REALITY :: production diagnostics");
Console.WriteLine("Implementation: unknown | Observable models: revisable | Observer: inside the system");
Console.WriteLine();
foreach (var stage in observable.DescribeHistory())
    Console.WriteLine($"[{stage.Domain}] {stage.Description}");

Console.WriteLine();
Console.WriteLine("SCIENTIFIC FINDINGS");
foreach (var finding in observable.Knowledge.Findings)
    Console.WriteLine($"[{finding.Confidence}] {finding.Subject}: {finding.Description}");

Console.WriteLine();
Console.WriteLine("PHILOSOPHICAL THEORIES (not alternate scientific universes)");
foreach (var assessment in new TheoryComparisonService().Compare(selected, observable.Knowledge))
{
    var theory = selected.First(x => x.Name == assessment.TheoryName);
    Console.WriteLine($"> {theory.Name}: {theory.CoreClaim}");
    Console.WriteLine($"  Assumptions: {assessment.StatedAssumptions} | Catalog-linked interpretations: {assessment.CatalogLinkedExplanations.Count} | Proposed predictions: {assessment.ProposedPredictions.Count}");
    foreach (var explanation in assessment.CatalogLinkedExplanations)
        Console.WriteLine($"  INTERPRETATION [{explanation.FindingSubject}]: {explanation.Account}");
    foreach (var question in assessment.OpenQuestions)
        Console.WriteLine($"  OPEN: {question.Description}");
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
}

Console.WriteLine();
Console.WriteLine("TODO: Discover the actual implementation. Source code unavailable.");

// A double-clicked console window should remain readable, but automation and
// redirected output must never block waiting for user input.
if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
{
    Console.WriteLine();
    Console.Write("Press Enter to exit...");
    Console.ReadLine();
}
