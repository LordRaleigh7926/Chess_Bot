using System;


public static class LegalMoves{


    void checkLegalMoves(Pieces piece){

        if (piece == Pieces.None) {
            Debug.LogError("CheckLegalMoves got Pieces.None as a piece in parameter");
        }

        int color = piece & (Pieces.White | Pieces.Black);
        int type = piece & ~(Pieces.White | Pieces.Black);

        if (color == Pieces.White){ // Piece is white

            

        } else { // Piece is black

        }
    }
}