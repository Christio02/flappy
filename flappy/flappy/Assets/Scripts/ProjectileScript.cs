using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   private float lifeTime = 6f;
//    private float cooldown = 2f;
   
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
            Destroy(obstacle.gameObject);
            Destroy(gameObject);
        }   
    }


   
}
