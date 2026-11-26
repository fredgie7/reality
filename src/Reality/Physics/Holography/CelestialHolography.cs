using Reality.Physics.Holography.Interfaces;
namespace Reality.Physics.Holography;

/// <summary>
/// A conceptual model of celestial holography, motivated by celestial
/// conformal bases for flat-space scattering (Pasterski, Shao, Strominger 2017).
/// The numerical demonstration is ONLY a one-dimensional real Mellin quadrature,
/// not a multi-leg celestial amplitude or a complete holographic dictionary.
/// </summary>
public sealed class CelestialHolography : IHolographicDuality
{
    public IPhysicalDescription Bulk { get; } = new FourDimensionalScatteringDescription();
    public IPhysicalDescription Boundary { get; } = new CelestialConformalDescription();
    // Some celestial-basis scattering results are established, but a complete
    // flat-space gravitational dual remains an open research question.
    public HolographicCorrespondenceStatus CorrespondenceStatus => HolographicCorrespondenceStatus.PartialResults;

    public string Name => "Celestial holography";

    public IReadOnlyList<string> OpenQuestions { get; } = [
        "Can a complete holographic dictionary for asymptotically flat quantum gravity be constructed?",
        "Under what assumptions, if any, can the 4D bulk be fully reconstructed from celestial data?",
        "How are infrared, distributional and nonperturbative questions resolved?"
    ];

    public string ExplainRelationship() =>
        "Scattering data in a 4D momentum basis may be recast in a celestial conformal basis. " +
        "A complete 2D dual of flat-space quantum gravity has not been established.";

    // Specialized toy calculation: deliberately not required by IHolographicDuality.
    public CelestialTransformResult DemonstrateEnergyMellinTransform(IReadOnlyList<EnergyAmplitudeSample> samples, double conformalDimension)
    {
        ArgumentNullException.ThrowIfNull(samples);
        if (samples.Count < 2) throw new ArgumentException("At least two samples required.", nameof(samples));
        if (!double.IsFinite(conformalDimension)) throw new ArgumentOutOfRangeException(nameof(conformalDimension));

        // Trapezoidal approximation to integral A(omega) * omega^(Delta-1) d(omega).
        // Real Delta, finite positive energies, and real amplitudes are toy restrictions.
        double integral = 0;
        for (var i = 0; i < samples.Count; i++)
        {
            var point = samples[i];
            if (!double.IsFinite(point.Energy) || point.Energy <= 0 || !double.IsFinite(point.Amplitude))
                throw new ArgumentException("Energies must be positive and finite; amplitudes finite.", nameof(samples));
            if (i == 0) continue;

            var previous = samples[i - 1];
            if (point.Energy <= previous.Energy)
                throw new ArgumentException("Energies must increase strictly.", nameof(samples));
            var left = previous.Amplitude * Math.Pow(previous.Energy, conformalDimension - 1);
            var right = point.Amplitude * Math.Pow(point.Energy, conformalDimension - 1);
            if (!double.IsFinite(left) || !double.IsFinite(right))
                throw new ArgumentOutOfRangeException(nameof(conformalDimension), "Integrand overflow.");
            integral += (left + right) * (point.Energy - previous.Energy) / 2;
            if (!double.IsFinite(integral))
                throw new ArgumentOutOfRangeException(nameof(samples), "Integral overflow.");
        }

        return new CelestialTransformResult(conformalDimension, integral, samples[0].Energy, samples[^1].Energy);
    }

    // Specialized operation: deliberately not required by IHolographicDuality.
    public void ReconstructFullBulk()
    {
        // TODO: Establish a complete celestial dictionary and bulk reconstruction.
        // A mathematical change of basis does not prove a full quantum-gravity dual.
        throw new NotSupportedException("Complete celestial bulk reconstruction remains an open research problem.");
    }
}
