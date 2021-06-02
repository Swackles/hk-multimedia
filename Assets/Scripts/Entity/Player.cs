using UnityEngine;
using Assets.Scripts.Collectible;
using Assets.Scripts.EventSystems;
using Assets.Scripts.AudioPlayer;
using System;
using System.Collections;
using QFSW.QC;

namespace Assets.Scripts.Entity
{
    
    [CommandPrefix("Entity.Player.")]
    [RequireComponent(typeof(AudioSource))]
    public class Player : AbstractEntity
    {
        [SerializeField] private Vector2 _maxVelocity = new Vector2(22, 22);
        
        private float _flashDuration = 0.2f;
        private int _flashRepeat = 5;
        
        public float JumpVelocity = 100f;
        public static Player Current;

        [NonSerialized] public int Health = 3;

        [SerializeField] private int _maxHealth = 3;
        private Vector2 _spawnPoint;

        [SerializeField] private PlayerAudioPlayer _audio;

        private QuantumConsole _console;

        /// <summary>
        /// If true the user will not be able to control the player
        /// </summary>
        private bool _controlsDisabled = false;
        
        private CapsuleCollider2D _collider;

        /// <summary>
        /// Checks if player is on the ground
        /// </summary>
        public bool IsGrounded { get {
            return Physics2D.Raycast(transform.position, Vector2.down, _collider.bounds.extents.y + 0.1f, LayerMask.GetMask("Default"));
        } }

        new public void Start()
        {
            base.Start();
            Current = this;

            _spawnPoint = transform.position;

            _collider = GetComponent<CapsuleCollider2D>();
            _audio.Source = GetComponent<AudioSource>();
            _console = FindObjectOfType<QuantumConsole>();
            
            _console.OnActivate += () => { _controlsDisabled = true; }; // Disable player controls when console gets activated
            _console.OnDeactivate += () => { _controlsDisabled = false; }; // Enable player controls when console gets closed
        }

        public void GameFinished()
        {
            gameObject.SetActive(false);
        }

        public void FixedUpdate()
        {

            if (!_controlsDisabled)

            // Fixes issue with player collider colliding with the gaps in tiles
            if (IsGrounded)
                RB.velocity = Vector2.right * RB.velocity;

            Movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            /**
             * ##### Why GetButton got replaced with GetKey #####
             * For some reason GetButton is unreliable and won't always register the key pressed
             */
            if (Input.GetKey(KeyCode.Space) && IsGrounded)

            {
                Movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
                /**
                 * ##### Why GetButton got replaced with GetKey #####
                 * For some reason GetButton is unreliable and won't always register the key pressed
                 */
                if (Input.GetKey(KeyCode.Space) && RB.velocity.y == 0)
                {
                    RB.velocity = Vector2.up * JumpVelocity;
                    _audio.Play(_audio.Jump);
                }
            }

            if (RB.velocity.x > _maxVelocity.x)
                RB.velocity = new Vector2(_maxVelocity.x, RB.velocity.y);
            else if (RB.velocity.x < _maxVelocity.x * -1)
                RB.velocity = new Vector2(_maxVelocity.x * -1, RB.velocity.y);

            #region Animator Logic

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

            #endregion
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out AbstractCollectible Collectible))
                Collectible.Collect();
        }

        [Command("Hurt")]
        public void Hurt(Vector2 KnockBack) 
        {
            StartCoroutine(FlashPlayer());
            _audio.Play(_audio.Hurt);
            int oldHealth = Health;

            Health--;

            EventSystem.Current.PlayerHurt(oldHealth, Health);

            if (Health < 1) {
                Kill();
            } else 
                RB.AddForce(KnockBack);
        }

        public void OnStep()
        {
            _audio.Play(_audio.Walking);
        }

        [Command("Kill")]
        public void Kill()
        {
            transform.position = _spawnPoint;
            Health = _maxHealth;
            EventSystem.Current.PlayerDeath(this);
        }
        public IEnumerator FlashPlayer()
        {
            for (int i = 0; i < _flashRepeat; i++)
                {
                SR.color = Color.red;
                yield return new WaitForSeconds(_flashDuration);
                SR.color = Color.white;
                yield return new WaitForSeconds(_flashDuration);
                }
        }
    }
}
