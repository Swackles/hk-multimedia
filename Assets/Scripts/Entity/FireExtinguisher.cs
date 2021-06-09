using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Entity
{

    public class FireExtinguisher : AbstractEntity
    {
        public float HitPower = 100f;
        public ParticleSystem part;
        public List<ParticleCollisionEvent> collisionEvents;
        private int wait = 1;

        new void Start()
        {
            part = GetComponent<ParticleSystem>();
            collisionEvents = new List<ParticleCollisionEvent>();
        }
        
        IEnumerator waiter()
        {
            yield return new WaitForSeconds(2);
            wait = 1;
        }

        void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (numCollisionEvents > 0)
            {
                if (rb)
                {
                    if (wait == 1)
                    {
                    Vector2 KnockBack = other.gameObject.transform.position - transform.position;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Hurt(KnockBack * HitPower);
                    wait = 0;
                    StartCoroutine(waiter());
                    }
                }
            }
        }
    }
}