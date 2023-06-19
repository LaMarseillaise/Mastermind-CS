public class Knuth : Player
{
    public string Name { get; }
    private Dictionary<Code, int> maxRemainingAfter = new Dictionary<Code, int>();

    public Knuth(string name)
    {
        this.Name = name;
    }

    public Code MakeSecret()
    {
        return Code.Random();
    }

    public Code MakeGuess(Game game)
    {
        HashSet<Code> candidates = Code.AllPossibilities;

        if (game.Turns.Count == 0)
        {
            return MakeInitialGuess();
        }
        else
        {
            foreach (Turn turn in game.Turns)
            {
                candidates = Prune(candidates, turn);
            }
        }

        if (candidates.Count == 1)
        {
            return candidates.First();
        }
        else
        {
            return MakeExploratoryGuess(candidates);
        }
    }

    private HashSet<Code> Prune(HashSet<Code> candidates, Turn turn)
    {
        return new HashSet<Code>(candidates.Where(code =>
            turn.Guess != code &&
            turn.Exact == code.ExactMatchesWith(turn.Guess) &&
            turn.Partial == code.PartialMatchesWith(turn.Guess)
        ));
    }

    private Code MakeInitialGuess()
    {
        Piece first = PieceExtensions.Random();
        Piece second;

        do
        {
            second = PieceExtensions.Random();
        } while (first == second);

        return new Code(new List<Piece> { first, first, second, second });
    }

    private Code MakeExploratoryGuess(HashSet<Code> candidates)
    {
        maxRemainingAfter.Clear();
        HashSet<Code> maxScoring = GetMaxScoringGuesses(candidates);
        return (
            maxScoring.Intersect(candidates).FirstOrDefault() ??
            maxScoring.FirstOrDefault() ??
            Code.Random()
        );
    }

    private HashSet<Code> GetMaxScoringGuesses(HashSet<Code> candidates)
    {
        int minimumMatches = MinMaxRemaining(candidates);
        return Code.AllPossibilities.Where(guess =>
            MaxRemaining(candidates, guess) == minimumMatches
        ).ToHashSet();
    }

    private int MinMaxRemaining(HashSet<Code> candidates)
    {
        return Code.AllPossibilities.Aggregate(candidates.Count, (least, guess) =>
            Math.Min(least, MaxRemaining(candidates, guess))
        );
    }

    private int MaxRemaining(HashSet<Code> candidates, Code guess)
    {
        if (maxRemainingAfter.ContainsKey(guess))
        {
            return maxRemainingAfter[guess];
        }

        int[] counts = new int[21];

        foreach (Code candidate in candidates)
        {
            int i = candidate.ExactMatchesWith(guess) * 5 +
                    candidate.PartialMatchesWith(guess);
            counts[i]++;
        }

        int most = counts.Max();
        maxRemainingAfter[guess] = most;

        return most;
    }
}