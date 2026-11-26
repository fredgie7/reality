using Reality.Investigation.Navigation;

namespace Reality.Console.Interaction;

/// <summary>
/// Text-only interactive host. Input/output are injectable for scripted use.
/// EOF exits cleanly; no console read is required for noninteractive summaries.
/// </summary>
public static class InteractiveSession
{
    public static void Run(TextReader input, TextWriter output, InvestigationNavigator navigator)
    {
        ArgumentNullException.ThrowIfNull(input);
        ArgumentNullException.ThrowIfNull(output);
        ArgumentNullException.ThrowIfNull(navigator);

        output.WriteLine("REALITY :: interactive investigation");
        output.WriteLine("Models are revisable; the implementation of reality remains unknown.");
        output.WriteLine("Type 'help' to explore findings, theories, evidence, experiments and reports.");
        while (true)
        {
            output.WriteLine();
            output.Write("reality> ");
            output.Flush();
            var line = input.ReadLine();
            if (line is null)
            {
                output.WriteLine("Input ended. Investigation closed.");
                return;
            }
            var result = navigator.Execute(line);
            output.WriteLine(result.Output);
            if (result.ShouldExit)
                return;
        }
    }
}
