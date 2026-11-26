using UnityEngine;

public class WorldSetup : MonoBehaviour
{
    [SerializeField] private SO_GridData worldGridData;
    [SerializeField] private GridPlacer gridPlacer;
    private Grid worldGrid;

    private void Start()
    {
        worldGrid = new Grid(transform.position, worldGridData.gridSize, worldGridData.cellSize, worldGridData.cellPreview);
        gridPlacer.SetWorldGrid(worldGrid);
    }
}
