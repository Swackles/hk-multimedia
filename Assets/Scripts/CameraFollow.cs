using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _following;

        public void Start()
        {
            gameObject.transform.position = _following.transform.position;
        }

        public void Update()
        {
            float followingX = _following.transform.position.x;

            // Check if following x is larger than camera x;
            if (followingX > transform.position.x)
            {
                Vector3 newPos = transform.position;
                newPos.x = followingX;

                transform.position = newPos;
            }
        }
    }
}
