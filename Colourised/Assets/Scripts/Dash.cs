using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    public float dashDuration;
    public float dashCdTime;
    private float dashCdTimer;
    private float prevHVelocity;
    private bool dashing;
    private PlayerPlatformerController ppc;

    // Start is called before the first frame update
    void Start()
    {
        dashing = false;
        rb = GetComponent<Rigidbody2D>();
        ppc = GetComponent<PlayerPlatformerController>();
    }

    void Update()
    {
        bool dashPressed = Input.GetButtonDown("Fire3");
        float samplePrevMovement = ppc.currentVelocity.x;
        if (Mathf.Abs(samplePrevMovement) > 0.05f)
            prevHVelocity = ppc.currentVelocity.x;

        if (dashPressed)
        {
            if(dashCdTimer <= 0) 
            {
            dashing = true;
            dashCdTimer = dashCdTime;
            StartDash();
            }

        } else{
            dashCdTimer -= Time.deltaTime;
        }

        ppc.animator.SetBool ("dashing", dashing);
    }

    void StartDash()
    {
        float movement = 0.0f;
        if (prevHVelocity < 0)
            movement = prevHVelocity - dashSpeed;
        else
            movement = prevHVelocity + dashSpeed;
        ppc.SetVelocity(new Vector2(movement, 0.0f));
        Invoke("StopDash", dashDuration);
    }

    void StopDash()
    {
        dashing = false;
        ppc.SetVelocity(Vector2.zero);
        Debug.Log("Dashed");
    }
}
