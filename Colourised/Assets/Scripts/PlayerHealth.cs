using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    
        public int health;
        public int numHearts;

        public Image[] hearts;
        public Sprite fullHearts;
        public Sprite emptyHearts;
    
    void Update(){

        if(health > numHearts){
            health = numHearts;
        }


        for (int i = 0; i < hearts.Length; i++) {

            if(i< health){
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

    public void takeDamage(){
        Debug.Log("Take One heart");
        health = health-1;
   /*      if (numHearts <= 0){
            Debug.Log ("PLayer Killed");
            GameMaster.killPlayer(this);
      */  
    }

    public void playerHeal(){
        Debug.Log("Return One heart");
        numHearts = health+1;
        if (numHearts <= 0){
            numHearts = health;
        }

    }

}