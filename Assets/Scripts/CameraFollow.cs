using UnityEngine;

namespace Assets.Scripts
{
    class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject Following;

        public void Start()
        {
            gameObject.transform.position = Following.transform.position;
        }
        public void Update()
        {
            float followingX = Following.transform.position.x;

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
