using UnityEngine;
using Assets.Scripts.Collectible;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {
        public float JumpVelocity = 100f;

        new public void Start()
        {
            base.Start();
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
    }
}

