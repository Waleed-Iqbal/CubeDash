
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextLevelNumber = SceneManager.GetActiveScene().buildIndex + 1;


        if (nextLevelNumber < totalScenes)
            SceneManager.LoadScene(nextLevelNumber);
        else // last level was reached
            SceneManager.LoadScene("HomeScene");
    }
}
