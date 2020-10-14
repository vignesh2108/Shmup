using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileScript : MonoBehaviour
{
    public float               speed = 2f;
    public int direction;
    private Rigidbody2D        rb;
    public GameObject hitEffect;
    public GameObject healthpack;
    public bool Laser= false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }

    
    private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        rb.AddForce(transform.up * speed * direction);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Laser == true)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                int h = Random.Range(0, 100);
                if (h < 30)
                {
                    Instantiate(healthpack, transform.position, Quaternion.identity);
                }
                Destroy(other.gameObject);
            }
            
            return;
        }

        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {   GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            int h = Random.Range(0, 100);
            if (h < 30)
            {
                Instantiate(healthpack, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
            if (Laser == false)
            {
                Destroy(this.gameObject);
            }
            
            
        }

        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
