using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public bool WindON;
    public float WindOff = 3.0f;
    public float WindDuration = 6.0f;
    float Windtimer;
    private PlayerPlatformerController ppc;
    private WindMask windM; 

    // Start is called before the first frame update
    void Start()
    {
        ppc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        Windtimer = WindDuration;
        WindON = true;
        getWind();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        getWind();
        if (col.tag == "Player" && WindON == true)
        {
            if (windM.Isinwind == true){




                
                wind();

            }
        

        }
    }

    void getWind(){
        windM = GameObject.FindGameObjectWithTag("WDM").GetComponent<WindMask>();

    }

    void wind(){
        ppc.SetVelocity(new Vector2(-10,0.0f));
        Debug.Log("WIND");        
    }

    void windReset(){
        Windtimer = WindDuration;
        WindON = true;
        Debug.Log("WindON");
    }

    // Update is called once per frame
    void Update()
    {
        Windtimer -= Time.deltaTime;
        if(Windtimer <= 0.0f)
        {
            WindON = false;
            Debug.Log("WindON");
            Invoke("windReset", WindOff);
            //Wind OFF dur'
        }
        
    }
}
