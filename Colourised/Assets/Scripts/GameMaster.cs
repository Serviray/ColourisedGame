using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector2 lastCheckPointPos;
    private GameObject player;
    private PlayerHealth playerHealth;
    public int crystals = 0; 
    public int health = 6;
    public int numHearts = 6;

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
        //GameMaster.instance.player = gameObject;
    }

    void Start()
    {
        SceneManager.activeSceneChanged += ResetForScene;
        RealResetForScene();
    }

    public static GameMaster Instance()
    {
        return instance;
    }

    public void ChangeScene(int sceneindex)
    {
        GetPlayerHealth().SavePlayer();   
        SceneManager.LoadScene(sceneindex);
    }

    public void ResetForScene(Scene current, Scene next)
    {
        RealResetForScene();
    }

    private void RealResetForScene()
    {
        Debug.Log("Reset For Scene");
        player = GameObject.FindWithTag("Player");
        lastCheckPointPos = player.transform.position;
        playerHealth = player.GetComponent<PlayerHealth>();
        Debug.Log("Player health is now: " + playerHealth);
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

    public void rePosition (GameObject Player) 
    {
         //Destroy (Player);
         if (lastCheckPointPos != null)
         {
            //teleport and reset the player
            player.transform.position = lastCheckPointPos;
            playerHealth.takeDamage();
         }
    }

}