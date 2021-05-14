using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Overlay
{
    public class FinalScore : MonoBehaviour
    {
        private Text _text;
        public void Results()
        {
            _text = GetComponent<Text>();
            _text.text = "Final score: " + FindObjectOfType<PointsOverlay>()._points.ToString();
        }

    }
}
