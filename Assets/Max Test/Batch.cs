using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Wave",menuName ="Enemy Wave")]
public class Batch : ScriptableObject
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int numberOfEnemy;
    [SerializeField] private float enemyDelay;
    public float waveDelay;

    public Batch(Batch b)
    {
        enemy = b.enemy;
        numberOfEnemy = b.numberOfEnemy;
        enemyDelay = b.enemyDelay;
        waveDelay = b.waveDelay;
    }

    public IEnumerator SpawnEnemy()
    {
        while(numberOfEnemy > 0)
        {
            Instantiate(enemy).GetComponent<LineFollower>().SetPath(FindAnyObjectByType<Path>());
            numberOfEnemy--;
            yield return new WaitForSeconds(enemyDelay);
        }
        Destroy(this);
    }
}
