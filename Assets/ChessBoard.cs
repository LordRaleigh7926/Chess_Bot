using UnityEngine;
using System.Collections.Generic;

    
    public class ChessBoardManager : MonoBehaviour
    {
        public GameObject tilePrefab;
        public GameObject[] whitePiecePrefabs;
        public GameObject[] blackPiecePrefabs;
        private const int boardSize = 8;
        private Color customWhite = new Color(235f / 255f, 236f / 255f, 208f / 255f); // RGB values for ebecd0
        private Color customBlack = new Color(115f / 255f, 149f / 255f, 82f / 255f); // RGB values for 739552
        private const float pieceScale = 0.33f;
        public const float pieceDragDepth = -0.2f;

        //private Pieces Piece = new Pieces();

        public Board chessBoard = new Board();

        public List<GameObject> chessPieces = new List<GameObject>();

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
            chessBoard.MakeMove(12, 28);
            UpdatePieces(12,28);
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
                    tileRenderer.color = customBlack;
                }
                else
                {
                    tileRenderer.color = customWhite;
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

            if (piece != Pieces.None)
            {
                // Determine the color and type of the piece
                int color = piece & (Pieces.White | Pieces.Black);
                int type = piece & ~(Pieces.White | Pieces.Black);

                // Get the appropriate prefab based on color and type
                GameObject piecePrefab = (color == Pieces.White) ? whitePiecePrefabs[type-1] : blackPiecePrefabs[type - 1];


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

        void UpdatePieces(int from, int to)
        {
            int piece = chessBoard.Square[to];
            int row = to / 8;
            int col = to % 8;
            Vector2 position = new Vector2(col, row);

            if (piece != Pieces.None)
            {
                // Determine the color and type of the piece
                int color = piece & (Pieces.White | Pieces.Black);
                int type = piece & ~(Pieces.White | Pieces.Black);

                // Get the appropriate prefab based on color and type
                GameObject piecePrefab = (color == Pieces.White) ? whitePiecePrefabs[type-1] : blackPiecePrefabs[type - 1];


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
            row = from / 8;
            col = from % 8;
            position = new Vector2(col, row);
            DeletePiece(position);


        }
        void PlacePiece(GameObject piecePrefab, Vector2 position)
        {
            if (piecePrefab != null)
            {
                GameObject piece = Instantiate(piecePrefab, position, Quaternion.identity);
                piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);
                chessPieces.Add(piece);
            }
            else
            {
                Debug.LogError("Piece prefab is null. Check the prefab loading.");
            }
        }
        void DeletePiece(Vector2 position)
        {
        GameObject pieceToDelete = null;
        foreach (GameObject piece in chessPieces)
        {
            if ((Vector2)piece.transform.position == position)
            {
                pieceToDelete = piece;
                break;
            }
        }

        if (pieceToDelete != null)
        {
            chessPieces.Remove(pieceToDelete);
            Destroy(pieceToDelete);
        }
        else
        {
            Debug.LogError("No piece found at the given position.");
        }
    }

    public Vector2Int GetGridPosition(Vector2 worldPosition)
    {
        float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        int x = Mathf.RoundToInt(worldPosition.x / tileSize);
        int y = Mathf.RoundToInt(worldPosition.y / tileSize);
        return new Vector2Int(x, y);
    }


    public Vector2 GetWorldPosition(Vector2Int gridPosition)
    {
        float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        return new Vector2(gridPosition.x * tileSize, gridPosition.y * tileSize);
    }

    public void MovePiece(GameObject piece, Vector2Int gridPosition)
    {
        Vector2 worldPosition = GetWorldPosition(gridPosition);
        piece.transform.position = worldPosition;
        // Update the chess board model here
        // Example: chessBoard.MakeMove(from, to);
    }

    public bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        // Implement logic to check if the move is valid according to chess rules
        return true;
    }

    }
