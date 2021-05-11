using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private bool _mute;

        public void SoundToggle()
        {
            _mute = !_mute;
            AudioListener.pause = _mute;
        }
    }
}
