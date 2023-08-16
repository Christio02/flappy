
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigid;

    // private GameObject objectBird;

    public LogicManager logic;

    private float flapStrength = 3;

    private bool birdIsAlive = true;

    public GameObject projectilePrefab;
    public Transform projectileSpawn;

    private float offsetProjectile = 0.4f;

    public float cooldown = 2f;

    private bool canSpawnProjectile = true;



    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            birdRigid.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 2.6 || transform.position.y < -5.6) {
            logic.gameOver();
            birdIsAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Vector3 pos = new Vector3(transform.position.x + offsetProjectile, transform.position.y, transform.position.z);
            spawnProjectile(pos);
            
           
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
        birdIsAlive = false;
        
      
    }

    public bool isAlive() {
        return birdIsAlive;
    }

    void spawnProjectile(Vector3 spawnPos) {
        if (canSpawn()) {
    	Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        logic.playShotgun();
        canSpawnProjectile = false;
        StartCoroutine(Cooldown());
        }
      
    
    }
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        canSpawnProjectile = true;
    }

    public bool canSpawn() {
        return canSpawnProjectile;
    }

   
}
