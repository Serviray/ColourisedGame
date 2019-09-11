using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{   


    void Start(){
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")){
            GameMaster.Instance().SetCheckpoint( transform.position );
        }
    }
}
