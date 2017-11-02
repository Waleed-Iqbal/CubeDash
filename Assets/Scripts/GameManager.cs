using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasGameEnded = false;
    int restartDelay = 1;

    public void EndGame()
    {
        if (!hasGameEnded)
        {
            hasGameEnded = true;
            Invoke("RestartGame", restartDelay);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
