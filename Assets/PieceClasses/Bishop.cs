using System;

public static class Bishop{

    public static void checkBishopMoves(int from, int color, Board chessBoard){

        int[] legalMovesBishop = new int[]; 



        
        while(int i = 9; i>0; i+=9) {

            try
            {
                toTile = chessBoard.Square[from+i];

                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from+i);
                }
                else { 

                    int color = toTile & (Pieces.White | Pieces.Black);
                    
                    if (color != color) {
                        legalMovesBishop.Add(from+i);
                    } else {
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                break;
            }
        }




        while(int i = 7; i>0; i+=7) {

            try
            {
                toTile = chessBoard.Square[from+i];


                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from+i);
                }
                else { 

                    int color = toTile & (Pieces.White | Pieces.Black);
                    
                    if (color != color) {
                        legalMovesBishop.Add(from+i);
                    } else {
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                
                break;
            }
        }





        while(int i = 9; i>0; i+=9) {

            try
            {
                toTile = chessBoard.Square[from-i];

                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from-i);
                }
                else { 

                    int color = toTile & (Pieces.White | Pieces.Black);
                    
                    if (color != color) {
                        legalMovesBishop.Add(from-i);
                    } else {
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                
                break;
            }
        }




        while(int i = 7; i>0; i+=7) {

            try
            {
                toTile = chessBoard.Square[from-i];


                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from-i);
                }
                else { 

                    int color = toTile & (Pieces.White | Pieces.Black);
                    
                    if (color != color) {
                        legalMovesBishop.Add(from-i);
                    } else {
                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                
                break;
            }
        }
    }
}