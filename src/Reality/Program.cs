using Reality;
using Reality.Biology;
using Reality.Culture;
using Reality.Implementations;
using Reality.Philosophy;
using Reality.Physics;
using Reality.Physics.Holography;

var model = args.Length == 0 ? "panpsychism" : args[0];
var knowledge = ScientificCatalog.Create();

IReality world;
try
{
    world = RealityFactory.Create(model, new KnownPhysics(), new CosmicHistory(), new ChemistryModel(), new DarwinianEvolution(seed: 42), knowledge);
}
catch (ArgumentException exception)
{
    Console.Error.WriteLine(exception.Message);
    Console.Error.WriteLine($"Usage: dotnet run --project src/Reality/Reality.csproj -- [{string.Join("|", RealityFactory.AvailableModels)}]");
    Environment.ExitCode = 1;
    return;
}

Console.WriteLine("REALITY :: production diagnostics");
Console.WriteLine("Source code: unavailable | Observer: running inside observed system");
Console.WriteLine($"Selected interpretation: {world.Name} (philosophical hypothesis)");
foreach (var assumption in world.MetaphysicalAssumptions)
    Console.WriteLine($"ASSUMPTION: {assumption}");

Console.WriteLine();
foreach (var stage in world.Evolve())
    Console.WriteLine($"[{stage.Domain}] {stage.Description}");

Console.WriteLine();
Console.WriteLine($"GENETICS: DNA coding strand ATGGGT -> RNA {world.Genetics.Transcribe("ATGGGT")} -> illustrative peptide {world.Genetics.Translate("AUGGGU")}");
Console.WriteLine($"SPACETIME: light takes {world.Spacetime.LightTravelSeconds(KnownPhysics.SpeedOfLight):F1} second to travel one light-second.");
var pattern = world.Emergence.Analyze(new[] { true, true, false, true });
Console.WriteLine($"EMERGENCE: {pattern.ActiveComponents} active nodes, {pattern.AdjacentActivePairs} connected active pair(s).");
var transmission = world.Culture.Transmit(new[] { new CulturalLearner("A", true), new CulturalLearner("B", false), new CulturalLearner("C", false) }, 2);
Console.WriteLine($"CULTURE: knowledge spreads from {transmission.InitialKnowledgeHolders} to {transmission.FinalKnowledgeHolders} learners.");
Console.WriteLine($"NEUROSCIENCE: {world.NervousSystem.Learn("a new observation")}");

Console.WriteLine();
var celestial = new CelestialHolography();
IHolographicDuality duality = celestial;
Console.WriteLine($"CELESTIAL: {new PhysicalDescriptionStudy().Summarize(world, duality)}");
Console.WriteLine($"RESEARCH: {duality.ExplainRelationship()}");
var mellinDemo = celestial.DemonstrateEnergyMellinTransform(new[]
{
    new EnergyAmplitudeSample(1, 1),
    new EnergyAmplitudeSample(2, 1),
    new EnergyAmplitudeSample(3, 1)
}, conformalDimension: 1);
Console.WriteLine($"TOY MELLIN INTEGRAL: {mellinDemo.ApproximateValue:F2} (not a full celestial correlator)");

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
