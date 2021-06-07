using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using QFSW.QC;

namespace Assets.Scripts
{
    [CommandPrefix("SceneLoader.")]
    public static class SceneLoader
    {
        public static string CurrentSceneName { get { return SceneManager.GetActiveScene().name; } }
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
        public static void LevelTwo()
        {
            LoadScene("Level_2");
        }

        [Command]
        public static void NextLevel()
        {
            Regex reg = new Regex(@"Level_(\d+)");
            Match match = reg.Match(CurrentSceneName);
            string nextSceneName = "Level_" + (Int32.Parse(match.Groups[1].Value) + 1);

            if (match.Success && SceneManager.GetSceneByName(nextSceneName).IsValid())
            {
                GameState.GlobalState.Instance.GameScore = Overlay.GameInfo.PointsOverlay.Current.Points;

                LoadScene(nextSceneName);
            }
            else
                ReloadScene();
        }

        [Command]
        public static void ReloadScene() { LoadScene(CurrentSceneName); }
    }
}
