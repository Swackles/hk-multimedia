using Assets.Scripts.EventSystems;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Overlay.Modifiers
{
    class VaccineModifier : MonoBehaviour, IVaccineCollectedHandler
    {
        private ProgressBar _pb;

        private Stopwatch _stopwatch = new Stopwatch();
        private int _time;

        /// <summary>
        /// The amount of time elapsed
        /// </summary>
        public double? ElapsedTime { get => _stopwatch?.Elapsed.TotalMilliseconds; }
        /// <summary>
        /// The amount of time remaining
        /// </summary>
        public double? RemainingTime { get => _time - ElapsedTime; }

        public void Awake()
        {
            _pb = GetComponentInChildren<ProgressBar>();
            if (_pb == null)
                throw new MissingComponentException("Vaccine Modifier has to have a ProgressBar component in a child");

            _pb.gameObject.SetActive(false);
        }

        public void FixedUpdate()
        {
            if (_stopwatch.IsRunning && RemainingTime <= 0)
                StopStopwatch();
            else if (_stopwatch.IsRunning)
                _pb.UpdateProgress((float)(RemainingTime / _time));
        }

        public void OnVaccineCollected(int time)
        {
            if (!_stopwatch.IsRunning || RemainingTime < time)
                StartStopwatch(time);
        }

        private void StartStopwatch(int time)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _time = time;

            _pb.gameObject.SetActive(true);
        }

        private void StopStopwatch()
        {
            _stopwatch.Stop();
            _pb.gameObject.SetActive(false);

            EventSystem.Current.VaccineEffectEnd();
        }
    }
}
