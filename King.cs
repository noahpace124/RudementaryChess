class King : Piece
{
    public King(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'K' : 'k';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        // Must move at least one square and no more than one in any direction
        if ((rowDiff <= 1 && colDiff <= 1) && (rowDiff + colDiff != 0))
        {
            // Can move into empty square or capture enemy
            if (board[endRow, endCol] == null || board[endRow, endCol].IsWhite != IsWhite)
                return true;
        }

        return false;
    }
}

// Note: This implementation does not include castling or check/checkmate logic.