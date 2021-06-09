using UnityEngine;
using Assets.Scripts.EventSystems;

namespace Assets.Scripts.AudioPlayer
{
    [RequireComponent(typeof(AudioSource))]
    class GlobalAudioPlayer : MonoBehaviour, IGameFinished, IPlayerDeathHandler
    {
        public static GlobalAudioPlayer Current;
        [SerializeField] private AudioSource _source, _backgroundMusic;
        [SerializeField] private AudioClip _gameOver, _gameWin;

        public void Awake() { Current = this; }

        /// <summary>
        /// Plays the specified audio clip in global audio player
        /// </summary>
        /// <param name="clip">clip to be played</param>
        public void Play(AudioClip clip)
        {
            _source.clip = clip;
            _source.Play();
        }

        public void OnGameFinished()
        {
            _backgroundMusic.Pause();
            Play(_gameWin);
        }

        public void OnPlayerDeath(Entity.Player player)
        {
            _backgroundMusic.Pause();
            Play(_gameOver);
        }
    }
}
