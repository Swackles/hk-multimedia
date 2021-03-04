using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        public int collectible;
        public Text counter;
        public float JumpVelocity = 100f;

        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);

            if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
                rb.velocity = Vector2.up * JumpVelocity;
        }

        public void changeCounter() {
            counter.text = "Collectibles: " + collectible;
        }

    }
}

