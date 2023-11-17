using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel(int level = 1)
    {
        SceneManager.LoadScene("Level_" + level, LoadSceneMode.Single);
    }
}