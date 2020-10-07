using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject hitEffect;
    // private void OnCollisionEnter2D(Collision2D other)
    // {  
    //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //     Destroy(effect, 0.5f);
    //     Destroy(gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }    
}
