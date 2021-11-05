using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollMovement : MonoBehaviour
{
    public Rigidbody2D rg;

    private int rollSpeed = 20;

    private bool _roll = true;
    private int _rollCooldown = 5;
    
    private void FixedUpdate()
    {
        if (_rollCooldown == 0)
        {
            _roll = true;
        }
        else
        {
            _rollCooldown--;
        }
        rg.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.Mouse1)&&_roll)
        {
            
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            rg.AddForce(mouseDirection * rollSpeed * Time.fixedDeltaTime);
            Debug.Log("ROOOOLLLLLING");
            _roll = false;
            _rollCooldown = 5;
        }
    }
}
