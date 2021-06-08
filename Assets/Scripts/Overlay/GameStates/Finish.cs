using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Overlay.GameInfo;

namespace Assets.Scripts.Overlay.GameStates
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Text _pointsTextField;

        public void Awake()
        {
            gameObject.SetActive(false);
        }

        public void MainMenu() 
        {
            PlayerPrefs.SetInt ("final_score", 0);
            SceneLoader.MainMenu(); 
        }

        public void Replay() 
        { 
            PlayerPrefs.SetInt ("final_score", 0);
            SceneLoader.LevelOne(); 
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _pointsTextField.text = "Final score: " + PointsOverlay.Current.Points;
        }
    }
}