using UnityEngine.SceneManagement;
using QFSW.QC;

namespace Assets.Scripts
{
    [CommandPrefix("SceneLoader.")]
    public static class SceneLoader
    {
        public static void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        [Command]
        public static void SampleScene() { LoadScene("SampleScene"); }

        [Command]
        public static void MainMenu() { LoadScene("MainMenu"); }

        [Command]
        public static void FinishMenu() { LoadScene("FinishMenu"); }

        [Command]
        public static void GameOverMenu() { LoadScene("GameOverMenu"); }

        [Command]
        public static void LevelOne() { LoadScene("Level_1"); }

        [Command]
        public static void LevelTwo() { LoadScene("Level_2"); }

        [Command]
        public static void ReloadScene() { LoadScene(SceneManager.GetActiveScene().name); }
    }
}
