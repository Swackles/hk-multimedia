﻿using UnityEngine;

namespace Assets.Scripts.Collectible
{
    abstract class AbstractCollectible : MonoBehaviour
    {
        public abstract void OnCollected();

        public abstract void OnMissed();

        public void Handle(bool collected = true)
        {
            gameObject.SetActive(false);

            if (collected)
                OnCollected();
            else
                OnMissed();
        }
    }
}