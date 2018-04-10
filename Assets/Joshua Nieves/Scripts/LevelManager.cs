using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject optionsCanvas;

    public bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else if (!isPaused)
            {
                Pause();
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelectArea1");
    }

    public void Area2()
    {
        SceneManager.LoadScene("LevelSelectArea2");
    }

    public void Area3()
    {
        SceneManager.LoadScene("LevelSelectArea3");
    }

    public void Area4()
    {
        SceneManager.LoadScene("LevelSelectArea4");
    }

    public void Area5()
    {
        SceneManager.LoadScene("LevelSelectArea5");
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void Back()
    {
        optionsCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void OptionsPause()
    {
        optionsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        isPaused = false;
        Debug.Log("Resume");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        isPaused = true;
        Debug.Log("Paused");
    }
}
