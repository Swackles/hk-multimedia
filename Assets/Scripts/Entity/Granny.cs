//_patrolPoints from a prefab must be assigned to Grannys array before patrolling can work.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

namespace Assets.Scripts.Entity
{
    public class Granny : Enemy
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private double _guardFor;
        private int _randomPoint;
        private static System.Timers.Timer _guardTimer;
        private int _guardTime = 1;
        
        //Granny selects a random patrol point from the array. Consecutive selections of the same point are avoided.
        new private void Start()
        {
            base.Start();
            _guardTimer = new System.Timers.Timer(_guardFor);
            _guardTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => _guardTime = 0;
            _randomPoint = Random.Range(0, _patrolPoints.Length);
        }
        //Overwrite base of abstractentity.
        new private void FixedUpdate(){ }

        //Animation, flip, timing and movement from point to point.
        private void Update()
        {   
            transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_randomPoint].position, Speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, _patrolPoints[_randomPoint].position) < 0.2f){
                if(_guardTime <= 0){
                    _guardTimer.Interval = _guardFor;
                    _randomPoint = Random.Range(0, _patrolPoints.Length);
                    while(_patrolPoints[_randomPoint].position.x == transform.position.x){
                        _randomPoint = Random.Range(0, _patrolPoints.Length);
                    }
                    _guardTime = 1;
                    SR.flipX = _patrolPoints[_randomPoint].position.x < transform.position.x;
                    Animator.SetBool("Patrolling", true);
                    Animator.SetBool("Idle", false);
                } else {
                    Animator.SetBool("Idle", true);
                    Animator.SetBool("Patrolling", false);
                    _guardTimer.Start();
                }
            }
        }
    }
}
