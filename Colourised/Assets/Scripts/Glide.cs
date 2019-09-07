using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    
    private Rigidbody2D rb2D;
    public float glideValue; 
    private PhysicsObject pO;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pO = GetComponent<PhysicsObject>();
    }

    void Update()
    {
        bool glidePressed = Input.GetButtonDown("Fire2");

        if (glidePressed)
        { 
            //briefly stop y velocity 
            
            Debug.Log("Gliding");
            StartGlide();
        } 
    }
    void StartGlide()
    {
        //change fallrate/gravity??
        pO.gravityModifier = glideValue;
    }


    void StopGlide()
    {
        //return gravity value here?? 
    }
}
