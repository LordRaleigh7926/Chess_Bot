
using System.Collections.Generic;
public static class Bishop{

    public static List<int> checkBishopMoves(int from, int color, Board chessBoard){

        List<int> legalMovesBishop = new List<int>(); 


        int i = 9;
        
        while(i>0) {

            try
            {
                int toTile = chessBoard.Square[from+i];

                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from+i);
                }
                else { 

                    int col = toTile & (Pieces.White | Pieces.Black);
                    
                    if (col != color) {
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
            i+=9;
        }


        i = 7;

        while(i>0) {

            try
            {
                int toTile = chessBoard.Square[from+i];


                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from+i);
                }
                else { 

                    int col = toTile & (Pieces.White | Pieces.Black);
                    
                    if (col != color) {
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
            i+=7;
        }



        i = 9;

        while( i>0) {

            try
            {
                int toTile = chessBoard.Square[from-i];

                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from-i);
                }
                else { 

                    int col = toTile & (Pieces.White | Pieces.Black);
                    
                    if (col != color) {
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
            i+=9;
        }


        i = 7;

        while(i>0) {

            try
            {
                int toTile = chessBoard.Square[from-i];


                if (toTile == Pieces.None) {
                    legalMovesBishop.Add(from-i);
                }
                else { 

                    int col = toTile & (Pieces.White | Pieces.Black);
                    
                    if (col != color) {
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
            i+=7;
        }
    return legalMovesBishop;
    }
}