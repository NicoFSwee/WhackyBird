using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenue : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenueUI;

    void Start()
    {
        pauseMenueUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenueUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        pauseMenueUI.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadMenue()
    {
        SceneManager.LoadScene("MainMenue");
        Time.timeScale = 1f;
    }
}
