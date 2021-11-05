using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public bool isTouched = false;
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player" && other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy"){
            isTouched  = true;
            Die();
        }
    }
 
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy"){
            isTouched  = false;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
