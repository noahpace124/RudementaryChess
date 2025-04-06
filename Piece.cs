public abstract class Piece
{
    public bool IsWhite { get; private set; }
    public char Symbol { get; protected set; }

    public Piece(bool isWhite)
    {
        IsWhite = isWhite;
    }

    public abstract bool IsValidMove(int startRow, int startCol, int endRow, int endCol, Piece[,] board);
}
