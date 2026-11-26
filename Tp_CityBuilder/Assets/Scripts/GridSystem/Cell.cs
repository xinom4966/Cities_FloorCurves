using UnityEngine;

public class Cell
{
    private (int, int) gridPos;
    public Vector3 worldPos { get; private set; }
    private bool isEmpty;

    public Cell((int,int) gridPosition, Vector3 worldPosition)
    {
        gridPos = gridPosition;
        worldPos = worldPosition;
        isEmpty = true;
    }
}
