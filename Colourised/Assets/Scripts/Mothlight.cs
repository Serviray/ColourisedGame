using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothlight : MonoBehaviour
{

    private GameObject lightObject;
    public Animator lightanim;
    public Animator MothAnima;
    public GameObject wind;

    // Start is called before the first frame update
    void Start()
    {
        lightObject = GameObject.FindGameObjectWithTag("light");
        wind = GameObject.FindGameObjectWithTag("WDM");

        lightObject.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        lightObject.SetActive(true);
        
        if (col.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            wind.SetActive(false);
            lightanim.SetTrigger("fall");

            // trigger light fall animation. 
            Invoke("mothF" , 1.0f);
            
        }
    }


    void mothF(){
            MothAnima.SetTrigger("mothF");
        
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        lightObject.SetActive(false);
    }
}
