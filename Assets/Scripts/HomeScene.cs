using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
        //public LevelComplete levelComplete;// = new LevelComplete();
    public void LetsBeatItClicked()
    {
        //levelComplete.LoadNextLevel();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
