using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _following;

        public void Update()
        {
            Vector3 newPos = _following.transform.position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
