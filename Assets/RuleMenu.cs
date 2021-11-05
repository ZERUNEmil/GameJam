using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
