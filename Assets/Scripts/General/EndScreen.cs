using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen instance;

    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject succeedScreen;

    GameObject youDied;
    GameObject mainMenuButton;
    GameObject retryButton;
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("test");
        if (EndScreen.instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }     
    }

    public void GetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }

    public void LoadNextLevel()
    {
        SceneLoader.LoadLevel(2);
        //make non harcore
    }

    public void reloadLevel()
    {
        SceneLoader.LoadLevel(1);
        //make non hardcode
    }

    public void TurnOnDeathScreen()
    {
       // Debug.Log("player died");
        deathScreen.SetActive(true);
    }

    public void TurnOnSucceedScreen()
    {
        succeedScreen.SetActive(true);
    }
    
}
