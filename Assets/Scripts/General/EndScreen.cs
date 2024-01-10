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
    //string[] numberCheck;
    // Start is called before the first frame update
    public void Start()
    {
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
        SceneLoader.LoadLevel(FindNumber()+1);
    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TurnOnDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void TurnOnSucceedScreen()
    {
        succeedScreen.SetActive(true);
    }

    public int FindNumber()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i < 10; i++)
        {
            char c = '0';
            int r = i;
            c += (char) r;
            Debug.Log(currentScene);
            if (currentScene.Contains(c))
            {
                return i;
            }
            
        }
        return -1;
    }
}
