using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    class Player : AbstractEntity
    {
        public void Update()
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0);
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
    }
}

