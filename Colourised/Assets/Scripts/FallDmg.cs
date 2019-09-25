using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDmg : MonoBehaviour
{
        
    void Start()
    {
         
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameMaster.Instance().rePosition(gameObject);
        }
    }
}
