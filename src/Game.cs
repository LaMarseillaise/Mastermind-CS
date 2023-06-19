public class Game
{
    static int MaxAttempts = 12;
    private Code secret;
    public List<Turn> Turns { get; private set; }

    public Game(Code? secret = null)
    {
        this.secret = secret ?? Code.Random();
        this.Turns = new List<Turn>();
    }

    public void Guess(Code guess)
    {
        int exact = this.secret.ExactMatchesWith(guess);
        int partial = this.secret.PartialMatchesWith(guess);
        int number = this.Turns.Count + 1;

        this.Turns.Add(new Turn(number, guess, exact, partial));
    }

    public Player? Winner(Player codemaker, Player codebreaker)
    {
        if (this.IsOver())
        {
            return this.IsSolved() ? codebreaker : codemaker;
        }
        else
        {
            return null;
        }
    }

    public bool IsOver()
    {
        return !this.HasAttemptsRemaining() || this.IsSolved();
    }

    private bool HasAttemptsRemaining()
    {
        return this.Turns.Count() < MaxAttempts;
    }

    private bool IsSolved()
    {
        return this.Turns.Any(turn => turn.Exact == Code.Length);
    }
}
