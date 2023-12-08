using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    GameObject endScreen;
    GameObject youDied;
    GameObject mainMenuButton;
    GameObject retryButton;
    // Start is called before the first frame update
    public void Start()
    {
        endScreen = GameObject.Find("End Screen");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void ShowDeathScreen()
    {

    }

    public void ShowSucceedScreen()
    {

    }

    public void GetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }

    public void TurnOnDeathScreen()
    {
        endScreen.SetActive(true);
    }
    
}
