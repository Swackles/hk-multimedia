using Assets.Scripts.AudioPlayer;
using UnityEngine;

namespace Assets.Scripts.Collectible
{
    public abstract class AbstractCollectible : MonoBehaviour
    {
        [SerializeField] private CollectiblesAudioPlayer _audio;

        public void Awake()
        {
            _audio.Source = GetComponent<AudioSource>();
        }

        public virtual void Collect()
        {
            _audio.Play(_audio.Collect);
            gameObject.SetActive(false);
        }
    }
}
