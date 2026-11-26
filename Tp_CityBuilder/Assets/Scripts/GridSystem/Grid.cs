using UnityEngine;
using System.Collections.Generic;

public class Grid
{
    public Vector2Int gridSize { get; private set; } = Vector2Int.one;
    public float cellSize { get; private set; } = 1;
    public GameObject cellPreview;
    private List<List<Cell>> grid = new List<List<Cell>>();
    private Transform transform;
    private List<GameObject> tiles = new List<GameObject>();

    public Grid(Vector3 worldPosition)
    {
        GameObject newTransform = new GameObject();
        transform = newTransform.transform;
        Object.Destroy(newTransform);
        transform.position = worldPosition;
    }

    public Grid(Vector3 worldPosition, Vector2Int gridSize, float cellSize, GameObject cellPreview) : this(worldPosition)
    {
        this.gridSize = gridSize; 
        this.cellSize = cellSize;
        this.cellPreview = cellPreview;

        for (int y = 0; y < gridSize.y; y++)
        {
            grid.Add(new List<Cell>());
            for (int x = 0; x < gridSize.x; x++)
            {
                Vector3 cellPos = new Vector3(transform.position.x + x * cellSize, transform.position.y + y * cellSize, transform.position.z);
                Cell newCell = new Cell((x, y), cellPos);
                grid[y].Add(newCell);
            }
        }
    }

    public void PreviewPlacement()
    {
        Vector2 cellPos = new Vector2(transform.position.x, transform.position.y);
        foreach (List<Cell> row in grid)
        {
            foreach (Cell cell in row)
            {
                GameObject newTile = Object.Instantiate(cellPreview, cellPos, Quaternion.identity);
                tiles.Add(newTile);
                cellPos.x += cellSize;
            }
            cellPos.y += cellSize;
            cellPos.x = transform.position.x;
        }
    }

    public void ClearPreview()
    {
        foreach (GameObject tile in tiles)
        {
            Object.Destroy(tile);
        }
    }

    public Vector3 GetNearestCell(Vector3 positionToSnap)
    {
        float smallestDistance = float.MaxValue;
        Cell nearestCell = null;
        foreach(List<Cell> row in grid)
        {
            foreach(Cell cell in row)
            {
                float delta = Vector3.Distance(cell.worldPos, positionToSnap);
                if (delta > smallestDistance)
                {
                    continue;
                }
                smallestDistance = delta;
                nearestCell = cell;
            }
        }
        //Sanity check
        if (nearestCell == null)
        {
            return Vector3.zero;
        }

        return nearestCell.worldPos;
    }
}
