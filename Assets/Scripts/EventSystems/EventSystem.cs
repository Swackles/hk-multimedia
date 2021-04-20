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
            SubscribePlayerHurt();
            SubscribeVaccine();
            SubscribePointsCollected();
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

        #region Vaccine
        private void SubscribeVaccine()
        {
            foreach (IVaccineCollectedHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IVaccineCollectedHandler>())
            {
                OnVaccineCollected += subscriber.OnVaccineCollected;
            }
        }

        public event Action<int> OnVaccineCollected;
        public void VaccineCollected(int timer)
        {
            OnVaccineCollected?.Invoke(timer);
        }
        #endregion
    }
}
