class Bishop : Piece
{
    public Bishop(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'B' : 'b';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        // Must move diagonally: row and column change must be equal
        if (rowDiff != colDiff)
            return false;

        int rowStep = (endRow > startRow) ? 1 : -1;
        int colStep = (endCol > startCol) ? 1 : -1;

        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        // Check for obstacles along the path
        while (currentRow != endRow && currentCol != endCol)
        {
            if (board[currentRow, currentCol] != null)
                return false;

            currentRow += rowStep;
            currentCol += colStep;
        }

        // Final square: must be empty or contain an enemy piece
        return board[endRow, endCol] == null || board[endRow, endCol].IsWhite != IsWhite;
    }
}
