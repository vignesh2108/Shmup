using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyProjectile;
    
    // Start is called before the first frame update
    void Start()
    {
        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        InvokeRepeating("Fire",delay,rate);
    }

    // Update is called once per frame
    private void Fire()
    {
        int i = Random.Range(0, 100);
        if (i > 10)
        { 
            Instantiate(enemyProjectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}
