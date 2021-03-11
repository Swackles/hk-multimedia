using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    abstract class AbstractEntity : MonoBehaviour
    {
        [SerializeField]
        public float Speed = 1f;

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
        }

        public void FixedUpdate()
        {
            Movement = Movement * Speed;
            rb.velocity += Movement;

            _Animator.SetFloat("Speed", Math.Abs(rb.velocity.x));

            _Animator.SetBool("Falling", false);
            _Animator.SetBool("Jumping", false);

            if (rb.velocity.y > 0.2f)
                _Animator.SetBool("Jumping", true);
            else if (rb.velocity.y < -0.2f)
                _Animator.SetBool("Falling", true);

            
            if (rb.velocity.x > 0.1f)
                sr.flipX = false;
            else if (rb.velocity.x < -0.1f)
                sr.flipX = true;
        }
    }
}
