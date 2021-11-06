using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene("Prod Scene");
    }
}
