using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hit_points = 0;
    public float max_speed = 0.1f;
    public float speed = 0.1f;
    [SerializeField] int max_hit_points = 0;
    [SerializeField] int damage = 0;
    [SerializeField] float xp_amount = 0.0f;
    [SerializeField] int coin_amount = 0;
    [SerializeField] enemyType type;
    [SerializeField] List<StatusEffect> mystatuseffects;
    //Enemy Types
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

    public Sprite sprite4;
    [SerializeField] private Sprite medic_up;
    [SerializeField] private Sprite medic_down;
    [SerializeField] private Sprite medic_left;
    [SerializeField] private Sprite medic_heal;
    // this is the variables used in walking across the line
    private Path pathIfollow;
    private EnemySpawner spawner;

    private float timer;
    public int currentpoint = 0;
    public float currentpathprogress = 0;

    public enum enemyType { Basic, Tank, Fast, Medic }
    public enemyType GetEnemyType() { return type; }
    public void SetEnemyType(enemyType ee) { type = ee; }
    public int[] status_effects;

    void Start()
    {

        
        if (mystatuseffects.Count > 0)
        {
            List<StatusEffect> effects = new List<StatusEffect>();
            foreach(var effect in mystatuseffects)
            {
                effects.Add(Instantiate(effect));
            }
            mystatuseffects = effects;
        }

        switch (type)
        {
            case enemyType.Basic:
                hit_points = 5;
                max_hit_points = hit_points;
                damage = 1;
                max_speed = 1.0f;
                speed = max_speed;
                xp_amount = 15.0f;
                coin_amount = 5;
                ChangeSprite(sprite1);
                break;
            case enemyType.Tank:
                hit_points = 20;
                max_hit_points = hit_points;
                ChangeSprite(sprite3);
                damage = 3;
                max_speed = 0.75f;
                speed = max_speed;
                xp_amount = 20.0f;
                coin_amount = 12;
                break;
            case enemyType.Fast:
                hit_points = 3;
                max_hit_points = hit_points;
                damage = 2;
                max_speed = 2.0f;
                speed = max_speed;
                xp_amount = 15.0f;
                coin_amount = 10;
                ChangeSprite(sprite2);
                break;
            case enemyType.Medic: 
                hit_points = 10;
                max_hit_points = hit_points;
                damage = 1;
                max_speed = 1.5f;
                speed = max_speed;
                xp_amount = 10.0f;
                coin_amount = 10;
                break;
        }

        transform.position = pathIfollow.pathway[currentpoint];
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        speed = max_speed;
        // update status effect stuff
        for(int s = 0; s < mystatuseffects.Count; s++)
        {
            if (!mystatuseffects[s].IsStatusDone())
            {
                mystatuseffects[s].DoStatusEffect(this);
            } else
            {
                mystatuseffects.RemoveAt(s);
                s--;
            }
        }

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
            LevelManager.main.decreaseLives(damage);
            Destroy(this.gameObject);
        }
        //if (timer >= 3 && this.e == enemyType.Medic)
        //{
        //    timer = 0.0f;
        //}
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
            case enemyType.Medic:
                if (newpos.x < currentpos.x) ChangeSprite(medic_left);
                else if (newpos.x > currentpos.x) ChangeSprite(sprite4);
                else if (newpos.y < currentpos.y) ChangeSprite(medic_down);
                else if (newpos.y > currentpos.y) ChangeSprite(medic_up);
                if (this.speed == 0) ChangeSprite(medic_heal);
                break;
        }
    }
    public void TakeDamage(int damage, TowerTargeting towerthatkilledme)
    {
        hit_points -= damage;
        if (hit_points <= 0)
        {
            LevelManager.main.increaseCurrency(coin_amount * 10);
            towerthatkilledme.increaseExp((int)xp_amount * 10);
            Die();
        }
    }
    public void GainHealth()
    {
        int healing = max_hit_points - (hit_points + 2);
        if (hit_points < max_hit_points && hit_points > 0)
        {
            hit_points += healing;
        }
    }

    public void AddStatus(StatusEffect status)
    {
        List<StatusEffect> effects = new List<StatusEffect>();
        foreach (var effect in mystatuseffects)
        {
            effects.Add(effect);
        }
        effects.Add(Instantiate(status));
        mystatuseffects = effects;
    }
    private void Die()
    {
        spawner.RemoveEnemy(this.gameObject);
        Destroy(gameObject);
    }
}
