public struct Turn
{
    public int Number { get; }
    public Code Guess { get; }
    public int Exact { get; }
    public int Partial { get; }

    public Turn(int number, Code guess, int exact, int partial)
    {
        Number = number;
        Guess = guess;
        Exact = exact;
        Partial = partial;
    }
}
