using System;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Entity;

namespace Assets.Scripts.EventSystems
{
    public class EventSystem : MonoBehaviour
    {
        public static EventSystem Current;

        private void Awake()
        {
            Current = this;
            SubscribeMedicine();
            SubscribeDeath();
        }

        #region Death
        private void SubscribeDeath()
        {
            foreach (IPlayerDeathHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IPlayerDeathHandler>())
            {
                OnDeath += subscriber.OnPlayerDeath;
            }
        }

        public event Action<Player> OnDeath;
        public void PlayerDeath(Player player)
        {
            OnDeath?.Invoke(player);
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
