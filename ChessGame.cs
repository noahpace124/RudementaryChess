public class ChessGame
{
    private Board board;
    private bool isWhiteTurn;

    public ChessGame()
    {
        board = new Board();
        isWhiteTurn = true;
    }

    public void StartGame()
    {
        while (true)
        {
            Console.Clear();
            board.PrintBoard();

            // Check if either king has been taken
            if (!HasKing(white: true)) // White's King has been taken
            {
                Console.WriteLine("Black wins! White's King has been captured.");
                break;
            }
            if (!HasKing(white: false)) // Black's King has been taken
            {
                Console.WriteLine("White wins! Black's King has been captured.");
                break;
            }

            Console.WriteLine($"It's {(isWhiteTurn ? "White's" : "Black's")} turn.");
            Console.Write("Enter your move (e.g., 'e2 e4'): ");
            string move = Console.ReadLine();
            string[] moveParts = move.Split(' ');

            if (moveParts.Length != 2)
            {
                Console.WriteLine("Invalid move format.");
                Console.ReadLine();
                continue;
            }

            (int startRow, int startCol) = ParsePosition(moveParts[0]);
            (int endRow, int endCol) = ParsePosition(moveParts[1]);

            // Debugging output for position
            Console.WriteLine($"Start Position: {moveParts[0]} -> ({startRow}, {startCol})");
            Console.WriteLine($"End Position: {moveParts[1]} -> ({endRow}, {endCol})");

            // Check if the piece at start position belongs to the current player
            Piece piece = board.Grid[startRow, startCol];

            // Debugging output for piece at start position
            if (piece == null)
            {
                Console.WriteLine("No piece at the start position.");
                Console.ReadLine();
                continue;
            }
            else
            {
                Console.WriteLine($"Piece at {moveParts[0]} is {(piece.IsWhite ? "White" : "Black")}");
            }

            if (piece == null || piece.IsWhite != isWhiteTurn)
            {
                Console.WriteLine("Please use your pieces.");
                Console.ReadLine();
                continue;
            }

            if (board.MovePiece(startRow, startCol, endRow, endCol))
            {
                // Check if a pawn has reached the promotion row
                if (piece is Pawn && ((piece.IsWhite && endRow == 0) || (!piece.IsWhite && endRow == 7)))
                {
                    board.Grid[endRow, endCol] = new Queen(piece.IsWhite); // Promote the pawn to a Queen
                    Console.WriteLine($"Pawn promoted to Queen at {endRow + 1}, {endCol + 1}!");
                }

                // If the move was valid, switch turns
                isWhiteTurn = !isWhiteTurn;
                Console.WriteLine("Move successful!");
            }
            else
            {
                Console.WriteLine("Invalid move.");
                Console.ReadLine();
            }
        }
    }

    private (int, int) ParsePosition(string pos)
    {
        // Convert the column (a-h) to an integer (0-7)
        int col = pos[0] - 'a'; 

        // Convert the row (1-8) to an integer (7-0)
        int row = 8 - int.Parse(pos[1].ToString());

        return (row, col); // Return as (row, col) tuple
    }

    private bool HasKing(bool white)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Piece piece = board.Grid[row, col];
                if (piece is King && piece.IsWhite == white)
                {
                    return true; // King is present
                }
            }
        }
        return false; // King is missing
    }
}
