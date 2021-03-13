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
        public int health = 3;
        public int maxHealth = 3;

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
                    Enemy enemyBumpPower = collisionEnemy.gameObject.GetComponent<Enemy>();
                    if (sr.flipX) 
                        {
                            rb.velocity = Vector2.right * enemyBumpPower.enemyBumpPowerX;
                        } else {
                            rb.velocity = Vector2.left * enemyBumpPower.enemyBumpPowerX;
                        }
                    if (health > 1) 
                        {
                            health = health - 1;
                    } else
                        {
                            rb.transform.position = new Vector2(Input.GetAxis("Horizontal"), 0);
                            rb.velocity = Vector2.zero;
                            health = maxHealth;
                        }
                }
            }
    }
}

