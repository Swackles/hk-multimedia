using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Menu
{
    public class VolumeControl : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void SetVolumeTo(float volume)
        {
            audioMixer.SetFloat("Volume", volume);
        }
    }
}
