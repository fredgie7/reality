namespace Reality.Physics;

public interface ISpacetime
{
    double LightTravelSeconds(double distanceMeters);
    double ProperTimeForMovingClock(double coordinateSeconds, double speedMetersPerSecond);
    double SchwarzschildRadiusMeters(double massKilograms);
}

/// <summary>
/// Flat-spacetime special relativity for constant relative speed, plus the
/// Schwarzschild radius for an ideal nonrotating uncharged mass.
/// No cosmological or general-relativistic spacetime solver is implied.
/// </summary>
public sealed class Spacetime : ISpacetime
{
    public double LightTravelSeconds(double distanceMeters)
    {
        if (!double.IsFinite(distanceMeters) || distanceMeters < 0) throw new ArgumentOutOfRangeException(nameof(distanceMeters));
        return distanceMeters / KnownPhysics.SpeedOfLight;
    }

    public double ProperTimeForMovingClock(double coordinateSeconds, double speedMetersPerSecond)
    {
        if (!double.IsFinite(coordinateSeconds) || coordinateSeconds < 0) throw new ArgumentOutOfRangeException(nameof(coordinateSeconds));
        if (!double.IsFinite(speedMetersPerSecond) || speedMetersPerSecond < 0 || speedMetersPerSecond >= KnownPhysics.SpeedOfLight)
            throw new ArgumentOutOfRangeException(nameof(speedMetersPerSecond));
        var fraction = speedMetersPerSecond / KnownPhysics.SpeedOfLight;
        return coordinateSeconds * Math.Sqrt(1 - fraction * fraction);
    }

    public double SchwarzschildRadiusMeters(double massKilograms)
    {
        if (!double.IsFinite(massKilograms) || massKilograms < 0) throw new ArgumentOutOfRangeException(nameof(massKilograms));
        return 2 * KnownPhysics.GravitationalConstant * massKilograms / (KnownPhysics.SpeedOfLight * KnownPhysics.SpeedOfLight);
    }

    // TODO: Curved metric tensors, gravitational time dilation, cosmic expansion,
    // and whether spacetime is fundamental or emergent.
}
