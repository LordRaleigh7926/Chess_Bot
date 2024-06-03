
using System.Collections.Generic;

    public class Pieces{

        public int None = 0;
        public int King = 1;
        public int Pawn = 2;
        public int Knight = 3;
        public int Bishop = 4;
        public int Rook = 5;
        public int Queen = 6;

        public int White = 8;
        public int Black = 16;

    }

    public class Board{

        private Pieces Piece = new Pieces();

        public int[] Square;

        public const string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        public void settingBoard() {
            Square = new int[64];

            fromFEN(fen);
        }

        public void fromFEN(string fen) {


            var fromPieceSymbol = new Dictionary<char, int> (){
                ['k'] = Piece.King,
                ['p'] = Piece.Pawn,
                ['n'] = Piece.Knight,
                ['b'] = Piece.Bishop,
                ['r'] = Piece.Rook,
                ['q'] = Piece.Queen
            };

            string fenBoard = fen.Split(' ')[0];
            int col = 0;
            int row = 7;

            foreach (char symbol in fenBoard) {
                if (symbol == '/') {
                    col = 0;
                    row--;

            } else {

                if (char.IsDigit(symbol)){
                    col += (int) char.GetNumericValue(symbol);
                } else {
                    int pieceColor = (char.IsUpper(symbol)) ? Piece.White : Piece.Black;
                    int pieceType = fromPieceSymbol[char.ToLower(symbol)];
                    Square[row*8 + col] = pieceType | pieceColor;
                    col++;
                }
            }
        }
    }
    }
