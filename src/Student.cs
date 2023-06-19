public class Student : Player
{
    public string Name { get; }

    public Student(string name)
    {
        this.Name = name;
    }

    public Code MakeSecret()
    {
        Console.Write($"{this.Name}: What will the secret code be? ");
        return Parse(Console.ReadLine());
    }

    public Code MakeGuess(Game game)
    {
        return Parse(Console.ReadLine());
    }

    private Code Parse(string? digits)
    {
        if (digits == null)
        {
            throw new ArgumentNullException(nameof(digits));
        }

        List<Piece> sequence = new List<Piece>();
        int i = 0;

        foreach (char digit in digits)
        {
            Piece? selection = Parse(digit);
            if (selection != null)
            {
                sequence.Add(selection.Value);
                i++;
                if (i >= Code.Length) { break; }
            }
        }

        for (int j = i; j < Code.Length; j++)
        {
            sequence.Add(PieceExtensions.Random());
        }

        return new Code(sequence);
    }

    private Piece? Parse(char digit)
    {
        switch (digit)
        {
            case '1': return Piece.Black;
            case '2': return Piece.Blue;
            case '3': return Piece.Green;
            case '4': return Piece.Red;
            case '5': return Piece.White;
            case '6': return Piece.Yellow;
            case 'q': Environment.Exit(0); return null;
            default: return null;
        }
    }
}
