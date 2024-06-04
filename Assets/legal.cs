using System;


public static class LegalMoves{


    public static void checkLegalMoves(Pieces piece){

        int color = piece & (Pieces.White | Pieces.Black);
        int type = piece & ~(Pieces.White | Pieces.Black);

        if (color == Pieces.White){ // Piece is white

            

        } else { // Piece is black

        }
    }
}