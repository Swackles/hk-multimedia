using UnityEngine;
using Assets.Scripts.Collectible;
using Assets.Scripts.EventSystems;
using Assets.Scripts.AudioPlayer;
using System;
using QFSW.QC;

namespace Assets.Scripts.Entity
{

    [CommandPrefix("Entity.Player.")]
    [RequireComponent(typeof(AudioSource))]
    public class Player : AbstractEntity
    {
        public float JumpVelocity = 100f;
        public static Player Current;

        [NonSerialized] public int Health = 3;

        [SerializeField] private int _maxHealth = 3;
        private Vector2 _spawnPoint = new Vector2(0, 0);

        [SerializeField] private PlayerAudioPlayer _audio;

        new public void Start()
        {
            base.Start();
            Current = this;

            _audio.Source = GetComponent<AudioSource>();
        }

        new public void FixedUpdate()
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

            base.FixedUpdate();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out AbstractCollectible Collectible))
                Collectible.Collect();
        }

        [Command("Hurt")]
        public void Hurt(Vector2 KnockBack) 
        {
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
            EventSystem.Current.PlayerDeath(this);
            transform.position = _spawnPoint;
            Health = _maxHealth;
        }
    }
}

