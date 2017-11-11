using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
        //public LevelComplete levelComplete;// = new LevelComplete();
    public void LetsFallClicked()
    {
        //levelComplete.LoadNextLevel();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
