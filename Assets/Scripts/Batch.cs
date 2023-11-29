using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Batch",menuName ="Enemy Batch")]
public class Batch : ScriptableObject
{
    [SerializeField] private GameObject enemy;
    public int numberOfEnemy;
    public float enemyDelay;
    public float batchDelay = 1.0f;

    public Batch(Batch b)
    {
        enemy = b.enemy;
        numberOfEnemy = b.numberOfEnemy;
        enemyDelay = b.enemyDelay;
        batchDelay = b.batchDelay;
    }

    public GameObject GetEnemy()
    {
        return enemy;
    }
}
