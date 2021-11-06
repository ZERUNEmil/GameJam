using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Prod Scene");
    }
    public void Level2()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
    public void LevelBoss()
    {
        SceneManager.LoadScene("FourthLevel");
    }
}
