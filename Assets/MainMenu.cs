using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // A way to change the scene with the Scene Manager -- File/ Build Settings/ Sccenes in Build
        // We change it from 0 to 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Just in case we need it after the player press backwards in the main screen
    public void QuitGame()
    {
        //Messages throught the console
        Debug.Log("Quit Done");
        Application.Quit();
    }

}
