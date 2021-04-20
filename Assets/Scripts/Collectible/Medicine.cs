using Assets.Scripts.EventSystems;
using UnityEngine;

namespace Assets.Scripts.Collectible
{
    public class Medicine : AbstractCollectible
    {
        [Tooltip("The time length in ms the effect will take")]
        [SerializeField] private int TimerLength = 5000;
        
        public override void Collect()
        {
            gameObject.SetActive(false);
            EventSystem.Current.MedicineCollected(TimerLength);
        }
    }
}
