using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMask : MonoBehaviour
{   
    public PlayerPlatformerController ppc;
    [SerializeField] public bool Isinwind;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Isinwind = true;

           Debug.Log("Wind true");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Isinwind = false;

           Debug.Log("Wind false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
