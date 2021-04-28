using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Enemy : AbstractEntity
    {
        public float HitPower = 100f;

        new private void FixedUpdate(){ }

        public void OnCollisionEnter2D(Collision2D collidedWith) {
            if (collidedWith.gameObject.CompareTag("Player")) {
                Vector2 KnockBack = collidedWith.gameObject.transform.position - transform.position;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Hurt(KnockBack * HitPower);
            }
        }
    }
}
