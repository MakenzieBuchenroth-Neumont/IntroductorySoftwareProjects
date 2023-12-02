using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtleWater : MonoBehaviour
{
    public float waterSpeed;
    public Vector2 moveDirection;
    public Rigidbody2D waterRB;
    public GameObject waterEffect;
    // Start is called before the first frame update

    void Start()
    {   // attach RigidBody2D to waterRB object 
        waterRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        waterRB.velocity = moveDirection * waterSpeed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed
        Instantiate(waterEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }
}
