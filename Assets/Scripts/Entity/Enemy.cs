using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    class Enemy : MonoBehaviour
    {
        public static Vector2 knockback;
        public static float hitPower = 100f;

        void OnCollisionEnter2D(Collision2D collidedWith) {
            if (collidedWith.gameObject.CompareTag("Player")) {
                knockback = collidedWith.gameObject.transform.position - transform.position;
                Player p;
                p=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                p.hurt();
            }
        }
    }
}