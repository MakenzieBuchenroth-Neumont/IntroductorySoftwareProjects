using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] private TowerTargeting towerIAmFrom;
    [SerializeField] private StatusEffect effect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieLater());
    }

    public void SetTowerFrom(TowerTargeting towerfrom)
    {
        towerIAmFrom = towerfrom;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * 5 * Time.deltaTime);
    }

    IEnumerator DieLater()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.collider.tag == "bad_guy") 
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.damage, towerIAmFrom);
            Debug.Log(effect);
            if (effect != null)
            {
                collision.gameObject.GetComponent<Enemy>().AddStatus(effect);
                effect.towerICameFrom = towerIAmFrom;
            }
            Destroy(this.gameObject);
        }
    }
}
