using Reality.Core.Observation;

namespace Reality.Science.Physics;

public sealed class CosmicHistory
{
    public IReadOnlyList<Event> Events { get; } = [
        new Event("Cosmology", "Early hot, dense universe and primordial nuclear reactions."),
        new Event("Cosmology", "Expansion and cooling allow neutral atoms to form."),
        new Event("Cosmology", "Gravity assembles galaxies and stars."),
        new Event("Cosmology", "Stars and stellar deaths enrich matter with heavier elements."),
        new Event("Cosmology", "Planetary systems form around some stars.")
    ];
}
