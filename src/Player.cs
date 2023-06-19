public interface Player
{
    string Name { get; }
    Code MakeSecret();
    Code MakeGuess(Game game);
}