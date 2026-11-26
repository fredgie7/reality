using Reality.Science.Physics;

namespace Reality.Science.Physics.Interfaces;

public interface ILawsOfPhysics
{
    IReadOnlyList<PhysicalPrinciple> Principles { get; }
}
