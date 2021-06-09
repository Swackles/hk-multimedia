using Assets.Scripts.EventSystems;
using UnityEngine;

namespace Assets.Scripts.Overlay
{
    class GamePausedMenu : MonoBehaviour, IGamePaused, IGameResumed
    {
        [SerializeField] private GameObject _container;

        public void Start()
        {
            _container.SetActive(false);
        }

        public void Continue() { Game.ResumeGame(); }
        public void MainMenu() { SceneLoader.MainMenu(); }
        public void Quit() { Application.Quit(); }

        public void OnGamePaused() { _container.SetActive(true); }

        public void OnGameResumed() { _container.SetActive(false); }
    }
}
