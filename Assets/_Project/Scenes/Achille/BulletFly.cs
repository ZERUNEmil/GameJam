using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed;
    private  Vector2 mousePos;
    public Rigidbody2D rb;
    public Vector2 mousePosition;

     Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        
        
        rb.velocity = worldPosition.normalized * speed;
       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer != 8 )
        Destroy(gameObject);
    }
}
