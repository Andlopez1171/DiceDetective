using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public void House()
    {
        SceneManager.LoadScene("House");
    }//END House

    public void Junkyard()
    {
        SceneManager.LoadScene("Junkyard");
    }//END junkyard

    public void CrimeScene()
    {
        SceneManager.LoadScene("CrimeScene");
    }//END CrimeScene

    public void DetectiveOffice()
    {
        SceneManager.LoadScene("Detective's Office");
    }//END DetectiveOffice

    public void PoliceCar()
    {
        SceneManager.LoadScene("Police Car");
    }//END PoliceCar

    public void Quit()
    {
        SceneManager.LoadScene("Quit");
    }//END Quit

}
