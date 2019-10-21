using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDMG : MonoBehaviour
{
    private PlayerHealth player;
    public float chargeTime;
    private float chargeTimer;
    private PlayerPlatformerController ppc;
    // Start is called before the first frame update
    void Start()
    {
        ppc = GetComponent<PlayerPlatformerController>();
        GetPlayer();
    }

    // Update is called once per frame
    void GetPlayer()
    {
        player = GameMaster.Instance().GetPlayerHealth();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           GameMaster.Instance().GetPlayerHealth().takeDamage();
           Debug.Log("Enviro DMG");
           ppc.knockback();
           
        }
    }
}
