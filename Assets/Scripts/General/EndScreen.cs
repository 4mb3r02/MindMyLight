using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen instance;
    int MaxLevel = 2; //making number higher than 9 breaks the system

    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject succeedScreen;

    GameObject youDied;
    GameObject mainMenuButton;
    GameObject retryButton;

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

    public void TurnOnDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void TurnOnSucceedScreen()
    {
        succeedScreen.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
    }

    public void LoadNextLevel()
    {
        int currentLevel = FindNumber();
        if (currentLevel < MaxLevel)
        {
            SceneLoader.LoadLevel(currentLevel+1);
        } else
        {
            LoadMainMenu();
        }
        
    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int FindNumber()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i <= MaxLevel; i++)
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
