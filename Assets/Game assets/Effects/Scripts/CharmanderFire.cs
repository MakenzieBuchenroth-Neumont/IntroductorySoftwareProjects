using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmanderFire : MonoBehaviour
{
    public float fireSpeed;
    public Vector2 moveDirection;
    public Rigidbody2D fireRB;
    public GameObject fireEffect;
   // private int fireDamage;
    private Animator anim;
    private SpriteRenderer fireSprite;
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
        fireRB.velocity = moveDirection * fireSpeed; 
             
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
        Instantiate(fireEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }


}
