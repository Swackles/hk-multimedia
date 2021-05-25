using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        private bool _mute;

        public void StartGame()
        {
            SceneLoader.LevelOne();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void BackToMainMenu()
        {
            SceneLoader.MainMenu();
        }

        public void SoundToggle()
        {
            _mute = !_mute;
            AudioListener.pause = _mute;
        }
    }
}
