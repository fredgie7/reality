using Reality.Core.Observation;

namespace Reality.Science.Physics;

public sealed class ChemistryModel
{
    public IReadOnlyList<Event> Events { get; } = [
        new Event(EventDomain.Chemistry, "Electromagnetic interactions produce bonds and complex molecules."),
        new Event(EventDomain.Chemistry, "Environmental conditions permit some complex prebiotic chemistry.")
    ];
}
