using Assets.Scripts.AudioPlayer;
using UnityEngine;

namespace Assets.Scripts.Collectible
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AbstractCollectible : MonoBehaviour
    {
        [SerializeField] private CollectiblesAudioPlayer _audio;

        public void Collect() {
            _audio.Play(_audio.Collect);
        }
    }
}
