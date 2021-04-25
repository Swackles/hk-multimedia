//Patrolpoints from a prefab must be assigned to Grannys array before patrolling can work.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Granny : AbstractEntity
    {
        private float guardTime;
        //Total guarding time set to 3 by default for testing.
        public float totalGuardTime = 3;
        public Transform[] patrolPoints;
        private int randomPoint;
        private int oldRandomPoint;
        public Vector2 newPoint;
        public Vector2 oldPoint;

        //Granny selects a random patrol point from the array. Consecutive selections of the same point are avoided.
        new public void Start()
        {
            //Speed set to 10f by default for testing.
            Speed = 10f;
            base.Start();
            guardTime = totalGuardTime;
            randomPoint = Random.Range(0, patrolPoints.Length);
            Debug.Log("Hello!");
            if(randomPoint == oldRandomPoint){
                randomPoint = Random.Range(0, patrolPoints.Length);
            }
            oldRandomPoint = randomPoint;

            oldPoint = transform.position;
        }
        //Overwrite base of abstractentity.
        new private void FixedUpdate(){ }

        //Animation, flip, timing and movement from point to point.
        public void Update()
        {
            newPoint = patrolPoints[randomPoint].position;
            if(newPoint.x > oldPoint.x){
                SR.flipX = false;
            }
            if(newPoint.x < oldPoint.x){
                SR.flipX = true;
            }

            Animator.SetBool("Patrolling", true);
            Animator.SetBool("Idle", false);
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, Speed * Time.deltaTime);


            if(Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f){
                if(guardTime <= 0){
                    randomPoint = Random.Range(0, patrolPoints.Length);
                    while(randomPoint == oldRandomPoint){
                        randomPoint = Random.Range(0, patrolPoints.Length);
                    }
                    oldRandomPoint = randomPoint;
                    guardTime = totalGuardTime;
                } else {
                    Animator.SetBool("Idle", true);
                    Animator.SetBool("Patrolling", false);
                    guardTime -= Time.deltaTime;
                    oldPoint = transform.position;
                }
            }
        }

        
    }
}
