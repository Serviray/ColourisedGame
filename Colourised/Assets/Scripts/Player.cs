using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f;
    public float jumpPower = 150f;
    private Animator _anim;
    public Transform m_GroundCheck;
    public bool grounded = true;
    private bool m_FacingRight = true;
    [SerializeField] private LayerMask m_WhatIsGround;  

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        bool jump = Input.GetButton("Jump");
        CheckGround();

        //horiz movement
        rb2d.AddForce(Vector2.right * speed * h);
        if (h < 0.0f && m_FacingRight)
        {
            Flip();
        }
        if (h > 0.0f && !m_FacingRight)
        {
            Flip();
        }

        //vertical movement
        if (grounded && jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        //update anim params
        if (_anim != null)
        {
            _anim.SetFloat("Speed", rb2d.velocity.x);
            _anim.SetBool("Grounded", grounded);
        }



    }

    private void CheckGround()
    {
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, 0.6f, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
