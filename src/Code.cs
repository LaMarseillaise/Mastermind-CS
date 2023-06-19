public class Code
{
    static public HashSet<Code> AllPossibilities = Code.Permutations();
    public static int Length = 4;
    public List<Piece> Sequence { get; private set; }

    public Code(List<Piece> sequence)
    {
        this.Sequence = sequence;
    }

    public int ExactMatchesWith(Code code)
    {
        int count = 0;

        for (int i = 0; i < Length; i++)
        {
            if (this.Sequence[i] == code.Sequence[i]) {
                count++;
            }
        }

        return count;
    }

    public int PartialMatchesWith(Code code)
    {
        return this.ColorMatchesWith(code) - this.ExactMatchesWith(code);
    }

    private int CountBy(Piece color)
    {
        int count = 0;

        for (int i = 0; i < Length; i++)
        {
            if (this.Sequence[i] == color) {
                count++;
            }
        }

        return count;
    }

    private int ColorMatchesWith(Code code)
    {
        int count = 0;

        foreach (Piece color in PieceExtensions.Colors())
        {
            count += Math.Min(this.CountBy(color), code.CountBy(color));
        }

        return count;
    }

    static public Code Random()
    {
        List<Piece> sequence = new List<Piece>();

        for (int i = 0; i < Length; i++)
        {
            sequence.Add(PieceExtensions.Random());
        }

        return new Code(sequence);
    }

    private static HashSet<Code> Permutations()
    {
        HashSet<Code> permutations = new HashSet<Code>();

        foreach (Piece first in PieceExtensions.Colors())
        {
            foreach (Piece second in PieceExtensions.Colors())
            {
                foreach (Piece third in PieceExtensions.Colors())
                {
                    foreach (Piece fourth in PieceExtensions.Colors())
                    {
                        permutations.Add(new Code(new List<Piece> { first, second, third, fourth }));
                    }
                }
            }
        }

        return permutations;
    }
}
