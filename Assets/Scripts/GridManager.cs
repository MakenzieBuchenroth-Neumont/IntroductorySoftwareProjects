using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform camera;

    private Dictionary<Vector2, Tile> tiles;

    private void Start()
    {
        generateGrid();
    }

    void generateGrid() {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                tiles[new Vector2(x,y)] = spawnedTile;
            }
        }

        camera.transform.position = new Vector3((float)width/2 - 0.5f, (float)height / 2 - 0.5f,-10);
    }

    public Tile getTileAtPosition(Vector2 position){
        if (tiles.TryGetValue(position, out var tile)) {
            return tile;
        }

        return null;
    }
}
