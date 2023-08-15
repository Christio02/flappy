using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    private float spawnRate = 3;
    private float timer = 0;

    private float spawnChance = 80f;

    public GameObject closedPipe;
    

    public float heightOffset = 2f;

    private Camera mainCamera;

    void Start()
    {
        
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
            
        }
        else {
            spawnPipe();
            timer = 0;
        }

       
       
    }


   void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        int numGenerated = Random.Range(0, 100);

        if (numGenerated > spawnChance) {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        } else {
              Instantiate(closedPipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
      

       
    }
}
