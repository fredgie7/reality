namespace Reality.Investigation.Navigation;

/// <summary>One navigation response and whether the interactive session should end.</summary>
public sealed record NavigationResult(string Output, bool ShouldExit = false);
