﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDMG : MonoBehaviour
{   
    private PlayerHealth player;
    private PlayerPlatformerController ppc;
    public float effectdelay = 2.0f;

    private bool effectON;
    
    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();
        ppc = GameObject.Find("Player").GetComponent<PlayerPlatformerController>();
        effectON = true;
    }
    void GetPlayer()
    {
        player = GameMaster.Instance().GetPlayerHealth();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && effectON)
        {
           effectON = false;
           GameMaster.Instance().GetPlayerHealth().takeDamage();
           Debug.Log("Bird Dmg");
           ppc.knockback();
           Invoke("reset", effectdelay);
        }
    }

    void reset(){
        effectON = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
