using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Detective's Office");
    }//END PlayGame

    public void ArcadeMode()
    {
        SceneManager.LoadScene("Battle");
    }

    public void QuitGame()
    {
        Application.Quit();
    }//END QuitGame
}
