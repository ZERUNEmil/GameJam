using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("FIN de LEVEL");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
