using UnityEngine;
using Assets.Scripts.Collectible;

namespace Assets.Scripts
{
    class MissedCollectiblesHandler : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(true);
            AbstractCollectible Collectible;

            if (other.TryGetComponent(out Collectible))
                Collectible.Handle(false);
        }
    }
}
