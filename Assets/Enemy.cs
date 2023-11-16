using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hit_points = 0;
    [SerializeField] float speed = 0.1f;
    [SerializeField] int max_hit_points = 0;
    [SerializeField] int damage = 0;
    [SerializeField] enemyType type;

    // this is the variables used in walking across the line
    private Path pathIfollow;
    private EnemySpawner spawner;

    public int currentpoint = 0;
    public float currentpathprogress = 0;

    public enum enemyType { Basic, Tank, Fast }
    public enemyType GetEnemyType() { return type; }
    public void SetEnemyType(enemyType ee) { type = ee; }

    void Start()
    {
        SetEnemyType(enemyType.Tank);
        switch (type)
        {
            case enemyType.Basic:
                hit_points = 5;
                max_hit_points = hit_points;
                damage = 1;
                speed = 1.0f;
                break;
            case enemyType.Tank:
                hit_points = 20;
                max_hit_points = hit_points;
                damage = 3;
                speed = 0.25f;
                break;
            case enemyType.Fast:
                hit_points = 3;
                max_hit_points = hit_points;
                damage = 2;
                speed = 2.0f;
                break;
        }

        transform.position = pathIfollow.pathway[currentpoint];
    }

    // Update is called once per frame
    void Update()
    {
        // probably place this stuff in the enemy
        if (currentpoint < pathIfollow.pathway.Count - 1)
        {
            // move the enemy from the currentpoint point to the next path point based on speed
            if (currentpoint >= 0)
            {
                transform.position = Vector3.Lerp(pathIfollow.pathway[currentpoint], pathIfollow.pathway[currentpoint + 1], currentpathprogress);
                currentpathprogress += (speed / Vector2.Distance(pathIfollow.pathway[currentpoint], pathIfollow.pathway[currentpoint + 1])) * Time.deltaTime;
            }

            if (speed > 0)
            {
                if (currentpathprogress >= 1)
                {
                    currentpathprogress = 0;
                    currentpoint++;
                }
            } else
            {
                if (currentpathprogress <= 0)
                {
                    currentpathprogress = 1;
                    currentpoint--;
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.RemoveEnemy(this.gameObject);
    }

    public void SetEnemySpawner(EnemySpawner e)
    {
        spawner = e;
    }

    public void SetPath(Path path)
    {
        pathIfollow = path;
    }

    public void TakeDamage(int damage)
    {
        hit_points -= damage;
        if ( hit_points <= 0) 
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
