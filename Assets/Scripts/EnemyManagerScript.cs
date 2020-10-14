using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyManagerScript : MonoBehaviour {
    public Transform brick;
    public Color[] brickColors;
    public float xSpacing, ySpacing;
    public float xOrigin, yOrigin;
    public int numRows, numColumns;

    public float speed = 2f;
    public float amplitude = 0.5f;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        float delay = 2f;
        float rate = 2f;
        InvokeRepeating("SpawnEnemy",delay,rate);

    }

    private void SpawnEnemy()
    {
        Transform go = Instantiate(brick);
        go.transform.parent = this.transform;
        int i = Random.Range(0, 20);
        int j = Random.Range(0, 20);
        Vector2 loc = new Vector2(xOrigin + (i * xSpacing), yOrigin - (j * ySpacing));
        
        go.transform.position = loc;
        
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>(); 
    }
    void Update()
    {
        
        


    }
}
