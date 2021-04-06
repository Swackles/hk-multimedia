using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        private int Collectible;
        public Text Counter;
        private int Health = 3;
        public int MaxHealth = 3;
        private Vector2 SpawnPoint = new Vector2(0,0);

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
                     Collectible++;
                     changeCounter();
                }
            
        }

        void changeCounter() {
            Counter.text = "Collectibles: " + Collectible;
        }

        public void hurt(Vector2 KnockBack) {
            Health--;
            if (Health < 1) {
                transform.position = SpawnPoint;
                Health = MaxHealth;
            } else 
                rb.AddForce(KnockBack);
        }  
    }
}