using Assets.Scripts.EventSystems;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

namespace Assets.Scripts
{
    public class LiftDoors : MonoBehaviour
    {
        private void onAnimationEnd()
        {
            Regex reg = new Regex(@"Level_(\d+)");
            Match match = reg.Match(SceneLoader.CurrentSceneName);
            string nextSceneName = "Level_" + (Int32.Parse(match.Groups[1].Value) + 1);
            
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                SceneLoader.NextLevel();
            else
                EventSystem.Current.GameFinished();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GetComponent<Animator>().SetBool("Close", true);
            Entity.Player.Current.GameFinished();
        }
    }
}
