using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

        private GameMaster gm;
        public int health;
        public int numHearts;
        public int damage = 1;
        public Image[] hearts;
        public Sprite fullHearts;
        public Sprite emptyHearts;
    
    void Update(){

        if(health > numHearts){
            health = numHearts;
        }

        if(Input.GetKeyDown(KeyCode.C)){
            takeDamage();
            Debug.Log("Coded -1 Dmg");
        }

        if(Input.GetKeyDown(KeyCode.V)){
            playerHeal();
            Debug.Log("Coded +1 Heal");
        }

        for (int i = 0; i < hearts.Length; i++) {

            if(i < health){
                hearts[i].sprite = fullHearts;
            } 
            else {
                hearts[i].sprite = emptyHearts;
            }

            if(i < numHearts){
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
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
    }


    public void playerHeal(){
        Debug.Log("Return One heart");
        numHearts = health+1;
        if (numHearts <= 0){
            numHearts = health;
        }
    }
}