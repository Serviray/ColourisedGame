using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrystalUI : MonoBehaviour
{
    public Image[] crystals;
    public Sprite currentCrystals;
    public Sprite emptyHolder;
    public int numCrystals;
    int crystalAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCrystals(int c)
    {
        crystalAmount = c;
        //UI input/ update
        for (int i = 0; i < crystals.Length; i++) {

            if(i < crystalAmount){
                crystals[i].sprite = currentCrystals;
            } 
            else {
                crystals[i].sprite = emptyHolder;
            }

            if(i < numCrystals){
                crystals[i].enabled = true;
            }
            else {
                crystals[i].enabled = false;
            }
        }
    }
}
