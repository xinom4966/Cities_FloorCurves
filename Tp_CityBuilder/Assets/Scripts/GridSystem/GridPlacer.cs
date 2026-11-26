using UnityEngine;
using UnityEngine.InputSystem;

public class GridPlacer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private SO_GridData playerGridData;
    private Grid worldGrid;
    private Grid playerGrid;
    private Vector3 mousePos;
    private Vector3 lastNearestCell = Vector3.zero;

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        if (worldGrid.GetNearestCell(mousePos) == lastNearestCell)
        {
            return;
        }
        lastNearestCell = worldGrid.GetNearestCell(mousePos);
        if (playerGrid != null)
        {
            playerGrid.ClearPreview();
        }
        playerGrid = new Grid(lastNearestCell, playerGridData.gridSize, playerGridData.cellSize, playerGridData.cellPreview);
        playerGrid.cellPreview = worldGrid.cellPreview;
        playerGrid.PreviewPlacement();
    }

    public void SetWorldGrid(Grid grid)
    {
        this.worldGrid = grid;
    }

    public void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Destroy(this);
        }
    }
}
