using System;
using UnityEngine;

namespace Assets.Scripts.AudioPlayer
{
    [Serializable]
    public class VirusAudioPlayer : AbstractAudioPlayer
    {
        public AudioClip Attack;
        public AudioClip AttackCooldownReset;
    }
}
