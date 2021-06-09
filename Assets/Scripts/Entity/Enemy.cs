using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Enemy : AbstractEntity
    {
        public float HitPower = 100f;

        public void OnCollisionEnter2D(Collision2D collidedWith) {
            if (collidedWith.gameObject.CompareTag("Player")) {
                Vector2 KnockBack = collidedWith.gameObject.transform.position - transform.position;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Hurt(KnockBack.normalized * HitPower);
            }
        }
    }
}
