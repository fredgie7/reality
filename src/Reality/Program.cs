using Reality;
using Reality.Biology;
using Reality.Implementations;
using Reality.Philosophy;
using Reality.Physics;

var knowledge = ScientificCatalog.Create();

// Swap this instance for another IReality implementation as we explore alternatives.
// Common physical, evolutionary and observer models are not tied to panpsychism.
IReality world = new PanpsychistReality(new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(seed: 42), knowledge);

Console.WriteLine("REALITY :: production diagnostics");
Console.WriteLine("Source code: unavailable | Observer: running inside observed system");
Console.WriteLine($"Selected interpretation: {world.Name} (philosophical hypothesis)");
foreach (var assumption in world.MetaphysicalAssumptions)
    Console.WriteLine($"ASSUMPTION: {assumption}");

Console.WriteLine();
foreach (var stage in world.Evolve())
    Console.WriteLine($"[{stage.Domain}] {stage.Description}");

Console.WriteLine();
var observer = world.CreateObserver();
foreach (var finding in observer.DoScience().Take(8))
    Console.WriteLine($"SCIENCE [{finding.Confidence}]: {finding.Subject} — {finding.Description}");

Console.WriteLine();
foreach (var question in observer.DoPhilosophy())
    Console.WriteLine($"PHILOSOPHY: {question}");

Console.WriteLine();
var comparison = new TheoryComparison();
foreach (var theory in comparison.Theories)
    Console.WriteLine($"THEORY: {theory.Name} — {theory.CoreClaim} [{theory.EvidenceStatus}]");

Console.WriteLine();
var population = Population.Create(size: 60, seed: 42);
for (var generation = 0; generation < 8; generation++)
{
    var report = world.Evolution.Advance(population, environmentOptimum: 0.7);
    Console.WriteLine($"EVOLUTION: generation {report.Generation}, population {report.PopulationSize}, mean trait {report.MeanTrait:F3}");
}

Console.WriteLine();
Console.WriteLine($"FIRST PERSON: {observer.Experience()}");
Console.WriteLine("The nature of reality is still under investigation.");
