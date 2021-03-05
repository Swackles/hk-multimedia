using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        public int collectible;
        public Text counter;
        public float JumpVelocity = 100f;
        new public void Start()
        {
            base.Start();
            changeCounter();

        }

        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);

            if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
                rb.velocity = Vector2.up * JumpVelocity;
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

    }
}

