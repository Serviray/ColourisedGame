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
    private AIDestinationSetter aiDestination;
    public Collider2D stopChasing;
    public EnemyState state;
    public float chargeTime;
    private float chargeTimer;
    public float ActiveRnge = 13.0f;
    public Transform startPosition;
    //Try and change this to the start position of the prefab (when it was placed)
    private PlayerHealth player;

            // Start is called before the first frame update
    void Start()
    {
        //Animation reference Here
        pathing = GetComponent<AIPath>();
        aiDestination = GetComponent<AIDestinationSetter>();
        GetPlayer();
        
    }

    void GetPlayer()
    {
        player = GameMaster.Instance().GetPlayerHealth();
    }

    void Update()
    {
        if (player == null)
        {
            GetPlayer();
        }
        else if (aiDestination != null)
        {
            if (Vector2.Distance(player.transform.position, transform.position) > ActiveRnge)
            {
                aiDestination.target = startPosition;
                /*pathing.canMove = false;
                return;*/
            }
            else
            {
                aiDestination.target = player.transform;
                pathing.canMove = true;
            }
        }

        if (state == EnemyState.START_ATTACK)
        {
            pathing.canMove = false;
            chargeTimer -= Time.deltaTime;
            if (chargeTimer <= 0.0f)
            {
                Debug.Log("Attack NOW");
                chargeTimer = 0.0f;
                state = EnemyState.ATTACKING;
                Invoke("FinishAttack", 2);
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

    public void CollisionWithPlayer(GameObject col)
    {
        if (state == EnemyState.ATTACKING)
        {
            
        }
        else if (state != EnemyState.START_ATTACK && state != EnemyState.STUNNED)
        {
            GameMaster.Instance().GetPlayerHealth().takeDamage();
            StartAttack();
            Debug.Log("restarting attack");
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