using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isTouched = false;
    public GameObject obj;
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
       Destroy(obj);
    }
}
