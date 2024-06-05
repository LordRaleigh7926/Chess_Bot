using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private ChessBoardManager chessBoardManager;
    private Vector2Int originalPosition;
    private Vector2Int currentPosition;

    void Start()
    {
        chessBoardManager = FindObjectOfType<ChessBoardManager>();
        currentPosition = chessBoardManager.GetGridPosition(transform.position);
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originalPosition = chessBoardManager.GetGridPosition(transform.position);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = ChessBoardManager.pieceDragDepth; // Ensure the piece stays on the same plane
            transform.position = newPosition;
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            Vector2Int gridPosition = chessBoardManager.GetGridPosition(transform.position);
            if (chessBoardManager.IsValidMove(originalPosition, gridPosition))
            {
                chessBoardManager.MovePiece(this.gameObject, originalPosition, gridPosition);
                currentPosition = gridPosition;
            }
            else
            {
                transform.position = chessBoardManager.GetWorldPosition(currentPosition);
            }
        }
    }
}
