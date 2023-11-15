using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    // ===================================== Change Scenes =====================================
    public void PlayLvl1()
    {
        // A way to change the scene with the Scene Manager -- File/ Build Settings/ Sccenes in Build
        // We change it from 0 to 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLvl2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
