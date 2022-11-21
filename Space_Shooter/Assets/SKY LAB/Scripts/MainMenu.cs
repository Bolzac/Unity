using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Preload");
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().NewGame();
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
