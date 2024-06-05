using System;


public static class LegalMoves{


    public static void checkLegalMoves(int piece, int from){


        int color = piece & (Pieces.White | Pieces.Black);
        int type = piece & ~(Pieces.White | Pieces.Black);

        if (chessBoard.isWhiteTurn) { //CHECK HERE

            if (color == Pieces.White) {

                switch (type) {

                    case Pieces.King:
                        King.checkKingMoves(from, color);
                        break;

                    case Pieces.Queen:
                        Queen.checkQueenMoves(from,color);
                        break;

                    case Pieces.Rook:
                        Rook.checkRookMoves(from, color);
                        break;

                    case Pieces.Bishop:
                        Bishop.checkBishopMoves(from, color);
                        break;
                        
                    case Pieces.Pawn:
                        Pawn.checkPawnMoves(from, color);
                        break;

                    case Pieces.Knight:
                        Knight.checkKnightMoves(from, color);
                        break;
                }

            }
        
        } else {

            if (color == Pieces.Black) {

                switch (type) {

                    case Pieces.King:
                        King.checkKingMoves(from, color);
                        break;

                    case Pieces.Queen:
                        Queen.checkQueenMoves(from,color);
                        break;

                    case Pieces.Rook:
                        Rook.checkRookMoves(from, color);
                        break;

                    case Pieces.Bishop:
                        Bishop.checkBishopMoves(from, color);
                        break;
                        
                    case Pieces.Pawn:
                        Pawn.checkPawnMoves(from, color);
                        break;

                    case Pieces.Knight:
                        Knight.checkKnightMoves(from, color);
                        break;
                }


            }
        }
    }
}