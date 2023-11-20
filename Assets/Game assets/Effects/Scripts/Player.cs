using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a temp script to emulate the UI gameplay code - need to integrate with the tower/UI
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Header("Ember Attack")]
    public EmberFire bullet;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("FireWeapon"))
            {   // make a copy of bullet at position of firePoint (
            Instantiate(bullet, firePoint.position, firePoint.rotation).moveDirection = new Vector2(transform.localScale.x, transform.localScale.y);
        }
    }

   
}


