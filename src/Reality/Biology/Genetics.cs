namespace Reality.Biology;

/// <summary>
/// Illustrative information flow: DNA replication, transcription, translation,
/// inheritance, and mutation. These strings are not a cellular simulation.
/// </summary>
public interface IGenetics
{
    string Replicate(string dna);
    string Transcribe(string dna);
    string Translate(string rna);
    string Inherit(string maternalDna, string paternalDna, int crossoverIndex);
    string Mutate(string dna, int position, char replacement);
}

public sealed class Genetics : IGenetics
{
    private const string Bases = "ACGT";

    public string Replicate(string dna)
    {
        ValidateDna(dna);
        // A daughter DNA molecule preserves sequence information; real replication
        // includes complementary strands and error-correction machinery.
        return new string(dna.ToCharArray());
    }

    public string Transcribe(string dna)
    {
        ValidateDna(dna);
        // Input denotes a coding strand, not the template strand.
        return dna.Replace('T', 'U');
    }

    public string Translate(string rna)
    {
        ArgumentNullException.ThrowIfNull(rna);
        if (rna.Any(c => !"ACGU".Contains(c))) throw new ArgumentException("RNA may only contain A, C, G, U.", nameof(rna));
        // Educational tiny codon table; real translation requires a full genetic code,
        // reading frame, start/stop logic, ribosomes, and cellular context.
        var codons = new Dictionary<string, char> { ["AUG"] = 'M', ["UUU"] = 'F', ["UUC"] = 'F', ["GGU"] = 'G', ["GGC"] = 'G', ["GGA"] = 'G', ["GGG"] = 'G', ["UAA"] = '*', ["UAG"] = '*', ["UGA"] = '*' };
        var aminoAcids = new List<char>();
        for (var i = 0; i + 2 < rna.Length; i += 3)
        {
            if (!codons.TryGetValue(rna.Substring(i, 3), out var aminoAcid))
                throw new NotSupportedException($"Codon {rna.Substring(i, 3)} is outside the illustrative table.");
            if (aminoAcid == '*') break;
            aminoAcids.Add(aminoAcid);
        }
        return new string(aminoAcids.ToArray());
    }

    public string Inherit(string maternalDna, string paternalDna, int crossoverIndex)
    {
        ValidateDna(maternalDna);
        ValidateDna(paternalDna);
        if (maternalDna.Length != paternalDna.Length || crossoverIndex < 0 || crossoverIndex > maternalDna.Length)
            throw new ArgumentOutOfRangeException(nameof(crossoverIndex), "Sequences must have equal length and the crossover must lie within them.");
        // Simplified recombination; actual inheritance involves homologous chromosomes.
        return maternalDna[..crossoverIndex] + paternalDna[crossoverIndex..];
    }

    public string Mutate(string dna, int position, char replacement)
    {
        ValidateDna(dna);
        if (position < 0 || position >= dna.Length) throw new ArgumentOutOfRangeException(nameof(position));
        if (!Bases.Contains(replacement)) throw new ArgumentException("Replacement must be A, C, G or T.", nameof(replacement));
        var result = dna.ToCharArray();
        result[position] = replacement;
        return new string(result);
    }

    private static void ValidateDna(string dna)
    {
        ArgumentNullException.ThrowIfNull(dna);
        if (dna.Any(c => !Bases.Contains(c))) throw new ArgumentException("DNA may only contain A, C, G, T.", nameof(dna));
    }

    // TODO: Epigenetic regulation, developmental biology, cellular context,
    // polygenic traits and environmental influences.
}
