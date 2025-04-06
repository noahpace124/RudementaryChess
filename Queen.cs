class Queen : Piece
{
    public Queen(bool isWhite) : base(isWhite)
    {
        Symbol = isWhite ? 'Q' : 'q';
    }

    public override bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int rowDiff = Math.Abs(endRow - startRow);
        int colDiff = Math.Abs(endCol - startCol);

        // Queen moves like a rook (horizontal or vertical)
        if (rowDiff == 0 || colDiff == 0)
        {
            return IsPathClear(startRow, startCol, endRow, endCol, board);
        }
        
        // Queen moves like a bishop (diagonal)
        if (rowDiff == colDiff)
        {
            return IsPathClear(startRow, startCol, endRow, endCol, board);
        }

        return false;
    }

    private bool IsPathClear(int startRow, int startCol, int endRow, int endCol, Piece[,] board)
    {
        int rowStep = 0, colStep = 0;

        // Horizontal movement
        if (startRow == endRow)
        {
            colStep = (endCol > startCol) ? 1 : -1;
        }
        // Vertical movement
        else if (startCol == endCol)
        {
            rowStep = (endRow > startRow) ? 1 : -1;
        }
        // Diagonal movement
        else if (Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
        {
            rowStep = (endRow > startRow) ? 1 : -1;
            colStep = (endCol > startCol) ? 1 : -1;
        }

        int currentRow = startRow + rowStep;
        int currentCol = startCol + colStep;

        while (currentRow != endRow && currentCol != endCol)
        {
            if (board[currentRow, currentCol] != null)
                return false;  // There's an obstacle in the path

            currentRow += rowStep;
            currentCol += colStep;
        }

        // Final square: must be empty or contain an enemy piece
        return board[endRow, endCol] == null || board[endRow, endCol].IsWhite != IsWhite;
    }
}
