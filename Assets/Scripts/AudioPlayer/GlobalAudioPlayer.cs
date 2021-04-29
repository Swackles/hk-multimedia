using UnityEngine;

namespace Assets.Scripts.AudioPlayer
{
    [RequireComponent(typeof(AudioSource))]
    class GlobalAudioPlayer : MonoBehaviour
    {
        public static GlobalAudioPlayer Current;
        private AudioSource Source;

        public void Awake()
        {
            Source = GetComponent<AudioSource>();
            
            Current = this;
        }

        /// <summary>
        /// Plays the specified audio clip in global audio player
        /// </summary>
        /// <param name="clip">clip to be played</param>
        public void Play(AudioClip clip)
        {
            Source.clip = clip;
            Source.Play();
        }
    }
}
