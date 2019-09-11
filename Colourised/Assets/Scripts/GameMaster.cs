using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    private GameObject player;
    private PlayerHealth playerHealth;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastCheckPointPos = player.transform.position;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public static GameMaster Instance()
    {
        return instance;
    }

    public PlayerHealth GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetCheckpoint(Vector2 pos)
    {
        lastCheckPointPos = pos;
    }
     
     public void killPlayer (GameObject Player) 
     {
         //Destroy (Player);
         if (lastCheckPointPos != null)
         {
             //teleport and reset the player
            player.transform.position = lastCheckPointPos;
            playerHealth.Reset();
         }
     }

}