using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

        private GameMaster gm;
        public int health;
        public int numHearts;
        public int crystals; 
        public int damage = 1;
        public HealthUI healthUI;
        public CrystalUI crystalUI;
        
    
    void Start (){
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        //Playerstats = GM.Stats
        health = GameMaster.instance.health;
        numHearts = GameMaster.instance.numHearts;
        crystals = GameMaster.instance.crystals;
        UpdateHealthUI();
    }
    
    void Update(){
        
        if(health > numHearts){
            health = numHearts;
            UpdateHealthUI();
        }

        //dev debugging
        if(Input.GetKeyDown(KeyCode.C)){
            takeDamage();
            Debug.Log("Coded -1 Dmg");
        }

        if(Input.GetKeyDown(KeyCode.V)){
            playerHeal();
            Debug.Log("Coded +1 Heal");
        }

        if(Input.GetKeyDown(KeyCode.B)){
            addCrystal();
            Debug.Log("Coded +1 Crystal");
        }

    }

    public void UpdateHealthUI()
    {
        if (healthUI != null)
        {
            healthUI.SetHealth(health);
        }

        if (crystalUI != null)
        {
            crystalUI.SetCrystals(crystals);
        }
    }

    public void Reset()
    {
        health = numHearts;
    }

    public void takeDamage(){
        Debug.Log("Ai 1 Dmg");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log ("PLayer Killed");
            GameMaster.Instance().killPlayer(gameObject);
        }
        UpdateHealthUI();
    }
    public void playerHeal(){
        Debug.Log("Return One heart");
        health += 1;
        if (numHearts <= 0){
            numHearts = health;
        }
        UpdateHealthUI();
    }

    public void addCrystal(){
        Debug.Log("1 NEW CRYSTAL");
        crystals += 1;
        UpdateHealthUI();
        
    }

    public void SavePlayer()
    {
        GameMaster.instance.health = health;
        GameMaster.instance.numHearts = numHearts;
        GameMaster.instance.crystals = crystals;
    }
}