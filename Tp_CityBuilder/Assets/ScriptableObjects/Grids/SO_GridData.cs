using UnityEngine;

[CreateAssetMenu(fileName = "SO_GridData", menuName = "Scriptable Objects/SO_GridData")]
public class SO_GridData : ScriptableObject
{
    public Vector2Int gridSize = Vector2Int.one;
    public float cellSize = 1;
    public GameObject cellPreview;
}
