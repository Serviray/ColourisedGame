using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnima : MonoBehaviour
{
    public bool birdAttack;

    public bool birdFaint = false;

    public int hits = 0;
    
    [SerializeField] public Animator bAnima;

    public Animator CrystalAnima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hits == 3)
        {   
            Debug.Log("Bird hit All Mushrooms");
            // faint animation.
            bAnima.SetTrigger("Faint");
            birdFaint = true;
            Invoke("throwCrystal", 2.0f);
        }
    }

    void throwCrystal()
    {
        CrystalAnima.SetTrigger("throw");

    }
}
