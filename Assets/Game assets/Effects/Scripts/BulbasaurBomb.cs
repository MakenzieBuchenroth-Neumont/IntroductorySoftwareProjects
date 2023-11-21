using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbasaurBomb : MonoBehaviour
{
    public float bombSpeed;
    public Vector2 moveDirection;
    public Rigidbody2D bombRB;
    public GameObject bombEffect;
    // Start is called before the first frame update

    void Start()
    {   // attach RigidBody2D to bombRB object 
        bombRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        bombRB.velocity = moveDirection * bombSpeed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed
        Instantiate(bombEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }
}
