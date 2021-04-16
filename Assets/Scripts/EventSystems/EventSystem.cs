using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.EventSystems
{
    public class EventSystem : MonoBehaviour
    {
        public static EventSystem Current;

        private void Awake()
        {
            Current = this;
            SubscribeMedicine();
        }

        #region Medicine
        private void SubscribeMedicine()
        {
            foreach (IMedicineCollectedHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IMedicineCollectedHandler>())
            {
                OnMedicineCollected += subscriber.OnMedicineCollected;
            }
        }

        public event Action<int> OnMedicineCollected;
        public void MedicineCollected(int timer)
        {
            OnMedicineCollected?.Invoke(timer);
        }
        #endregion
    }
}
