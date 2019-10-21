using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject 
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 12;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Vector2 currentVelocity;
    private bool facingRight;
    public float kbstrength = 50.0f;

    // Use this for initialization
    void Awake () 
    {   
        facingRight = true;
        spriteRenderer = GetComponent<SpriteRenderer> ();    
        animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) //press jump
        {
            velocity.y = jumpTakeOffSpeed;
        } 
        else if (Input.GetButtonUp ("Jump")) //release jump
        { 
            if (velocity.y > 0) 
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        
        if( (move.x > 0 && !facingRight) || (move.x < 0 && facingRight) )
        {
            Flip();    
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
        currentVelocity = targetVelocity;
    }
 

    public void SetVelocity(Vector2 newVelocity)
    {
        //targetVelocity = newVelocity;
        rb2d.velocity = newVelocity;
    }

    public void knockback(){
        SetVelocity(new Vector2(-10,0.0f));
        Debug.Log("KB");
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;

        theScale.x *=-1;

        transform.localScale = theScale;
    }

    
}
