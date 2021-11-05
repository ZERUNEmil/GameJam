using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Schema;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GenerateSound : MonoBehaviour
{
    [SerializeField] private Transform soundOrigin;
   
    private int x, y, z = 1;
    private Vector3 VMax = new Vector3(7,7,7);
    private Vector3 mMax = new Vector3(1,1,1);
    
    
    public PlayerMovement playerSpeed; 
   
   

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
           growSound(VMax,transform );
           playerSpeed.moveSpeed = 7;
        }
        if (Input.GetButton("Fire2"))
        {
            reduceSound(mMax, transform);
            playerSpeed.moveSpeed = 4;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D ennemy)
    {
       
        if (ennemy.CompareTag("Enemy"))
        {
            ennemy.gameObject.GetComponent<FieldOfView>().setTarget(transform);
           
        }
    }

    public void growSound(Vector3 size, Transform origin)
    {
       
            origin.localScale = size;
        
    }
    
    public void reduceSound(Vector3 size, Transform origin)
    {
        origin.localScale = size;
    }
    }

    
    

