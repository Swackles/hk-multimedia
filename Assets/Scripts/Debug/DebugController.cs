using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.Debug
{
    [DisallowMultipleComponent]
    class DebugController : MonoBehaviour
    {
        [SerializeField] private bool ActivateOnStartup = true;
        [SerializeField] private KeyCode Key = KeyCode.F2;
        private GameObject DebugGrid;

        public void Start()
        {
            DebugGrid = GetComponentInChildren<GridLayoutGroup>().gameObject;

            DebugGrid.SetActive(ActivateOnStartup);
        }

        public void Update()
        {
            if (Input.GetKeyDown(Key))
                DebugGrid.SetActive(!DebugGrid.activeSelf);
        }
    }
}
