using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Overlay
{
    public class FinalScore : MonoBehaviour
    {
        private Text _text;
        private int _finalScore;

        private void Start()
        {
            Results();
        }
        public void Results()
        {
            _text = GetComponent<Text>();
            _finalScore = PlayerPrefs.GetInt ("final_score");
            _text.text = "Final score: " + _finalScore.ToString();
        }

    }
}
