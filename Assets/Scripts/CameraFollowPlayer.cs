using UnityEngine;

namespace Assets.Scripts
{
    class CameraFollowPlayer : MonoBehaviour
    {
        public GameObject Player;
        public void Start()
        {
            gameObject.transform.position = Player.transform.position;
        }
        public void Update()
        {
            float playerX = Player.transform.position.x;
            Vector3 newPos = transform.position;

            newPos.y = Player.transform.position.y;

            // Check if following x is larger than camera x;
            if (playerX > transform.position.x)
                newPos.x = playerX;

            transform.position = newPos;
        }
    }
}
