using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    class Enemy : MonoBehaviour
    {
        private Vector2 knockback;
        private float hitPower = 100f;
        void OnCollisionEnter2D(Collision2D collidedWith) {
            if (collidedWith.gameObject.CompareTag("Player")) {
                knockback = collidedWith.gameObject.transform.position - transform.position;
                GameObject playerObj = GameObject.Find("Player");
                playerObj.GetComponent<Rigidbody2D>().AddForce(knockback * hitPower);
                Player.isHurt = true;
            }
        }
    }
}