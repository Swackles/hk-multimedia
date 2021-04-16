using UnityEngine;

namespace Assets.Scripts.Collectible
{
    public abstract class AbstractCollectible : MonoBehaviour
    {
        public abstract void OnCollected();

        public abstract void Collect();

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
