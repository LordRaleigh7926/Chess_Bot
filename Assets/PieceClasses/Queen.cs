using System.Collections.Generic;

public static class Queen
{
    public static List<int> checkQueenMoves(int from, int color, Board chessBoard)
    {
        List<int> legalMovesQueen = new List<int>();

        // Rook-like moves
        int[] rookDirections = { 1, -1, 8, -8 };
        foreach (int direction in rookDirections)
        {
            int i = direction;
            while (true)
            {
                try
                {
                    int toTile = chessBoard.Square[from + i];

                    if (toTile == Pieces.None)
                    {
                        legalMovesQueen.Add(from + i);
                    }
                    else
                    {
                        int col = toTile & (Pieces.White | Pieces.Black);
                        if (col != color)
                        {
                            legalMovesQueen.Add(from + i);
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

        // Bishop-like moves
        int[] bishopDirections = { 9, -9, 7, -7 };
        foreach (int direction in bishopDirections)
        {
            int i = direction;
            while (true)
            {
                try
                {
                    int toTile = chessBoard.Square[from + i];

                    if (toTile == Pieces.None)
                    {
                        legalMovesQueen.Add(from + i);
                    }
                    else
                    {
                        int col = toTile & (Pieces.White | Pieces.Black);
                        if (col != color)
                        {
                            legalMovesQueen.Add(from + i);
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

        return legalMovesQueen;
    }
}
