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
