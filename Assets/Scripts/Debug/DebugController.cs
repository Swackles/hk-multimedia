using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DebugOverlay
{
    [DisallowMultipleComponent]
    public class DebugController : MonoBehaviour
    {
        [SerializeField] private bool _activateOnStartup = true;
        [SerializeField] private KeyCode _key = KeyCode.F2;
        private GameObject _debugGrid;

        public void Start()
        {
            _debugGrid = GetComponentInChildren<GridLayoutGroup>().gameObject;

            _debugGrid.SetActive(_activateOnStartup);
        }

        public void Update()
        {
            if (Input.GetKeyDown(_key))
                _debugGrid.SetActive(!_debugGrid.activeSelf);
        }
    }
}
