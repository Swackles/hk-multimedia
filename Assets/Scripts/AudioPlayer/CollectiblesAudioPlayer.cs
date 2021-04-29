using System;
using UnityEngine;

namespace Assets.Scripts.AudioPlayer
{
    [Serializable]
    class CollectiblesAudioPlayer : AbstractAudioPlayer
    {
        public AudioClip Collect;

        /// <summary>
        /// Plays the specified audio clip
        /// </summary>
        /// <param name="clip">clip to be played</param>
        public new void Play(AudioClip clip)
        {
            GlobalAudioPlayer.Current.Play(clip);
        }
    }
}
