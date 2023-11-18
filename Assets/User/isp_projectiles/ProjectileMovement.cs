using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


namespace isp_projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {
        public int  initialSpeed = 1;
        public int  acceleration = 15;
        public ParticleSystem smokeEffect;

        private float currentSpeed; 
        private bool smokeStart = false;
        void Start()
        {
            currentSpeed = initialSpeed;

            Debug.Log("Current speed: " + currentSpeed);
        }

    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
        Debug.Log("Current speed: " + currentSpeed);

            if(!smokeStart && currentSpeed > 0)
            {
                smokeEffect.Play();
                smokeStart = true;

            }

        }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
            {
                Debug.Log("Current speed: " + currentSpeed);

                Debug.Log("Direct Hit!");

                Destroy(gameObject);
        }
    }

}
}

