using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public enum EnemyState
{
    IDLE,
    MOVING,
    START_ATTACK,
    ATTACKING,
    STUNNED
}
public class EnemyStatus : MonoBehaviour
{
    private float stunTime;
    public float startStunTime;
    private AIPath pathing;
    private PlayerHealth playerHp;
    public Collider2D stopChasing;
    public EnemyState state;
    public float chargeTime;
    private float chargeTimer;

            // Start is called before the first frame update
    void Start()
    {
        //Animation reference Here
        pathing = GetComponent<AIPath>();
        playerHp = GetComponent<PlayerHealth>();
        if (pathing)
        {
            Debug.Log("Enemy got pathing component");
        }
    }

    void Update()
    {
        if (state == EnemyState.START_ATTACK)
        {
            pathing.canMove = false;
            chargeTimer -= Time.deltaTime;
            if (chargeTimer <= 0.0f)
            {
                Debug.Log("Attack NOW");
                chargeTimer = 0.0f;
                state = EnemyState.ATTACKING;
                Invoke("FinishAttack", 2.0f);
            }
        }

        if (state == EnemyState.MOVING)
        {
            pathing.canMove = true;
        }

        if (state == EnemyState.STUNNED)
        {
            if(stunTime <= 0) //finish the stun
        {
            //restore AI Speed.
            //set stunTime to 0
            stunTime = 0;
            if (pathing)
            {
                pathing.canMove = true;
            }
        }
        else //be stunned
        {
            //need to call to change the A* speed
            stunTime -= Time.deltaTime;
            if (pathing)
            {
                pathing.canMove = false;
            }
        }    
        }
            
    }
    public void Stunned()
    {   
        state = EnemyState.START_ATTACK;
        stunTime = startStunTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           CollisionWithPlayer(col.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            CollisionWithPlayer(col.gameObject);
        }
    }

    public void CollisionWithPlayer(GameObject Player)
    {
        if (state == EnemyState.ATTACKING)
        {
            playerHp.takeDamage();
        }
        else if (state != EnemyState.START_ATTACK && state != EnemyState.STUNNED)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        state = EnemyState.START_ATTACK;
        chargeTimer = chargeTime;
    }

    private void FinishAttack()
    {
        state = EnemyState.MOVING;
    }
}
