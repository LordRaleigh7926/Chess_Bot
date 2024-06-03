using UnityEngine;


    
    public class ChessBoardManager : MonoBehaviour
    {
        public GameObject tilePrefab;
        public GameObject[] whitePiecePrefabs;
        public GameObject[] blackPiecePrefabs;
        private int boardSize = 8;
        private Color customWhite = new Color(235f / 255f, 236f / 255f, 208f / 255f); // RGB values for ebecd0
        private Color customBlack = new Color(115f / 255f, 149f / 255f, 82f / 255f); // RGB values for 739552
        private float pieceScale = 0.33f;

        private Pieces Piece = new Pieces();

        public Board chessBoard = new Board();

        void Start()
        {
            Camera.main.orthographic = true;
            float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            Camera.main.orthographicSize = (boardSize * tileSize) / 2;
            Camera.main.transform.position = new Vector3((boardSize * tileSize) / 2 - (tileSize / 2), (boardSize * tileSize) / 2 - (tileSize / 2), -10);
            LoadPiecePrefabs();
            GenerateChessBoard();
            chessBoard.settingBoard();
            PlacePieces();
        }

        void LoadPiecePrefabs()
        {
            // Load all white and black pieces from the "Prefabs/Pieces" folder
            whitePiecePrefabs = Resources.LoadAll<GameObject>("Pieces/Prefabs/White");
            blackPiecePrefabs = Resources.LoadAll<GameObject>("Pieces/Prefabs/Black");

            // Debugging the number of prefabs loaded
            Debug.Log("White Piece Prefabs Loaded: " + whitePiecePrefabs.Length);
            Debug.Log("Black Piece Prefabs Loaded: " + blackPiecePrefabs.Length);

            // Ensure there are exactly 6 pieces for each color
            if (whitePiecePrefabs.Length != 6 || blackPiecePrefabs.Length != 6)
            {
                Debug.LogError("There should be exactly 6 white and 6 black piece prefabs.");
            }
        }

        void GenerateChessBoard()
    {
        float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                Vector2 position = new Vector2(x * tileSize, y * tileSize);
                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                tileObject.transform.SetParent(transform);

                // Get the Tile component
                Tile tileComponent = tileObject.GetComponent<Tile>();
                if (tileComponent != null)
                {
                    // Set the position of the tile
                    tileComponent.SetPosition(new Vector2Int(x, y));
                }
                else
                {
                    Debug.LogError("Tile component not found on tile prefab.");
                }

                SpriteRenderer tileRenderer = tileObject.GetComponent<SpriteRenderer>();
                if ((x + y) % 2 == 0)
                {
                    tileRenderer.color = customWhite;
                }
                else
                {
                    tileRenderer.color = customBlack;
                }
            }
        }
    }

    void PlacePieces()
    {
        
            for (int i = 0; i < chessBoard.Square.Length; i++)
            {
                int piece = chessBoard.Square[i];
                int row = i / 8;
                int col = i % 8;
                Vector2 position = new Vector2(col, row);

                if (piece != Piece.None)
                {
                    // Determine the color and type of the piece
                    int color = piece & (Piece.White | Piece.Black);
                    int type = piece & ~(Piece.White | Piece.Black);

                    // Get the appropriate prefab based on color and type
                    GameObject piecePrefab = (color == Piece.White) ? whitePiecePrefabs[type] : blackPiecePrefabs[type - 1];

                    // Place the piece on the board
                    if (piecePrefab != null)
                    {
                        PlacePiece(piecePrefab, position);
                    }
                    else
                    {
                        Debug.LogError("Piece prefab is null. Check the prefab loading.");
                    }
                }
            }
        }

        void PlacePiece(GameObject piecePrefab, Vector2 position)
        {
            if (piecePrefab != null)
            {
                GameObject piece = Instantiate(piecePrefab, position, Quaternion.identity);
                piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);
            }
            else
            {
                Debug.LogError("Piece prefab is null. Check the prefab loading.");
            }
        }
    }
