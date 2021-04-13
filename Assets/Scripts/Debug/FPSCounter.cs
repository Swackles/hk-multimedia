using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DebugOverlay
{
    [RequireComponent(typeof(Text))]
    public class FPSCounter : MonoBehaviour
    {
        private Text _text;
        public void Awake()
        {
            _text = GetComponent<Text>();
        }
        public void Update()
        {
            
            float frames = Time.frameCount / Time.time;

            _text.text = "FPS: " + ((int)frames).ToString();
        }
    }
}
