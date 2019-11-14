using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public bool WindON;
    public float WindOff = 3.0f;
    public float WindDuration = 6.0f;
    public float WindStn = 1;
    float Windtimer;
    private PlayerPlatformerController ppc;
    public Animator MothAnima;

    // Start is called before the first frame update
    void Start()
    {
        ppc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        Windtimer = WindDuration;
        WindON = true;

    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && WindON == true )
        {
           wind();
           
        }
    }

    void wind(){
        ppc.SetVelocity(new Vector2(-10 * WindStn ,0.0f));
        Debug.Log("WIND");  
    }

    void windReset(){
        Windtimer = WindDuration;
        WindON = true;
        MothAnima.SetTrigger("moth_attack");
        Debug.Log("WindON");
    }

    // Update is called once per frame
    void Update()
    {
        Windtimer -= Time.deltaTime;
        if(Windtimer <= 0.0f)
        {
            WindON = false;
            Debug.Log("WindOFF");
            MothAnima.SetTrigger("moth_idle");
            Invoke("windReset", WindOff);
            //Wind OFF dur'
        }

        //Anim Moth set trigger flapping whilst ture 
        
    }
}
