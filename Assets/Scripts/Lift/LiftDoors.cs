using UnityEngine;
using Assets.Scripts.EventSystems;
using QFSW.QC;

public class LiftDoors : MonoBehaviour
{
    private void onAnimationEnd()
    {
        EventSystem.Current.GameFinished();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Animator>().SetBool("Close", true);
        Assets.Scripts.Entity.Player.Current.GameFinished();
    }
}
