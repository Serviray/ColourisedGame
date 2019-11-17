using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedNPC : MonoBehaviour
{
    
    public Collider2D Trigger;
    public Animator RedAnima;

    void Start() {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            RedAnima.SetTrigger("jump");

        }  
    }
}
