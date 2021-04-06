using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    class Enemy : MonoBehaviour
    {
        private float HitPower = 100f;

        void OnCollisionEnter2D(Collision2D collidedWith) {
            if (collidedWith.gameObject.CompareTag("Player")) {
                Vector2 KnockBack = collidedWith.gameObject.transform.position - transform.position;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().hurt(KnockBack * HitPower);
            }
        }
    }
}