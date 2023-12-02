using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BulbasaurLeaf : MonoBehaviour
{
    public float leafSpeed;
    public Vector2 moveDirection;
    public Rigidbody2D leafRB;
    public GameObject leafPrefab; // assigned to leaf prefab in Unity
    public GameObject leafEffect;

    public string targetCollisionTag = "TargetObject";



    // Start is called before the first frame update
    void Start()
    {

        // attach RigidBody2D to leafRB object 
        leafRB = GetComponent<Rigidbody2D>();
        MultipleLeaves();

        // Check for input to shoot leaves - REPLACE WITH CORRECT KEY DOWN
        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    MultipleLeaves();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        leafRB.velocity = moveDirection * leafSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed


        Instantiate(leafEffect, transform.position, transform.rotation);
        Destroy(gameObject);


        // debug:
        // Log collision details
        Debug.Log("Leaf collided with: " + collision.gameObject.name);
        Debug.Log("Collision at position: " + collision.transform.position);
        Debug.Log("Current speed: " + leafSpeed);



    }

    private void MultipleLeaves()
    {
        int numberOfLeaves = 3; 
        float spreadAngle = 10f; // angle between each leaf
        Vector2 startPosition = transform.position; // Starting position of the leaves

        for (int i = 0; i < numberOfLeaves; i++)
        {
            // Calculate the rotation for each leaf
            float rotationAngle = spreadAngle * (i - numberOfLeaves / 2);
            Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle);

            // Instantiate leaf prefab and set its initial properties
            GameObject newLeaf = Instantiate(leafPrefab, startPosition, rotation);
            Rigidbody2D rb = newLeaf.GetComponent<Rigidbody2D>();

            // Apply velocity in the direction the leaf is facing
            rb.velocity = rotation * Vector2.up * leafSpeed;
        }
    }

    private void OnBecameInvisible()
    {   // when out of camera view gets destroyed
        Destroy(gameObject);
    }
}


