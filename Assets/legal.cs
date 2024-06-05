using System;


public static class LegalMoves{


    public static void checkLegalMoves(int piece, int from, Board chessBoard){


        int color = piece & (Pieces.White | Pieces.Black);
        int type = piece & ~(Pieces.White | Pieces.Black);

        if (chessBoard.isWhiteTurn) {

            if (color == Pieces.White) {

                switch (type) {

                    case Pieces.King:
                        King.checkKingMoves(from, color, chessBoard);
                        break;

                    case Pieces.Queen:
                        Queen.checkQueenMoves(from, color, chessBoard);
                        break;

                    case Pieces.Rook:
                        Rook.checkRookMoves(from, color, chessBoard);
                        break;

                    case Pieces.Bishop:
                        Bishop.checkBishopMoves(from, color, chessBoard);
                        break;
                        
                    case Pieces.Pawn:
                        Pawn.checkPawnMoves(from, color, chessBoard);
                        break;

                    case Pieces.Knight:
                        Knight.checkKnightMoves(from, color, chessBoard);
                        break;
                }

            }
        
        } else {

            if (color == Pieces.Black) {

                switch (type) {

                    case Pieces.King:
                        King.checkKingMoves(from, color, chessBoard);
                        break;

                    case Pieces.Queen:
                        Queen.checkQueenMoves(from, color, chessBoard);
                        break;

                    case Pieces.Rook:
                        Rook.checkRookMoves(from, color, chessBoard);
                        break;

                    case Pieces.Bishop:
                        Bishop.checkBishopMoves(from, color, chessBoard);
                        break;
                        
                    case Pieces.Pawn:
                        Pawn.checkPawnMoves(from, color, chessBoard);
                        break;

                    case Pieces.Knight:
                        Knight.checkKnightMoves(from, color, chessBoard);
                        break;
                }


            }
        }
    }
}