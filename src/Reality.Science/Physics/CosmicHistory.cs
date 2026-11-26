using Reality.Core.Observation;

namespace Reality.Science.Physics;

public sealed class CosmicHistory
{
    public IReadOnlyList<Event> Events { get; } = [
        new Event(EventDomain.Cosmology, "Early hot, dense universe and primordial nuclear reactions."),
        new Event(EventDomain.Cosmology, "Expansion and cooling allow neutral atoms to form."),
        new Event(EventDomain.Cosmology, "Gravity assembles galaxies and stars."),
        new Event(EventDomain.Cosmology, "Stars and stellar deaths enrich matter with heavier elements."),
        new Event(EventDomain.Cosmology, "Planetary systems form around some stars.")
    ];
}
