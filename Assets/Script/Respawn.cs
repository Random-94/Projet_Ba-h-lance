using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform ball;
    [SerializeField] private Transform RespawnPoint;
    public Ball_Controls myRB1; // j'appelle l'autre script de la balle

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            ball.transform.position = RespawnPoint.transform.position;
            Physics.SyncTransforms();
            myRB1.myRB.velocity = Vector3.zero; 
        }
    }
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
