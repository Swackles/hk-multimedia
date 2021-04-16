using UnityEngine;
using Assets.Scripts.Collectible;
using Assets.Scripts.EventSystems;
using System;
using QFSW.QC;

namespace Assets.Scripts.Entity
{
    [CommandPrefix("Entity.Player.")]
    public class Player : AbstractEntity
    {
        public float JumpVelocity = 100f;
        public static Player Current;

        [NonSerialized] public int Health = 3;

        [SerializeField] public int _maxHealth = 3;
        private Vector2 _spawnPoint = new Vector2(0,0);

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
            if (Input.GetKey(KeyCode.Space) && RB.velocity.y == 0)
                RB.velocity = Vector2.up * JumpVelocity;

            base.FixedUpdate();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            AbstractCollectible Collectible;

            if (other.TryGetComponent(out Collectible))
                Collectible.Handle();
        }

        public void Hurt(Vector2 KnockBack) 
        {
            Health--;
            if (Health < 1) {
                Kill();
            } else 
                RB.AddForce(KnockBack);
        }

        [Command("Kill")]
        public void Kill()
        {
            EventSystem.Current.PlayerDeath(this);
            transform.position = _spawnPoint;
            Health = _maxHealth;
        }
    }
}

