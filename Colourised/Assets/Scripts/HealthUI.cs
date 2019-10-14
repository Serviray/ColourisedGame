using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public int numHearts;
    int healthAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int h)
    {
        healthAmount = h;
        //UI input/ update
        for (int i = 0; i < hearts.Length; i++) {

            if(i < healthAmount){
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
}
