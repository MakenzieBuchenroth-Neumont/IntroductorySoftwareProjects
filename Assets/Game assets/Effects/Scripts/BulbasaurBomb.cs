using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbasaurBomb : MonoBehaviour
{

    public float bombSpeed;
    [SerializeField] int damage;
    public Vector2 moveDirection;
    public Rigidbody2D bombRB;
    public GameObject bombEffect;
    [SerializeField] private TowerTargeting towerIAmFrom;
    [SerializeField] private StatusEffect effect;
    // Start is called before the first frame update

    public void SetTowerFrom(TowerTargeting towerfrom)
    {
        towerIAmFrom = towerfrom;
    }

    void Start()
    {   // attach RigidBody2D to bombRB object 
        bombRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        bombRB.velocity = (transform.rotation * moveDirection) * bombSpeed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed
        if (collision.gameObject.tag == "bad_guy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.damage, towerIAmFrom);
            Debug.Log(effect);
            if (effect != null)
            {
                collision.gameObject.GetComponent<Enemy>().AddStatus(effect);
                effect.towerICameFrom = towerIAmFrom;
            }
            Instantiate(bombEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }
}
