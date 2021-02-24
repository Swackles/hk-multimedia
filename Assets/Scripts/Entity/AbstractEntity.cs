using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    abstract class AbstractEntity : MonoBehaviour
    {
        [SerializeField]
        public float Speed = 1f;

        public int count;
        public Text collectible;

        protected Vector2 Movement;
        protected Vector2 Velocity;

        protected Rigidbody2D rb;
        protected Animator _Animator;
        protected SpriteRenderer sr;

        // Start is called before the first frame update
        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _Animator = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            count = 0;
            changeCounter();
        }

        public void FixedUpdate()
        {
            Movement = Movement * Speed;
            rb.velocity += Movement;

            if (rb.velocity.x != 0)
            {
                _Animator.SetBool("Moving", true);

                if (rb.velocity.x > 0)
                    sr.flipX = false;
                else
                    sr.flipX = true;
            } else
                _Animator.SetBool("Moving", false);

            if (rb.velocity.y < 0)
                _Animator.SetBool("Falling", true);
            else
                _Animator.SetBool("Falling", false);
        }
        public void OnTriggerEnter2D(Collider2D other) 
        {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Collectible"))
                {
                     other.gameObject.SetActive(false);
                     count = count + 1;
                     changeCounter();
                }
        }
        
        void changeCounter () {
            collectible.text = "Coins: " + count.ToString ();
        }
    }
    
}
