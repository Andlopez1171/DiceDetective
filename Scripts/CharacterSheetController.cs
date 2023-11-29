using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheetController : MonoBehaviour
{
    public GameObject characterSheetUI;
    public static bool GameIsPaused = false;

    void Start()
    {
        characterSheetUI.SetActive(false);
    }//END Start

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ExitSheet();
            }//END if
        }//END if
    }//END update

    public void PauseGameForSheet()
    {
        Time.timeScale = 0f;
        characterSheetUI.SetActive(true);
        GameIsPaused = true;
    }//END pauseGame()

    public void ExitSheet()
    {
        characterSheetUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }//END resume()
}
