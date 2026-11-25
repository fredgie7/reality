using Reality.Biology;
using Reality.Physics;

namespace Reality.Implementations;

/// <summary>
/// A substance-dualist interpretation: mind and matter are ontologically
/// distinct types of substance. This example does not assert that causal
/// interaction is established or explain how such interaction works.
/// </summary>
public sealed class SubstanceDualistReality : RealityBase
{
    public SubstanceDualistReality(ILawsOfPhysics physics, CosmicHistory cosmos, ChemistryModel chemistry, IBiologicalEvolution evolution, ScientificCatalog knowledge)
        : base(physics, cosmos, chemistry, evolution, knowledge) { }

    public override string Name => "Substance dualism";

    public override IReadOnlyList<string> MetaphysicalAssumptions { get; } = new[]
    {
        "Mental and physical substances are fundamentally distinct.",
        "Subjective experience is not exhaustively identical with physical matter.",
        "The relationship between mental events and the physical world must be specified; interaction is not assumed to be solved."
    };

    // TODO: Explain how mental and physical substances might causally interact.
    // TODO: Reconcile any proposed mental causation with well-tested physical constraints.
    // TODO: Specify whether the account is interactionist, parallelist, or another variant.
}
