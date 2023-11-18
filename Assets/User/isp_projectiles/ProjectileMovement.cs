using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace isp_projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {
        public int initialSpeed = 1;
        public int acceleration = 15;
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
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
            Debug.Log("Current speed: " + currentSpeed);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("bad_guy"))
            {
                Debug.Log("Current speed: " + currentSpeed);

                Debug.Log("Direct Hit!");

                if (smokeEffect != null)
                {
                    GameObject particles = Instantiate(smokeEffect.gameObject, transform.position, Quaternion.identity);
                    particles.GetComponent<ParticleSystem>().Play();
                }

                Destroy(gameObject);
            }
        }

    }
}

