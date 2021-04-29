using Assets.Scripts.EventSystems;
using UnityEngine;

namespace Assets.Scripts.Collectible
{
    public class Vaccine : AbstractCollectible
    {
        [Tooltip("The time length in ms the effect will take")]
        [SerializeField] private int TimerLength = 5000;
        
        public new void Collect()
        {
            base.Collect();

            gameObject.SetActive(false);
            EventSystem.Current.VaccineCollected(TimerLength);
        }
    }
}
