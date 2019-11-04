using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMushroom : MonoBehaviour
{
    
    private BirdAnima birdAnima;
    private float timer; 
    private bool inM = false;
    private int birdhits;
    public float MushroomNUM;
    public float Cd = 4.0f;
    public Animator bAnima;

    // Start is called before the first frame update
    void Start()
    {
        birdAnima = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdAnima>();
        timer = Cd; 
    
    }
    void Update()
    {
       if (timer >= 0.0f && inM){
            timer -= Time.deltaTime;
        }else if (timer <= 0.0f)
        {
            BirdAttack();
        }
    }

    
    public void BirdAttack(){
        inM = false;
        timer = Cd;

        if(MushroomNUM == 1.0f){
            bAnima.SetTrigger("A1");
            Invoke("birdReset", 2.0f);

        }
        if(MushroomNUM == 2.0f){
            bAnima.SetTrigger("A2");
            Invoke("birdReset", 2.0f);

        }
        if(MushroomNUM == 3.0f){
            bAnima.SetTrigger("A3");
            Invoke("birdReset", 2.0f);
        }
    }
    public void BirdHits()
    {
        birdhits += 1;
        Debug.Log("BirdHit");
    }

    void birdReset(){
        bAnima.SetTrigger("Idle");
        if(birdhits == 3)
        {   
            Debug.Log("Bird hit All Mushrooms");
            // faint animation.
            bAnima.SetTrigger("Idle");
            birdAnima.birdFaint = true;
        }
        Destroy(gameObject);
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            inM = false;
            timer = Cd;
            Debug.Log("Exit PLAYER");
        }

        if (col.tag == "Bird"){
            BirdHits();
            
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
        Debug.Log("Enter PLAYER");

            inM = true;
        }
    }
}
