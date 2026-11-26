namespace Reality.Physics;

public sealed class ChemistryModel
{
    public IReadOnlyList<Event> Events { get; } = new[]
    {
        new Event("Chemistry", "Electromagnetic interactions produce bonds and complex molecules."),
        new Event("Chemistry", "Environmental conditions permit some complex prebiotic chemistry.")
    };
}
