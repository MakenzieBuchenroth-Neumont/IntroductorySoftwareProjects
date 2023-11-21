using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailMarySpawner : MonoBehaviour
{
    public GameObject fireBulletPrefab;
    public GameObject bombPrefab;
    public int numSpawn = 10;
    public Vector2 spawnArea = new Vector2(10f, 10f);
    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapons();
    }

    void SpawnWeapons()
    {
        for (int i = 0; i < numSpawn; i++)
        {
            // Generate a random position within the spawn area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
            );

            Instantiate(fireBulletPrefab, spawnPosition, Quaternion.identity);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
