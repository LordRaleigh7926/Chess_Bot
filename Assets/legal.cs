using System;
using System.Collections.Generic;


public static class LegalMoves{


    public static List<int> checkLegalMoves(int piece, int from, Board chessBoard){
        List<int> moves = new List<int>();

        int color = piece & (Pieces.White | Pieces.Black);
        int type = piece & ~(Pieces.White | Pieces.Black);

        if (chessBoard.isWhiteTurn) {

            if (color == Pieces.White) {

                switch (type) {

                    case Pieces.King:
                        moves = King.checkKingMoves(from, color, chessBoard);
                        break;

                    case Pieces.Queen:
                        moves =Queen.checkQueenMoves(from, color, chessBoard);
                        break;

                    case Pieces.Rook:
                        moves =Rook.checkRookMoves(from, color,chessBoard);
                        break;

                    case Pieces.Bishop:
                        moves = Bishop.checkBishopMoves(from, color,chessBoard);
                        break;
                        
                    case Pieces.Pawn:
                        moves = Pawn.checkPawnMoves(from, color, chessBoard);
                        break;

                    case Pieces.Knight:
                        moves = Knight.checkKnightMoves(from, color, chessBoard);
                        break;
                }

                

            }
        
        } else {

            if (color == Pieces.Black) {

                switch (type) {

                    case Pieces.King:
                        moves =King.checkKingMoves(from, color, chessBoard);
                        break;

                    case Pieces.Queen:
                        moves =Queen.checkQueenMoves(from, color, chessBoard);
                        break;

                    case Pieces.Rook:
                        moves =Rook.checkRookMoves(from, color,chessBoard);
                        break;

                    case Pieces.Bishop:
                        moves = Bishop.checkBishopMoves(from, color, chessBoard);
                        break;
                        
                    case Pieces.Pawn:
                        moves =Pawn.checkPawnMoves(from, color, chessBoard);
                        break;

                    case Pieces.Knight:
                        moves =Knight.checkKnightMoves(from, color, chessBoard);
                        break;
                }
                

            }
        }
        return moves;
    }
}