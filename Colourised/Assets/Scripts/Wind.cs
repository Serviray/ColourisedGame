using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public bool WindON;
    public bool lightOff;
    public float WindDurOff = 5.0f;
    public float WindDuration = 6.0f;
    public float WindStn = 1;
    float Windtimer;
    private PlayerPlatformerController ppc;
    public Animator MothAnima;
    public ParticleSystem WindVFX;

    // Start is called before the first frame update
    void Start()
    {
        ppc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        Windtimer = WindDuration;
        WindON = true;
        lightOff = true;
        WindVFX.Play();
        
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
    }

    void windReset(){
        {
        Windtimer = WindDuration;
        WindON = true;
        MothAnima.SetTrigger("moth_attack");
        WindVFX.Play();
        Debug.Log("WindON");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Windtimer -= Time.deltaTime;
        
        
        if (Windtimer <= 0.0f && lightOff == true)
        {
            WindON = false;
            Debug.Log("WindOFF");
            MothAnima.SetTrigger("moth_idle");
            WindVFX.Stop();

            Invoke("windReset", WindDurOff);
            //Wind OFF dur'
        }
        

        //Anim Moth set trigger flapping whilst ture 
        
    }
}
