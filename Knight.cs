class Knight : Piece
{
    public Knight(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'N' : 'n';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        // Knight moves in an L-shape (2 squares in one direction, 1 in the other)
        if ((rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2))
        {
            // Final square: must be empty or contain an enemy piece
            return board[endRow, endCol] == null || board[endRow, endCol].IsWhite != IsWhite;
        }

        return false;
    }
}
