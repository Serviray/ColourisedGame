using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class loadscene : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private GameObject player;
    public Animator transitionAnim;
    public int index = 1;

    void Awake() {

        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            StartCoroutine(nextscene());
        }
    }

    IEnumerator nextscene(){

        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        GameMaster.Instance().ChangeScene(index);

    }
}