using UnityEngine;
using System.Linq;
using Assets.Scripts.EventSystems;
using Assets.Scripts.Entity;

namespace Assets.Scripts.Overlay.GameInfo
{
    class HealthOverlay : MonoBehaviour, IPlayerHurtHandler, IPlayerDeathHandler
    {
        private RectTransform[] _hearts;

        public void Awake()
        {
            _hearts = GetComponentsInChildren<RectTransform>().ToList().FindAll(x => x.CompareTag("Health")).ToArray();
        }

        public void OnPlayerHurt(int oldHP, int newHP) {
            for (int i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].gameObject.SetActive(i < newHP);
            }
        }

        public void OnPlayerDeath(Player player)
        {
            OnPlayerHurt(0, player.Health);
        }
    }
}
