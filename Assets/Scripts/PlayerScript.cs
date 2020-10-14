using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    // private float     xPos;
    // public float      speed = .05f;
    // public float      leftWall, rightWall;
    public float health = 1f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
    public float moveSpeed = 5f;
    public Camera cam;
    public Image healthbar;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (health < 0.1)
        {
            SceneManager.LoadScene ("GameOver");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            health -= 0.1f;
            healthbar.fillAmount = health;
        }

        if (other.gameObject.tag == "HealthPack")
        {
            Destroy((other.gameObject));
            if (health < 0.7)
            {
                health += 0.3f;
            }
            else
            {
                health = 1; 
            }
            
            healthbar.fillAmount = health;
        }
    }
}

