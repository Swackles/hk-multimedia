using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EventSystems;
using Assets.Scripts.Entity;

namespace Assets.Scripts.Overlay
{

    [RequireComponent(typeof(Text))]
    class PointsOverlay : MonoBehaviour, IPointsCollected, IPlayerDeathHandler
    {
        public int _points = 0;
        [Tooltip("The string that goes before the points")]
        [SerializeField] private string _prefix = "";
        [Tooltip("The string that goes after the points")]
        [SerializeField] private string _suffix = "";
        private Text _text;

        public void Awake()
        {
            _text = GetComponent<Text>();
            UpdatePoints();
        }

        public void OnPointsCollected(int points)
        {
            _points += points;
            UpdatePoints();
        }

        public void OnPlayerDeath(Player player)
        {
            FindObjectOfType<FinalScore>().Results();
            _points = 0;
            UpdatePoints();
        }

        public void UpdatePoints()
        {
            _text.text = _prefix + _points.ToString() + _suffix;
        }
    }
}
