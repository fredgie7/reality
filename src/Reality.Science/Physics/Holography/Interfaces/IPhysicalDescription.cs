namespace Reality.Science.Physics.Holography.Interfaces;

// A mathematical description of observable physics, not an ontology.
public interface IPhysicalDescription
{
    string Name { get; }
    string Domain { get; }
    IReadOnlyList<string> Observables { get; }
    string ResearchStatus { get; }
}
