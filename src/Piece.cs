public enum Piece
{
    Black,
    Blue,
    Green,
    Red,
    White,
    Yellow
}

static class PieceExtensions
{
    public static IEnumerable<Piece> Colors()
    {
        return Enum.GetValues(typeof(Piece)).Cast<Piece>();
    }

    public static Piece Random()
    {
        return Colors().OrderBy(x => Guid.NewGuid()).First();
    }
}
