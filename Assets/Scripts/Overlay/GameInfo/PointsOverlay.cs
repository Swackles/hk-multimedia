using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EventSystems;

namespace Assets.Scripts.Overlay.GameInfo
{

    [RequireComponent(typeof(Text))]
    class PointsOverlay : MonoBehaviour, IPointsCollected
    {
        private int _points = 0;
        [Tooltip("The string that goes before the points")]
        [SerializeField] private string _prefix = "";
        [Tooltip("The string that goes after the points")]
        [SerializeField] private string _suffix = "";
        private Text _text;

        public static PointsOverlay Current;

        public int Points { get { return _points; } }

        public void Awake()
        {
            _points = GameState.GlobalState.Instance.GameScore;

            Current = this;
            _text = GetComponent<Text>();
            PlayerPrefs.SetInt ("final_score", 0);
            UpdatePoints();
        }

        public void OnPointsCollected(int points)
        {
            _points += points;
            PlayerPrefs.SetInt ("final_score", _points);
            UpdatePoints();
        }

        public void UpdatePoints() { _text.text = _prefix + _points.ToString() + _suffix; }
    }
}
