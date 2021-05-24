using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EventSystems;
using Assets.Scripts;

public class LiftFront : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Current.onLiftDoorEnter += onLiftDoorEnter;
    }

    private void onLiftDoorEnter()
    {
        GetComponent<Animator>().SetBool("Close", true);
    }

    private void onAnimationEnded()
    {
        EventSystem.Current.LiftAnimationEnding();
    }

}
