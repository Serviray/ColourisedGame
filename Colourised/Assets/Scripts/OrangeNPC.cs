using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeNPC : MonoBehaviour
{
    public Collider2D WaveTrigger;
    public Animator OrangeAnima;

    void Start() {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            OrangeAnima.SetTrigger("wave");

        }  
    }
    
}
