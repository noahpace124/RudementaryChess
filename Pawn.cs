class Pawn : Piece
{
    public Pawn(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'P' : 'p';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int direction = IsWhite ? -1 : 1; // White moves up (row decreases), black moves down (row increases)
        int startRowForPawn = IsWhite ? 6 : 1; // White starts at row 6, black starts at row 1

        // Forward one square
        if (startCol == endCol && board[endRow, endCol] == null)
        {
            if (endRow == startRow + direction)
                return true;

            // Forward two squares from the starting row
            if (startRow == startRowForPawn && endRow == startRow + 2 * direction && board[startRow + direction, startCol] == null)
                return true;
        }

        // Diagonal capture
        if (Math.Abs(endCol - startCol) == 1 && endRow == startRow + direction)
        {
            if (board[endRow, endCol] != null && board[endRow, endCol].IsWhite != IsWhite)
                return true;
        }

        return false;
    }
}
