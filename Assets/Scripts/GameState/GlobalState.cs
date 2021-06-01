using UnityEngine;

namespace Assets.Scripts.GameState
{
    class GlobalState : MonoBehaviour
    {
        public static GlobalState Instance;
        public int GameScore = 0;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
