using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }
    public void MainMenuBtn()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore(); // Singleton üzerinden eriþ
        }

        SceneManager.LoadScene(0);
    }

    public void QuitBtn()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore(); // Singleton üzerinden eriþ
        }

        Application.Quit();
    }
}
