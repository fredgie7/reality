namespace Reality.Science.Biology;

public sealed class Organism(double trait)
{
    public double Trait { get; } = Math.Clamp(trait, 0, 1);
}
