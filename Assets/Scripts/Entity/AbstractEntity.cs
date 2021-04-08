using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    public abstract class AbstractEntity : MonoBehaviour
    {
        public float Speed = 1f;

        protected Vector2 Movement;
        protected Vector2 Velocity;

        protected Rigidbody2D RB;
        protected Animator Animator;
        protected SpriteRenderer SR;

        // Start is called before the first frame update
        public void Start()
        {
            RB = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            SR = GetComponent<SpriteRenderer>();
        }

        public void FixedUpdate()
        {
            Movement = Movement * Speed;
            RB.velocity += Movement;

            Animator.SetFloat("Speed", Math.Abs(RB.velocity.x));

            Animator.SetBool("Falling", false);
            Animator.SetBool("Jumping", false);

            if (RB.velocity.y > 0.2f)
                Animator.SetBool("Jumping", true);
            else if (RB.velocity.y < -0.2f)
                Animator.SetBool("Falling", true);

            
            if (RB.velocity.x > 0.1f)
                SR.flipX = false;
            else if (RB.velocity.x < -0.1f)
                SR.flipX = true;
        }
    }
}
