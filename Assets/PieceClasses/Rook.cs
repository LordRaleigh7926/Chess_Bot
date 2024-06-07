using System.Collections.Generic;

public static class Rook
{
    public static List<int> checkRookMoves(int from, int color, Board chessBoard)
    {
        List<int> legalMovesRook = new List<int>();

        int[] directions = { 1, -1, 8, -8 }; // Right, Left, Up, Down

        foreach (int direction in directions)
        {
            int i = direction;
            while (true)
            {
                try
                {
                    int toTile = chessBoard.Square[from + i];

                    if (toTile == Pieces.None)
                    {
                        legalMovesRook.Add(from + i);
                    }
                    else
                    {
                        int col = toTile & (Pieces.White | Pieces.Black);
                        if (col != color)
                        {
                            legalMovesRook.Add(from + i);
                        }
                        break;
                    }
                }
                catch (System.Exception)
                {
                    break;
                }
                i += direction;
            }
        }
        return legalMovesRook;
    }
}
