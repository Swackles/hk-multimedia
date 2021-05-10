using UnityEngine;

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
    }
}
