using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Prod Scene");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void GameRules()
    {
        SceneManager.LoadScene("GameRules");
    }

}
