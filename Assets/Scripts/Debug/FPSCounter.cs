using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Debug
{
    [RequireComponent(typeof(Text))]
    class FPSCounter : MonoBehaviour
    {
        private Text _Text;
        public void Awake()
        {
            _Text = GetComponent<Text>();
        }
        public void Update()
        {
            
            float frames = Time.frameCount / Time.time;

            _Text.text = "FPS: " + ((int)frames).ToString();
        }
    }
}
