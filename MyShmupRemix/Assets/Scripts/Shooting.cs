using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject PrimarybulletPrefab;
    public GameObject SecondarybulletPrefab;
    public float bulletForce = 20f;

    public int FireMode = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (FireMode == 0)
            {
                Shoot();
            }
            else if (FireMode == 1)
            {
                Shoot2();
            }
            
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(PrimarybulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Shoot2()
    {
        GameObject bullet = Instantiate(SecondarybulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
