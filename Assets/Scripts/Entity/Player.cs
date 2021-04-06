using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Collectible;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {
        public float JumpVelocity = 100f;
        public static Player Current;

        private int Collectible;
        public Text Counter;
        private int Health = 3;
        public int MaxHealth = 3;
        private Vector2 SpawnPoint = new Vector2(0,0);
        
        new public void Start()
        {
            base.Start();
            Current = this;
        }

        new public void FixedUpdate()
        {
            Movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            /**
             * ##### Why GetButton got replaced with GetKey #####
             * For some reason GetButton is unreliable and won't always register the key pressed
             */
            if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0)
                rb.velocity = Vector2.up * JumpVelocity;

            base.FixedUpdate();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            AbstractCollectible Collectible;

            if (other.TryGetComponent(out Collectible))
                Collectible.Handle();
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