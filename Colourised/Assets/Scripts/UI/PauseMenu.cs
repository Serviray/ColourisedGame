using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; 

    public GameObject playerUI;
    public GameObject crystalUI;

    public GameObject pauseMenuUI;
    public GameObject controllMenuUI;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused)
            {
                Resume();
                Debug.Log("Game RESUMED");
            } else 
            {
                Pause();
                Debug.Log("Game PAUSED");

            }
        }

      
    }

    public void Resume()
    {
        crystalUI.SetActive(true);
        playerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        crystalUI.SetActive(false);
        playerUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ControllMenuUI()
    {
        controllMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
                Debug.Log("Control M UI");

    }

    public void ExitControllMenuUI()
    {
        controllMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
                Debug.Log("Control Exit");

    }
    public void LoadMenu()
    {   
        SceneManager.LoadScene("0");
        Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
