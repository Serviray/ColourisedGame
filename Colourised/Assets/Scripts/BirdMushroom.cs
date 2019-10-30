using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMushroom : MonoBehaviour
{
    public Animator birdAnima;
    public float attackDelay = 6.0f;
    private float attacktimer;
    private bool attackReady;
    private bool inTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        attackReset();
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" )
        {
            inTrigger = true;
            if(attacktimer <= 0)
            {
            birdAnima.Play("A1");
            Debug.Log("Bird Attacking");
            
            //duration is animation duration
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" )
        {
            inTrigger = false;
            attackReset();
           
           Debug.Log("Exit");
        }
    }

    void attackReset(){
        attacktimer = attackDelay;
        Debug.Log("reset time");
    }

    // Update is called once per frame
    void Update()
    {
       if(attacktimer >= 0 && inTrigger == true)
       {
            attacktimer -= Time.deltaTime;
            Debug.Log(attacktimer);
       }
    }
}
