using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 }
//    private void OnCollisionEnter2D(Collision2D collision) 
//    {
//    if (collision.collider.tag == "bad_guy")
//    {
//            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.damage);
//            Destroy(this.gameObject);
//        }
//    }
//}
