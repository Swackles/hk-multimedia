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

        #region PlayerHurt
        private void SubscribePlayerHurt()
        {
            foreach (IPlayerHurtHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IPlayerHurtHandler>())
            {
                OnPlayerHurt += subscriber.OnPlayerHurt;
            }
        }

        public event Action<int, int> OnPlayerHurt;
        public void PlayerHurt(int oldHealth, int newHealth)
        {
            OnPlayerHurt?.Invoke(oldHealth, newHealth);
        }

        #endregion

        #region Medicine
        private void SubscribeMedicine()
        {
            foreach (IMedicineCollectedHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IMedicineCollectedHandler>())
            {
                OnMedicineCollected += subscriber.OnMedicineCollected;
            }

            foreach (IMedicineMissedHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IMedicineMissedHandler>())
            {
                OnMedicineMissed += subscriber.OnMedicineMissed;
            }
        }

        public event Action OnMedicineCollected;
        public void MedicineCollected()
        {
            if (OnMedicineCollected != null)
                OnMedicineCollected();
        }

        public event Action OnMedicineMissed;
        public void MedicineMissed()
        {
            if (OnMedicineMissed != null)
                OnMedicineMissed();
        }
        #endregion
    }
}
