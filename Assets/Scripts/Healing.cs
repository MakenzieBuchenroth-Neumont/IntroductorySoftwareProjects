using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    [SerializeField] float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "bad_guy" )
        {
            collision.gameObject.GetComponentInParent<Enemy>().GainHealth();
        }
    }

    // Update is called once per frame
    async void Update()
    {
        this.circleCollider.enabled = false;
        timer += Time.deltaTime;
        if (timer >= 3.0f) 
        { 
            this.gameObject.GetComponentInParent<Enemy>().speed = 0;
            this.circleCollider.enabled = true;
            timer = 0.0f;
        }
        this.gameObject.GetComponentInParent<Enemy>().speed = this.gameObject.GetComponentInParent<Enemy>().max_speed;
    }
}
