using System;
using UnityEngine;

namespace Assets.Scripts.AudioPlayer
{
    public abstract class AbstractAudioPlayer
    {
        [NonSerialized] public AudioSource Source;

        /// <summary>
        /// Plays the specified audio clip
        /// </summary>
        /// <param name="clip">clip to be played</param>
        public void Play(AudioClip clip)
        {
            Source.clip = clip;
            Source.Play();
        }
    }
}
