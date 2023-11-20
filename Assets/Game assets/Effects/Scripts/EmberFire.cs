using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberFire : MonoBehaviour
{
    public float fireSpeed;
    public Vector2 moveDirection;
    private Rigidbody2D fireRB;
    public GameObject bulletEffect;
    // Start is called before the first frame update

    void Start()
    {   // attach RigidBody2D to fireRB object 
        fireRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        fireRB.velocity = moveDirection * fireSpeed; 
             
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed
        Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }


}
