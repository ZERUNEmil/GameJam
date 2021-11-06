using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag == "Player" && col.gameObject.tag == "Enemy" || gameObject.tag == "Player" && col.gameObject.tag == "Trap" ){
            Die();
        }
    }
 
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy"){
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}