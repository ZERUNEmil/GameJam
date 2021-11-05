using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void secretMennu()
    {
        SceneManager.LoadScene("GameRules");
    }
}
