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

        #region PointsCollected
        private void SubscribePointsCollected()
        {
            foreach (IPointsCollected subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IPointsCollected>())
            {
                OnPointsCollected += subscriber.OnPointsCollected;
            }
        }

        public event Action<int> OnPointsCollected;
        public void PointsCollected(int value)
        {
            OnPointsCollected?.Invoke(value);
        }
        #endregion

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
