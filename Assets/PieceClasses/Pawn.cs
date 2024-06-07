using System.Collections.Generic;

public static class Pawn
{
    public static List<int> checkPawnMoves(int from, int color, Board chessBoard)
    {
        List<int> legalMovesPawn = new List<int>();
        int direction = (color == Pieces.White) ? 1 : -1;
        int startRank = (color == Pieces.White) ? 1 : 6;
        
        // Move forward one square
        int to = from + 8 * direction;
        if (chessBoard.Square[to] == Pieces.None)
        {
            legalMovesPawn.Add(to);
            
            // Move forward two squares from starting position
            if (from / 8 == startRank)
            {
                to = from + 16 * direction;
                if (chessBoard.Square[to] == Pieces.None)
                {
                    legalMovesPawn.Add(to);
                }
            }
        }

        // Capture diagonally
        int[] diagonalMoves = { 7, 9 };
        foreach (int move in diagonalMoves)
        {
            to = from + move * direction;
            if (to >= 0 && to < 64)
            {
                int toTile = chessBoard.Square[to];
                int col = toTile & (Pieces.White | Pieces.Black);
                if (toTile != Pieces.None && col != color)
                {
                    legalMovesPawn.Add(to);
                }
            }
        }

        return legalMovesPawn;
    }
}
