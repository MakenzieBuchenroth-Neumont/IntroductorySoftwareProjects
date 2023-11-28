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

    public Sprite sprite1;
    [SerializeField] private Sprite basic_up;
    [SerializeField] private Sprite basic_down;
    [SerializeField] private Sprite basic_left;
    
    public Sprite sprite2;
    [SerializeField] private Sprite fast_up;
    [SerializeField] private Sprite fast_down;
    [SerializeField] private Sprite fast_left;
    public Sprite sprite3;
    [SerializeField] private Sprite big_up;
    [SerializeField] private Sprite big_down;
    [SerializeField] private Sprite big_left;

    // this is the variables used in walking across the line
    private Path pathIfollow;
    private EnemySpawner spawner;

    public int currentpoint = 0;
    public float currentpathprogress = 0;

    public enum enemyType { Basic, Tank, Fast }
    public enemyType GetEnemyType() { return type; }
    public void SetEnemyType(enemyType ee) { type = ee; }
    public bool flipped = true;

    void Start()
    {
        switch (type)
        {
            case enemyType.Basic:
                hit_points = 5;
                max_hit_points = hit_points;
                damage = 1;
                speed = 1.0f;
                ChangeSprite(sprite1);
                break;
            case enemyType.Tank:
                hit_points = 20;
                max_hit_points = hit_points;
                ChangeSprite(sprite3);
                damage = 3;
                speed = 0.75f;
                break;
            case enemyType.Fast:
                hit_points = 3;
                max_hit_points = hit_points;
                damage = 2;
                speed = 2.0f;
                ChangeSprite(sprite2);
                break;
        }

        transform.position = pathIfollow.pathway[currentpoint];
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
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
                    UpdateSprite();

                }
            } else
            {
                if (currentpathprogress <= 0)
                {
                    currentpathprogress = 1;
                    currentpoint--;
                    UpdateSprite();

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
    public void ChangeSprite(Sprite newSprite) 
    { 
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
public void UpdateSprite()
    {
        Vector3 newpos = pathIfollow.pathway[currentpoint + 1];
        Vector3 currentpos = pathIfollow.pathway[currentpoint];

        switch (type)
        {
            case enemyType.Basic:
                if (newpos.x < currentpos.x) ChangeSprite(basic_left);
                else if (newpos.x > currentpos.x) ChangeSprite(sprite1);
                else if (pathIfollow.pathway[currentpoint + 1].y < pathIfollow.pathway[currentpoint].y) ChangeSprite(basic_down);
                else if (pathIfollow.pathway[currentpoint + 1].y > pathIfollow.pathway[currentpoint].y) ChangeSprite(basic_up);

                break;
            case enemyType.Fast:
                if (newpos.x < currentpos.x) ChangeSprite(fast_left);
                else if (newpos.x > currentpos.x) ChangeSprite(sprite2);
                else if (newpos.y < currentpos.y) ChangeSprite(fast_down);
                else if (newpos.y > currentpos.y) ChangeSprite(fast_up);
              
                break;
            case enemyType.Tank:
                if (newpos.x < currentpos.x) ChangeSprite(big_left);
                else if (newpos.x > currentpos.x) ChangeSprite(sprite3);
                else if (newpos.y < currentpos.y) ChangeSprite(big_down);
                else if (newpos.y > currentpos.y) ChangeSprite(big_up);
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
