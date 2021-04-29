using System;
using UnityEngine;

namespace Assets.Scripts.AudioPlayer
{
    [Serializable]
    public class PlayerAudioPlayer : AbstractAudioPlayer
    {
        public AudioClip Walking;
        public AudioClip Hurt;
        public AudioClip Jump;
    }
}
