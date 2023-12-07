using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulbasaurLeaf : MonoBehaviour
{
    public float leafSpeed;
    [SerializeField] int damage;
    public Vector2 moveDirection;
    public Rigidbody2D leafRB;
    private GameObject leafPrefab; // assigned to leaf prefab in Unity
    public GameObject leafEffect;
    [SerializeField] private TowerTargeting towerIAmFrom;
    [SerializeField] private StatusEffect effect;
    public string targetCollisionTag = "TargetObject";

    public void SetTowerFrom(TowerTargeting towerfrom)
    {
        towerIAmFrom = towerfrom;
    }

    // Start is called before the first frame update
    void Start()
    {

        // attach RigidBody2D to leafRB object 
        leafRB = GetComponent<Rigidbody2D>();
        //MultipleLeaves();

        // Check for input to shoot leaves - REPLACE WITH CORRECT KEY DOWN
        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    MultipleLeaves();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        leafRB.velocity = (transform.rotation * moveDirection) * leafSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // when collides game object is destroyed

        if (collision.gameObject.tag == "bad_guy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.damage, towerIAmFrom);
            //Debug.Log(effect);
            if (effect != null)
            {
                collision.gameObject.GetComponent<Enemy>().AddStatus(effect);
                effect.towerICameFrom = towerIAmFrom;
            }
            Instantiate(leafEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    //private void MultipleLeaves()
    //{
    //    int numberOfLeaves = 3; 
    //    float spreadAngle = 10f; // angle between each leaf
    //    Vector2 startPosition = transform.position; // Starting position of the leaves

    //    for (int i = 0; i < numberOfLeaves; i++)
    //    {
    //        // Calculate the rotation for each leaf
    //        float rotationAngle = spreadAngle * (i - numberOfLeaves / 2);
    //        Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle);

    //        // Instantiate leaf prefab and set its initial properties
    //        GameObject newLeaf = Instantiate(leafPrefab, startPosition, rotation);
    //        Rigidbody2D rb = newLeaf.GetComponent<Rigidbody2D>();

    //        // Apply velocity in the direction the leaf is facing
    //        rb.velocity = rotation * Vector2.up * leafSpeed;
    //    }
    //}

   
}


