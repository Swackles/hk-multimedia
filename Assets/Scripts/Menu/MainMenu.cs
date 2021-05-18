using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

        public void SoundToggle()
        {
            _mute = !_mute;
            AudioListener.pause = _mute;
        }
    }
}
