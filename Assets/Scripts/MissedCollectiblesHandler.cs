using UnityEngine;
using Assets.Scripts.Collectible;

namespace Assets.Scripts
{
    public class MissedCollectiblesHandler : MonoBehaviour
    {

        public void OnTriggerEnter2D(Collider2D other)
        {
            AbstractCollectible Collectible;

            if (other.TryGetComponent(out Collectible))
                Collectible.Handle(false);
        }
    }
}
