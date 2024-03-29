using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{

    // ===================================== PLAY GAME =====================================
    public void PlayGame()
    {
        // A way to change the scene with the Scene Manager -- File/ Build Settings/ Sccenes in Build
        // We change it from 0 to 1

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // ===================================== VOLUME SETTINGS =====================================

    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    //H�ctor es tonto

    public void setMusic(float music)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("music", music);
    }

    public void setSFX(float sfx)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("sfx", sfx);
    }



    // ===================================== QUALITY SETTINGS =====================================

    public void setQuality (int qualityIndex)
    {
        if(qualityIndex == 0)
        {
            qualityIndex = 2;
        }
        else if (qualityIndex == 2)
        {
              qualityIndex = 0;
        }

        Debug.Log("Past quality -- " + QualitySettings.GetQualityLevel());
        Debug.Log("New quality -- " + qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }



    //Just in case we need it after the player press backwards in the main screen
    public void QuitGame()
    {
        //Messages throught the console
        Debug.Log("Quit Done");
        Application.Quit();
    }
}
