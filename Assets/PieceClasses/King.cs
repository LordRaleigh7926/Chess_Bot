using System.Collections.Generic;

public static class King
{
    public static List<int> checkKingMoves(int from, int color, Board chessBoard)
    {
        List<int> legalMovesKing = new List<int>();

        int[] moves = { -9, -8, -7, -1, 1, 7, 8, 9 };

        foreach (int move in moves)
        {
            int to = from + move;
            if (to >= 0 && to < 64)
            {
                int toTile = chessBoard.Square[to];
                int col = toTile & (Pieces.White | Pieces.Black);
                if (toTile == Pieces.None || col != color)
                {
                    legalMovesKing.Add(to);
                }
            }
        }

        return legalMovesKing;
    }
}
