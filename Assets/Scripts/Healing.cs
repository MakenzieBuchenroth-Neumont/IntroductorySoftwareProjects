using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    [SerializeField] float stop_timer = 0.0f;
    [SerializeField] float go_timer = 0.0f;
    private bool moving;
    private int stop_count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "bad_guy")
        {
            collision.gameObject.GetComponent<Enemy>().GainHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.circleCollider.enabled = false;
        stop_timer += Time.deltaTime;

        if (stop_timer >= 6.0f)
        {
            StartCoroutine(Stop());
        }
    }

    public IEnumerator Stop()
    {
        this.gameObject.GetComponentInParent<Enemy>().speed = 0;
        this.circleCollider.enabled = true;
        stop_timer = 0;
        moving = false;
        yield return new WaitForSecondsRealtime(3);
        this.gameObject.GetComponentInParent<Enemy>().speed = this.gameObject.GetComponentInParent<Enemy>().max_speed;
    }


}
