using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGameStatus();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameStatus>().ResetGameStatus();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
