using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.General
{
    public static class SceneLoader
    {
        public static void LoadLevel(int level = 1)
        {
            SceneManager.LoadScene($"Level {level} Start", LoadSceneMode.Single);
        }

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene($"Main Menu", LoadSceneMode.Single);
        }
    }
}