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
    public float Cd = 2.0f;
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
            BirdHits();
        }
    }

    
    public void BirdAttack(){
        inM = false;
        birdAnima.birdAttack = true;

            
        timer = Cd;

       
        bAnima.SetBool ("birdAttack", birdAnima.birdAttack);   
        //bAnima.SetTrigger("A1");
        //bAnima.SetTrigger("A2");
        //bAnima.SetTrigger("A3");



        
        Invoke("birdReset", 2.0f);
    }
    public void BirdHits()
    {
        birdhits += 1;
            Debug.Log("BirdHit");
    }

    void birdReset(){
        birdAnima.birdAttack = false;

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
            if(birdhits >= 3)
        {   
            Debug.Log("Bird hit Mushrooms");
            // faint animation.
            birdAnima.birdFaint = true;
            birdReset();
        }
            
        }
        bAnima.SetBool ("birdFaint", birdAnima.birdFaint);     }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
        Debug.Log("Enter PLAYER");

            inM = true;
        }
    }
}
