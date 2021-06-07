using UnityEngine;

namespace Assets.Scripts
{
    class Parrallax : MonoBehaviour
    {
        private float _length, _startPos;
        [SerializeField] private GameObject _mainCamera;
        [SerializeField] private float _parallaxEffect;

        private void Start()
        {
            _startPos = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            float temp = _mainCamera.transform.position.x * (1 - _parallaxEffect);
            float dist = _mainCamera.transform.position.x * _parallaxEffect;

            transform.position = new Vector3(_startPos + dist, transform.position.y, transform.position.z);

            if (temp > _startPos + _length) _startPos += _length;
            else if (temp < _startPos - _length) _startPos -= _length;
        }
    }
}
