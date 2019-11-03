using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDMG : MonoBehaviour
{   
    private PlayerHealth player;
    private PlayerPlatformerController ppc;
    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();
        ppc = GameObject.Find("Player").GetComponent<PlayerPlatformerController>();
    }
    void GetPlayer()
    {
        player = GameMaster.Instance().GetPlayerHealth();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           GameMaster.Instance().GetPlayerHealth().takeDamage();
           Debug.Log("Bird Dmg");
           ppc.knockback();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
