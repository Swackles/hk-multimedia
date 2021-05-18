using UnityEngine;
using Assets.Scripts.EventSystems;
using Assets.Scripts.Entity;

namespace Assets.Scripts.Overlay.GameInfo
{
    public class GameInfoOverlayContainer : MonoBehaviour, IPlayerDeathHandler
    {
        public void OnPlayerDeath(Player player) { gameObject.SetActive(false); }
    }

}
