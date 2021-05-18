using UnityEngine;
using Assets.Scripts.Entity;
using Assets.Scripts.EventSystems;

namespace Assets.Scripts.Overlay.GameStates
{
    class GameStatesOverlayContainer : MonoBehaviour, IPlayerDeathHandler
    {
        [SerializeField] private GameOver _gameOver;
        public void OnPlayerDeath(Player player) { _gameOver.Show(); }
    }
}
