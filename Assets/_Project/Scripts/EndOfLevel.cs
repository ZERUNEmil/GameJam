using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collisison)
    {
        Debug.Log(collisison.gameObject.tag);
        if (collisison.gameObject.tag == "Player")
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
