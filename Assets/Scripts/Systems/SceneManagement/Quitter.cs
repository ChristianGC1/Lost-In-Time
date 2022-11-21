using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quitter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doExitGame();
        }
    }

    public void doExitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }


}
