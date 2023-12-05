using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmanderFire : MonoBehaviour
{
    public float fireSpeed;
    [SerializeField] int damage;
    public Vector2 moveDirection;
    public Rigidbody2D fireRB;
    public GameObject fireEffect;
   // private int fireDamage;
    private Animator anim;
    private SpriteRenderer fireSprite;
    [SerializeField] private TowerTargeting towerIAmFrom;
    [SerializeField] private StatusEffect effect;
    // Start is called before the first frame update

    void Start()
    {   // attach RigidBody2D to fireRB object 
        fireRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        fireSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() 
    {
        fireRB.velocity = (transform.rotation * moveDirection) * -fireSpeed; 
             
    }

    // this is for the interaction with enemies but we'll have to work this out further:
    //private void OnTriggerEnter2D(Collider2D fireHit)
    //{
    //    // fire damage
    //    if( fireHit.tag == "bad_guy" )
    //    {
    //        fireHit.GetComponent<Enemy>().TakeDamage(fireDamage);
    //        anim.SetBool("Hit", true);
    //        fireSpeed = 0;
    //    }
    //}

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
            Instantiate(fireEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }


}
