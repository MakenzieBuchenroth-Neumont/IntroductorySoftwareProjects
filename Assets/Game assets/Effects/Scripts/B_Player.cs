using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a temp script to emulate the UI gameplay code - need to integrate with the tower/UI
public class B_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Header("Bulbasaur Attack")]
    public BulbasaurBomb bullet;
    public Transform firePoint_B;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("FireWeapon"))
            {   // make a copy of bullet at position of firePoint (
            Instantiate(bullet, firePoint_B.position, firePoint_B.rotation).moveDirection = new Vector2(transform.localScale.x, transform.localScale.y);
        }
    }

   
}


