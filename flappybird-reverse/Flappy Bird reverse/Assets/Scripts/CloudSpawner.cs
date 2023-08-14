using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cloud;
    private float spawnRate = 10;
    private float upperBound = 2;
    private float lowerBound = -5;
    private float timer = 0;
    private 
    void Start()
    {
        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnCloud();
            timer = 0;
        }

        
    }

    void spawnCloud() {
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowerBound, upperBound), 0), transform.rotation);
    }
}
