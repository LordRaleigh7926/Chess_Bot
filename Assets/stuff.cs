using System.Collections.Generic;
using System.Text;
    public class Pieces{

        public const int None = 0;
        public const int King = 2;
        public const int Pawn = 4;
        public const int Knight = 3;
        public const int Bishop = 1;
        public const int Rook = 6;
        public const int Queen = 5;

        public const int White = 8;
        public const int Black = 16;

    }

    public class Board{

        private bool isWhiteTurn = true;  // Define the isWhiteTurn variable

        public int[] Square;

        public string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        public void settingBoard() {
            Square = new int[64];

            fromFEN(fen);
        }

        public void fromFEN(string fen) {


            var fromPieceSymbol = new Dictionary<char, int> (){
                ['k'] = Pieces.King,
                ['p'] = Pieces.Pawn,
                ['n'] = Pieces.Knight,
                ['b'] = Pieces.Bishop,
                ['r'] = Pieces.Rook,
                ['q'] = Pieces.Queen
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
                    int pieceColor = (char.IsUpper(symbol)) ? Pieces.White : Pieces.Black;
                    int pieceType = fromPieceSymbol[char.ToLower(symbol)];
                    Square[row*8 + col] = pieceType | pieceColor;
                    col++;
                }
            }
        }
        // Set the turn information from the FEN string
        isWhiteTurn = fen.Split(' ')[1] == "w";
        
    }
        public void MakeMove(int from, int to)
        {
            // Make the move on the board
            Square[to] = Square[from];
            Square[from] = Pieces.None;
            
            // Toggle the turn
            isWhiteTurn = !isWhiteTurn;

            // Update the FEN string
            // fen = ToFEN();
        }

    public string ToFEN()
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 7; row >= 0; row--)
        {
            int emptySquares = 0;
            for (int col = 0; col < 8; col++)
            {
                int piece = Square[row * 8 + col];
                if (piece == Pieces.None)
                {
                    emptySquares++;
                }
                else
                {
                    if (emptySquares > 0)
                    {
                        sb.Append(emptySquares);
                        emptySquares = 0;
                    }
                    bool isWhite = (piece & Pieces.White) == Pieces.White;
                    int pieceType = piece & ~Pieces.White & ~Pieces.Black;
                    char pieceChar = pieceType switch
                    {
                        Pieces.King => 'k',
                        Pieces.Queen => 'q',
                        Pieces.Rook => 'r',
                        Pieces.Bishop => 'b',
                        Pieces.Knight => 'n',
                        Pieces.Pawn => 'p',
                        _ => ' '
                    };
                    sb.Append(isWhite ? char.ToUpper(pieceChar) : pieceChar);
                }
            }
            if (emptySquares > 0)
            {
                sb.Append(emptySquares);
            }
            if (row > 0)
            {
                sb.Append('/');
            }
        }

        // Append additional FEN fields
        sb.Append(isWhiteTurn ? " w " : " b ");
        // Note: Simplified castling rights, en passant, halfmove clock, fullmove number for this example
        sb.Append("KQkq - 0 1");

        return sb.ToString();
    }
    }
