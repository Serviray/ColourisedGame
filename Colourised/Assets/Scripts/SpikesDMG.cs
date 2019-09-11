using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDMG : MonoBehaviour
{
    private PlayerHealth player;
    public float chargeTime;
    private float chargeTimer;
    // Start is called before the first frame update
    void Start()
    {
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
           CollisionWithPlayer(col.gameObject);
           
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            CollisionWithPlayer(col.gameObject);
        }
    }

    public void CollisionWithPlayer(GameObject col)
    {
        GameMaster.Instance().GetPlayerHealth().takeDamage();
        EnviroDelay();
        Debug.Log("Enviro DMG");
    }

    private void EnviroDelay()
    {
        
        
        chargeTimer = chargeTime;
    }

}
