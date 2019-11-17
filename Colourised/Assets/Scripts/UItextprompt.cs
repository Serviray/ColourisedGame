using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItextprompt : MonoBehaviour
{
    public Collider2D textTrigger;
    public GameObject gameObject;


    void Start() 
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D col)
    {
         if (col.tag == "Player")
        {
            gameObject.SetActive(false);
           
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
         if (col.tag == "Player")
        {
            gameObject.SetActive(true);
           
        }
    }

}
