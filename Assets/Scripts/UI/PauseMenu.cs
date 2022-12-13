using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuPanel;
    [SerializeField] public GameObject optionsMenuPanel;

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Pause();
        }
        else if (Input.GetButtonDown("Menu") && pauseMenuPanel.activeInHierarchy == true)
        {
            Resume();
        }
    }

    public void Pause()
    {
        PlayerInputChecker.isAcceptingPlayerInput = false;
        pauseMenuPanel.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PlayerInputChecker.isAcceptingPlayerInput = true;
        pauseMenuPanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void Options()
    {
        pauseMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
