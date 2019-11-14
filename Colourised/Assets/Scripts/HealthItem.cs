using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private PlayerHealth player;
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
            GetPlayer();
            if (player.health < 6)
        {
           GameMaster.Instance().GetPlayerHealth().playerHeal();
           Debug.Log("Item Healed");
           Invoke("Destroyitem" , 0.1f);
        }
           
        }
    }

    void Destroyitem(){
        Destroy(gameObject);        
    }
}
