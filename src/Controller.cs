public class Controller
{
    public static void Play()
    {
        (Player codemaker, Player codebreaker) = GetPlayers();
        Code secret = GetSecret(codemaker);
        Game game = new Game(secret);
        Player? winner = null;

        Console.WriteLine($"{codebreaker.Name} must guess the code.");
        Console.WriteLine(View.GradingScheme());
        Console.WriteLine(View.TopBorder());

        while (winner == null)
        {
            Code guess = codebreaker.MakeGuess(game);
            game.Guess(guess);
            Console.WriteLine(View.AttemptLine(game.Turns[^1]));
            winner = game.Winner(codemaker, codebreaker);
        }

        Console.WriteLine(View.BottomBorder());
        Console.WriteLine($"{winner.Name} wins! ({game.Turns.Count} guesses)");
    }

    public static (Player, Player) GetPlayers()
    {
        Console.WriteLine("\n\nWho will be the code maker?");
        Console.WriteLine("1. Player");
        Console.WriteLine("2. Computer");

        string input = Console.ReadLine() ?? "";
        switch (input)
        {
            case "q": Environment.Exit(0); return (null, null);
            case "2": return (new Knuth("Computer"), new Student("Player"));
            default: return (new Student("Player"), new Knuth("Computer"));
        }
    }

    public static Code GetSecret(Player codemaker)
    {
        Console.WriteLine(View.ColorCodes());
        return codemaker.MakeSecret();
    }
}