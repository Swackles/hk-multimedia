using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManagement : MonoBehaviour
    {
        public void BackToMainMenu()
        {
            SceneLoader.LoadScene("MainMenu");
        }

        public void Replay()
        {
            SceneLoader.LoadScene("SampleScene");
        }

        public void GameDeath()
        {
            Debug.Log("Game over!");
        }
    }
}
