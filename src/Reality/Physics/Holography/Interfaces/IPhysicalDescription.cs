namespace Reality.Physics.Holography;

// A mathematical description of observable physics, not an ontology.
public interface IPhysicalDescription
{
    string Name { get; }
    string Domain { get; }
    IReadOnlyList<string> Observables { get; }
    string ResearchStatus { get; }
}
