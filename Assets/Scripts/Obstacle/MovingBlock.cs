using UnityEngine;

namespace Assets.Scripts.Obstacle
{
    class MovingBlock : MonoBehaviour
    {
        [SerializeField] Vector2 _moveBy;
        internal Vector3 _originalPos;
        internal bool _moveToPos = true;
        public Vector3 TargetPos { get { return _moveToPos ? _originalPos + (Vector3)_moveBy : _originalPos; } }

        [SerializeField] internal float _speed;

        [SerializeField] internal float _cooldown;
        internal float _cooldownTimer;
        public bool Cooldown { get { return _cooldownTimer > 0; } }


        internal void Start()
        {
            _originalPos = transform.position;
        }

        internal void Update()
        {

            if (Cooldown)
                _cooldownTimer -= Time.deltaTime;
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPos, _speed * Time.deltaTime);

                if (transform.position == TargetPos)
                {
                    _moveToPos = !_moveToPos;
                    _cooldownTimer = _cooldown;
                }
            }
        }

        internal void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_moveBy);
        }
    }
}
