using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{
    private float timebetweenAttack;
    public float startTimeBtwAttack;
    public Transform stunPos;
    public float stunRange;
    public LayerMask stunable;  
    void Update()
    {
        if(timebetweenAttack <= 0){

            if(Input.GetKey(KeyCode.E)){
                Collider2D[] enemiesToStun = Physics2D.OverlapCircleAll(stunPos.position, stunRange, stunable);
                for (int i = 0; i < enemiesToStun.Length; i++){
                    enemiesToStun[i].GetComponent<EnemyStatus>().Stunned();
                }
                Debug.Log("STUN");
            }

            timebetweenAttack = startTimeBtwAttack;
        } else {
            timebetweenAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(stunPos.position, stunRange);
    }

}
