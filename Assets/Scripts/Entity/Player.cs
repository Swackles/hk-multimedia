using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        public int collectible;
        public Text counter;
        public float enemyBumpPowerY = 10f;
        public float enemyBumpPowerX = 10f;
        public int health = 3;

        new public void Start() {
            base.Start();
            changeCounter();

        }
        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        }

        void OnTriggerEnter2D(Collider2D other) 
        {

            if (other.gameObject.CompareTag("Collectible"))
                {
                     other.gameObject.SetActive(false);
                     collectible = collectible + 1;
                     changeCounter();
                }
        }

        public void changeCounter() {
            counter.text = "Collectibles: " + collectible;
        }

        void OnCollisionEnter2D(Collision2D collisionEnemy)
            {
            if (collisionEnemy.gameObject.tag.Equals ("Enemy"))
                {
                    if (sr.flipX) 
                        {
                            rb.velocity = Vector2.right * enemyBumpPowerX;
                        } else {
                            rb.velocity = Vector2.left * enemyBumpPowerX;
                        }
                    if (health > 1) 
                        {
                            health = health - 1;
                    } else
                        {
                            rb.transform.position = new Vector2(Input.GetAxis("Horizontal"), 0);
                            health = 3;
                        }
                }
            }
    }
}

