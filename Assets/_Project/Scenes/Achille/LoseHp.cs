using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHp : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var body = other.attachedRigidbody;
        if( body) dealDamage(body.gameObject)
            else;
    }

    void dealDamage(GameObject obj)
    {
        var dam = obj.GetComponent<IDamageable>();
        dam?.TakeDamage(damage);
    }
    
    

    
}
