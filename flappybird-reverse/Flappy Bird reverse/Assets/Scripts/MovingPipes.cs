using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPipes : MonoBehaviour
{
    public float moveSpeed = 5;

    private float deadZone = -20;

    private BirdScript bird;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

         if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }

        
        
    }
}
