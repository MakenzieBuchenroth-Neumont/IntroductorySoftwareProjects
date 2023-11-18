using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Path> paths;

    public bool autostart;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private List<Wave> waves;
    private List<Batch> usedBatches = new List<Batch>();

    private List<GameObject> enemies = new List<GameObject>();

    public void StartWave()
    {
        if (currentWave < waves.Count)
        {
            StartCoroutine(BatchSpawner());
            currentWave++;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWave();
        }
        if (autostart && enemies.Count == 0 && usedBatches.Count == 0)
        {
            StartWave();
        }
    }

    public IEnumerator BatchSpawner() // responsible for filling the used batchs from the current wave
    {
        int currentwave = currentWave;
        for (int currentbatch = 0; currentbatch < waves[currentwave].GetBatches().Count; currentbatch++)
        {
            Batch batch = Instantiate(waves[currentwave].GetBatches()[currentbatch]);
            usedBatches.Add(batch);
            StartCoroutine(SpawnEnemy(batch));
            yield return new WaitForSeconds(batch.batchDelay);
        }
    }

    public IEnumerator SpawnEnemy(Batch batch) // responsible for spawning enemies from used batches
    {
        int chosenpath = 0;
        while (batch.numberOfEnemy > 0)
        {
            GameObject g = Instantiate(batch.GetEnemy());
            g.GetComponent<Enemy>().SetPath(paths[chosenpath]);
            g.GetComponent<Enemy>().SetEnemySpawner(this);
            enemies.Add(g);
            batch.numberOfEnemy--;
            yield return new WaitForSeconds(batch.enemyDelay);
            if (chosenpath < paths.Count - 1)
            {
                chosenpath++;
            }
            else
            {
                chosenpath = 0;
            }
        }
        usedBatches.Remove(batch);
    }

    public void RemoveEnemy(GameObject g)
    {
        enemies.Remove(g);
    }
}
