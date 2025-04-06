public class Board
{
    public Piece[,]? Grid { get; private set; }

    public Board()
    {
        Grid = new Piece[8, 8];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        // Initialize black pieces (row 0 and 1)
        Grid[0, 0] = new Rook(false);  // Black Rook
        Grid[0, 1] = new Knight(false); // Black Knight
        Grid[0, 2] = new Bishop(false); // Black Bishop
        Grid[0, 3] = new Queen(false);  // Black Queen
        Grid[0, 4] = new King(false);   // Black King
        Grid[0, 5] = new Bishop(false); // Black Bishop
        Grid[0, 6] = new Knight(false); // Black Knight
        Grid[0, 7] = new Rook(false);   // Black Rook

        for (int i = 0; i < 8; i++) // Black pawns on row 1
        {
            Grid[1, i] = new Pawn(false);  // Black Pawns
        }

        // Initialize white pieces (row 6 and 7)
        Grid[7, 0] = new Rook(true);  // White Rook
        Grid[7, 1] = new Knight(true); // White Knight
        Grid[7, 2] = new Bishop(true); // White Bishop
        Grid[7, 3] = new Queen(true);  // White Queen
        Grid[7, 4] = new King(true);   // White King
        Grid[7, 5] = new Bishop(true); // White Bishop
        Grid[7, 6] = new Knight(true); // White Knight
        Grid[7, 7] = new Rook(true);   // White Rook

        for (int i = 0; i < 8; i++) // White pawns on row 6
        {
            Grid[6, i] = new Pawn(true);  // White Pawns
        }
    }

    public void PrintBoard()
    {
        Console.WriteLine("  A B C D E F G H");
        for (int row = 0; row < 8; row++)
        {
            Console.Write($"{8 - row} ");
            for (int col = 0; col < 8; col++)
            {
                if (Grid[row, col] == null)
                    Console.Write(". ");
                else
                    Console.Write(Grid[row, col].Symbol + " ");
            }
            Console.WriteLine();
        }
    }

    public bool MovePiece(int startRow, int startCol, int endRow, int endCol)
    {
        Piece piece = Grid[startRow, startCol];
        if (piece == null)
            return false;

        // Check if the move is valid for the piece
        if (piece.IsValidMove(startRow, startCol, endRow, endCol, Grid))
        {
            // Move the piece to the new location
            Grid[endRow, endCol] = piece;
            Grid[startRow, startCol] = null;

            // Check if the moved piece is a pawn and if it reached the promotion row
            if (piece is Pawn && ((piece.IsWhite && endRow == 0) || (!piece.IsWhite && endRow == 7)))
            {
                // Promote the pawn to a Queen
                Grid[endRow, endCol] = new Queen(piece.IsWhite); 
            }

            return true;
        }

        return false;
    }

}
