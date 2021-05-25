using UnityEngine;
using Assets.Scripts.EventSystems;
using Assets.Scripts.Entity;

namespace Assets.Scripts.Overlay.GameInfo
{
    public class GameInfoOverlayContainer : MonoBehaviour, IPlayerDeathHandler, IGameFinished
    {        
        public void OnPlayerDeath(Player player) { gameObject.SetActive(false); }
        public void OnGameFinished() { gameObject.SetActive(false); }
    }

}
