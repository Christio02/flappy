using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    [SerializeField] private LogicManager logic;

    private MovingPipes pipes;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        pipes = GetComponentInParent<MovingPipes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 3) {
            logic.addScore(1);

            
        }
        
    }
}
