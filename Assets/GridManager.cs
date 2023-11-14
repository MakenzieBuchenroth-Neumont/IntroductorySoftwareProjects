using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap gridTilemap;
    public Path path;

    void Start()
    {
        // Your initialization code here
    }

    public bool IsTileClickable(Vector3Int cellPosition)
    {
        // Check if the tile is within the grid
        if (gridTilemap.HasTile(cellPosition))
        {
            // Check if the tile is part of the path
            Vector3 tileWorldPosition = gridTilemap.GetCellCenterWorld(cellPosition);
            return !IsPointOnPath(tileWorldPosition);
        }

        // Tile is outside the grid
        return false;
    }

    private bool IsPointOnPath(Vector3 point)
    {
        // Check if the point is on the path
        for (int i = 0; i < path.pathway.Count - 1; i++)
        {
            float distance = Vector3.Distance(point, path.pathway[i]);
            float pathSegmentLength = Vector3.Distance(path.pathway[i], path.pathway[i + 1]);

            // Use a small threshold value to account for precision errors
            if (distance <= 0.1f && distance <= pathSegmentLength)
            {
                return true;
            }
        }

        return false;
    }
}
