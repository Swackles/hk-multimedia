//_patrolPoints from a prefab must be assigned to Grannys array before patrolling can work.

using UnityEngine;
using System.Timers;

namespace Assets.Scripts.Entity
{
    public class Granny : Enemy
    {
        [SerializeField] private Transform[] _patrolPoints;
        [Tooltip("The amount of time grandma will guard for")]
        [SerializeField] private double _guardFor;

        private int _randomPoint;
        private bool _guarding = false;
        private Timer _guardingTimer = new Timer();

        // Returns the current patrol point
        public Vector2 PatrolPoint {
            get { return new Vector2(_patrolPoints[_randomPoint].position.x, transform.position.y); }
        }
        
        //Granny selects a random patrol point from the array. Consecutive selections of the same point are avoided.
        new private void Start()
        {
            base.Start();

            SetPatrolPoint();
        }

        //Animation, flip, timing and movement from point to point.
        private void FixedUpdate()
        {
            if (_guarding && !_guardingTimer.Enabled)
                EndGuard();
            else if (!_guarding)
            {
                transform.position = Vector2.MoveTowards(transform.position, PatrolPoint, Speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, PatrolPoint) < 0.2f)
                    StartGuard();
            }
        }

        public void StartGuard()
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Patrolling", false);

            _guardingTimer = new Timer(_guardFor);
            _guardingTimer.AutoReset = false;
            _guardingTimer.Start();

            _guarding = true;
        }

        public void EndGuard()
        {
            Animator.SetBool("Patrolling", true);
            Animator.SetBool("Idle", false);

            SetPatrolPoint();

            SR.flipX = PatrolPoint.x < transform.position.x;

            _guarding = false;
        }

        private void SetPatrolPoint()
        {
            while (Vector2.Distance(transform.position, PatrolPoint) < 0.2f)
                _randomPoint = Random.Range(0, _patrolPoints.Length);
        }
    }
}
