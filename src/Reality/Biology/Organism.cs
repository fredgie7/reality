namespace Reality.Biology;

public sealed class Organism
{
    public Organism(double trait) => Trait = Math.Clamp(trait, 0, 1);
    public double Trait { get; }
}
