﻿using System;
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
            SubscribePointsCollected();
        }

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
