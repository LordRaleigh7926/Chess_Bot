using UnityEngine;

public class Tile : MonoBehaviour
{
    // Add a field to store the position
    private Vector2Int position;

    // Method to set the position
    public void SetPosition(Vector2Int pos)
    {
        position = pos;
    }

    // Method to get the position
    public Vector2Int GetPosition()
    {
        return position;
    }
}
