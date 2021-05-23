using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EventSystems;

public class LiftTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventSystem.Current.LiftDoorEnter();
    }
}
