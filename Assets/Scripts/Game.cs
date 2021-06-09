using UnityEngine;

namespace Assets.Scripts
{
    public static class Game
    {
        public static bool Paused { get; private set; } = false;

        public static void PauseGame()
        {
            Paused = true;
            Time.timeScale = 0;
            EventSystems.EventSystem.Current.GamePaused();
        }
        public static void ResumeGame()
        {
            Paused = false;
            Time.timeScale = 1;
            EventSystems.EventSystem.Current.GameResumed();
        }
    }
}
