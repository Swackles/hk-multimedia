using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //Debug.Log message is for testing, since Application.Quit doesnt close the game in editor.
        Debug.Log ("Game Closed");
        Application.Quit();
    }
}
