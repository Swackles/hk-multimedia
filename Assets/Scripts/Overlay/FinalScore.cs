using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Overlay.GameInfo;

namespace Assets.Scripts.Overlay
{
    public class FinalScore : MonoBehaviour
    {
        private Text _text;
        public void Results()
        {
            _text = GetComponent<Text>();
            _text.text = "Final score: " + PointsOverlay.Current.Points.ToString();
        }

    }
}
