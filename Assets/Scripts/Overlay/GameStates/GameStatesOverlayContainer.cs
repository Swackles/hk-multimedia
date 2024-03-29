﻿using UnityEngine;
using Assets.Scripts.Entity;
using Assets.Scripts.EventSystems;

namespace Assets.Scripts.Overlay.GameStates
{
    class GameStatesOverlayContainer : MonoBehaviour, IPlayerDeathHandler, IGameFinished
    {
        [SerializeField] private GameOver _gameOver;
        [SerializeField] private Finish _finish;
        public void OnPlayerDeath(Player player) { _gameOver.Show(); }
        public void OnGameFinished() { _finish.Show(); }
    }
}