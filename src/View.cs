public struct View {
    public const int paddingLeft = 4;
    public const string TOP_LEFT_CORNER = "┏";
    public const string TOP_MIDDLE_INTER = "┳";
    public const string TOP_RIGHT_CORNER = "┓";
    public const string BOTTOM_LEFT_CORNER = "┗";
    public const string BOTTOM_MIDDLE_INTER = "┻";
    public const string BOTTOM_RIGHT_CORNER = "┛";
    public const string HORIZONTAL = "➖";
    public const string SIDE = "┃";

    // piece colors
    public const string BLACK = "⚫️";
    public const string BLUE = "🔵";
    public const string GREEN = "🟢";
    public const string RED = "🔴";
    public const string WHITE = "⚪️";
    public const string YELLOW = "🟡";

    // grading
    public const string EXACT = "🔴";
    public const string PARTIAL = "⚪️";
    public const string NON_MATCH = "▪️";

    public static string Introduction() {
        return "MASTERMIND";
    }

    public static string GradingScheme() {
        return $"{EXACT}: matched color and position {PARTIAL}: matched color";
    }

    public static string ColorCodes() {
        int current = 0;
        return string.Join("  ", PieceExtensions.Colors().Select(piece =>
        {
            current++;
            return $"{current}: {PieceIcon(piece)}";
        })) + "  q: exit";
    }

    public static string PieceIcon(Piece piece) {
        switch (piece) {
            case Piece.Black: return BLACK;
            case Piece.Blue: return BLUE;
            case Piece.Green: return GREEN;
            case Piece.Red: return RED;
            case Piece.White: return WHITE;
            case Piece.Yellow: return YELLOW;
            default: return "";
        }
    }

    public static string TopBorder() {
        return (
            new string(' ', paddingLeft) +
            TOP_LEFT_CORNER +
            new string(HORIZONTAL[0], Code.Length) +
            TOP_MIDDLE_INTER +
            new string(HORIZONTAL[0], Code.Length) +
            TOP_RIGHT_CORNER
        );
    }

    public static string BottomBorder() {
        return (
            new string(' ', paddingLeft) +
            BOTTOM_LEFT_CORNER +
            new string(HORIZONTAL[0], Code.Length) +
            BOTTOM_MIDDLE_INTER +
            new string(HORIZONTAL[0], Code.Length) +
            BOTTOM_RIGHT_CORNER
        );
    }

    public static string AttemptLine(Turn turn) {
        return (
            $"{turn.Number}:".PadRight(paddingLeft, ' ') +
            SIDE +
            GuessBar(turn.Guess.Sequence) +
            SIDE +
            FeedbackLine(turn.Exact, turn.Partial) +
            SIDE
        );
    }

    public static string FeedbackLine(int exact, int partial) {
        int nonMatches = (Code.Length - exact - partial);
        return (
            new string(EXACT[0], exact) +
            new string(PARTIAL[0], partial) +
            new string(NON_MATCH[0], nonMatches)
        );
    }
    
    public static string GuessBar(List<Piece> sequence) {
        return string.Join("", sequence.Select(PieceIcon));
    }
}