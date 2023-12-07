using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtleWater : MonoBehaviour
{
    public float waterSpeed;
    [SerializeField] int damage;
    public Vector2 moveDirection;
    public Rigidbody2D waterRB;
    public GameObject waterEffect;
    [SerializeField] private TowerTargeting towerIAmFrom;
    [SerializeField] private StatusEffect effect;
    [SerializeField] private int pierce = 1;
    // Start is called before the first frame update

    public void SetTowerFrom(TowerTargeting towerfrom)
    {
        towerIAmFrom = towerfrom;
    }

    void Start()
    {   // attach RigidBody2D to waterRB object 
        waterRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        waterRB.velocity = (transform.rotation * moveDirection) * waterSpeed; 
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
            Instantiate(waterEffect, transform.position, transform.rotation);
            if (pierce <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                pierce--;
            }
        }
    }
}
