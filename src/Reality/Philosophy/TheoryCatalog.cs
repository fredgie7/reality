using Reality.Philosophy.Interfaces;
using Reality.Philosophy.Theories;

namespace Reality.Philosophy;

/// <summary>
/// Registry of interpretations. No candidate is a substitute for observable science.
/// </summary>
public static class TheoryCatalog
{
    public static IReadOnlyList<ITheoryOfReality> All { get; } = new ITheoryOfReality[]
    {
        new PanpsychistTheory(),
        new PhysicalistTheory(),
        new IdealistTheory(),
        new SubstanceDualistTheory()
    };

    public static ITheoryOfReality Find(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return All.FirstOrDefault(x => x.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase))
            ?? throw new ArgumentException($"Unknown theory '{name}'. Choose: {string.Join(", ", All.Select(x => x.Name))}.", nameof(name));
    }
}
