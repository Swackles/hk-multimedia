using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {

        public int collectible;
        public Text counter;
        [SerializeField] private LayerMask m_WhatIsGround;
	    [SerializeField] private Transform m_GroundCheck;
        [SerializeField] private float m_JumpForce = 400f;
        const float k_GroundedRadius = .2f; 
	    private bool m_Grounded;
        public UnityEvent OnLandEvent;
        [System.Serializable]
	    public class BoolEvent : UnityEvent<bool> { }
        bool jump = false;
        

        private void Awake()
        {

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();
        }

        new public void Start() {
            base.Start();
            changeCounter();

        }

        new public void FixedUpdate() {
            base.FixedUpdate();
            bool wasGrounded = m_Grounded;
		    m_Grounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }

        public void OnLanding () {
            _Animator.SetBool("Jumping", false);
        }

        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);

            if (Input.GetButtonDown("Jump")) {
                jump = true;
                _Animator.SetBool("Jumping", true);
                rb.AddForce(new Vector2(0f, m_JumpForce));
            }
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

