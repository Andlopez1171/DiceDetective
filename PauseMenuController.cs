using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }//END Start

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }//END if
        }//END if
    }//END update

    public void PauseGame()
    {
        Debug.Log("Pausing");
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }//END pauseGame()

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }//END resume()

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }//END LoadGame

    public void QuitGame()
    {
        Debug.Log("Game has Quit");
        Application.Quit();
    }//END QuitGame
}
