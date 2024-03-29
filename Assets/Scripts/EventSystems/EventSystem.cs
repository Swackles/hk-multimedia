﻿using System;
using System.Linq;
using UnityEngine;
using QFSW.QC;
using Assets.Scripts.Entity;

namespace Assets.Scripts.EventSystems
{
    [CommandPrefix("Trigger.")]
    public class EventSystem : MonoBehaviour
    {
        public static EventSystem Current;

        private void Awake()
        {
            Current = this;

            SubscribeGameFinished();
            SubscribePlayerHurt();
            SubscribeVaccine();
            SubscribePointsCollected();
            SubscribeDeath();
            LiftDoorEnter();
            LiftAnimationEnding();
            SubscribeGame();
        }
        #region GameFinished
        private void SubscribeGameFinished()
        {
            foreach (IGameFinished subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IGameFinished>())
            {
                OnGameFinished += subscriber.OnGameFinished;
            }
        }

        public event Action OnGameFinished;
        public void GameFinished()
        {
            OnGameFinished?.Invoke();
        }
        #endregion

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

        #region Vaccine
        private void SubscribeVaccine()
        {
            foreach (IVaccineCollectedHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IVaccineCollectedHandler>())
            {
                OnVaccineCollected += subscriber.OnVaccineCollected;
            }

            foreach(IVaccineEffectEndHandler subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IVaccineEffectEndHandler>())
            {
                OnVaccineEffectEnd += subscriber.OnVaccineEffectEnd;
            }
        }

        public event Action OnVaccineEffectEnd;
        public event Action<int> OnVaccineCollected;

        [Command("CollectVaccine", "Triggers the vaccine collected")]
        public void VaccineCollected(int timer)
        {
            OnVaccineCollected?.Invoke(timer);
        }

        public void VaccineEffectEnd()
        {
            OnVaccineEffectEnd?.Invoke();
        }
        #endregion

        #region Lift
        public event Action onLiftDoorEnter;
        public void LiftDoorEnter()
        {
            if (onLiftDoorEnter != null)
            {
                onLiftDoorEnter();
            }
        }

        public event Action onLiftAnimationEnding;
        public void LiftAnimationEnding()
        {
            onLiftAnimationEnding += onLiftAnimationEnding;
            if (onLiftAnimationEnding != null)
            {
                onLiftAnimationEnding();
            }
        }
        #endregion

        #region Game
        private void SubscribeGame()
        {
            foreach (IGameResumed subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IGameResumed>())
            {
                OnGameResumed += subscriber.OnGameResumed;
            }

            foreach (IGamePaused subscriber in FindObjectsOfType<MonoBehaviour>().OfType<IGamePaused>())
            {
                OnGamePaused += subscriber.OnGamePaused;
            }
        }

        public event Action OnGamePaused;
        public void GamePaused() { OnGamePaused?.Invoke(); }

        public event Action OnGameResumed;
        public void GameResumed() { OnGameResumed?.Invoke(); }
        #endregion
    }
}
