class Rook : Piece
{
    public Rook(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'R' : 'r';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        // Must move in a straight line (either row or column must be the same)
        if (startRow != endRow && startCol != endCol)
            return false;

        int rowStep = Math.Sign(endRow - startRow); // +1, 0, or -1
        int colStep = Math.Sign(endCol - startCol); // +1, 0, or -1

        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        // Check each square along the path for obstructions (not including destination)
        while (currentRow != endRow || currentCol != endCol)
        {
            if (board[currentRow, currentCol] != null)
                return false;

            currentRow += rowStep;
            currentCol += colStep;
        }

        // Final square must be empty or have enemy
        return board[endRow, endCol] == null || board[endRow, endCol].IsWhite != IsWhite;
    }
}
// Castling not implemented in this example