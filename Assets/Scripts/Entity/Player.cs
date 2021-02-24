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
    }
}

