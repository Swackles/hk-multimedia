using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        private int collectible;
        public Text counter;
        private int health = 3;
        public int maxHealth = 3;
        private Vector2 spawnpoint = new Vector2(0,0);

        new public void Start() {
            base.Start();
            changeCounter();

        }
        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            changeCounter();
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
            counter.text = "Collectibles: " + health;
        }

        public void hurt() {
            health = health - 1;
            if (health < 1) {
                transform.position = spawnpoint;
                health = maxHealth;
            } else {
                GameObject playerObj = GameObject.Find("Player");
                playerObj.GetComponent<Rigidbody2D>().AddForce(Enemy.knockback * Enemy.hitPower);
            }
        }  
    }
}