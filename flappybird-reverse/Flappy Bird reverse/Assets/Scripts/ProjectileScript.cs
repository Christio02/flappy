using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 6f;
   
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 15) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D obstacle) {
        if (obstacle.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Hit!");
            Destroy(obstacle.gameObject);
            Destroy(gameObject);
        }   
    }
}
