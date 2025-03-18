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
        movePipe(Vector3.left);

         if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }


        
        
    }

    public void movePipe(Vector3 direction) {
        transform.position = transform.position + direction * moveSpeed * Time.deltaTime;
    }

    
}
