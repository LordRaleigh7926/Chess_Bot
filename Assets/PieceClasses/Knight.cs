using System.Collections.Generic;

public static class Knight
{
    public static List<int> checkKnightMoves(int from, int color, Board chessBoard)
    {
        List<int> legalMovesKnight = new List<int>();

        int[] moves = { 15, 17, -15, -17, 10, -10, 6, -6 }; // All possible knight moves in 1D array index

        foreach (int move in moves)
        {
            try
            {
                int toTile = chessBoard.Square[from + move];

                if (toTile == Pieces.None)
                {
                    legalMovesKnight.Add(from + move);
                }
                else
                {
                    int col = toTile & (Pieces.White | Pieces.Black);
                    if (col != color)
                    {
                        legalMovesKnight.Add(from + move);
                    }
                }
            }
            catch (System.Exception)
            {
                // Ignore out-of-bound exceptions
            }
        }
        return legalMovesKnight;
    }
}
