using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuPanel;
    [SerializeField] public GameObject optionsMenuPanel;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
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
