using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public Transform newpos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           CollisionWithPlayer(col.gameObject);
        }
    }

     public void CollisionWithPlayer(GameObject col)
    {
        player.transform.position = newpos.position;
        Debug.Log("Tp'ed");
    }
}
