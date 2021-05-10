using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeTo(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
