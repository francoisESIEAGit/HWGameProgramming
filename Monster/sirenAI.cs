using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sirenAI : MonoBehaviour
{
    
    
    public GameObject player;
    public GameObject monster;

    public AudioSource screamFX;
    public AudioSource playerFright;
    public bool playerGetCaught = false;
    public AudioSource monsterFx;
    public AudioSource killPlayer;
    public float monsterSpeed = 1.0f;
    public bool isAttacking = false;



    void OnTriggerEnter(Collider other)
    {
        bool ignorePlayer = monster.GetComponent<monster>().ignorePlayer;

        if (other.gameObject.CompareTag("Player") && !ignorePlayer)
        {
            
            StartCoroutine(FindThePlayer());
        }
    }

    IEnumerator FindThePlayer()
    {
        yield return new WaitForSeconds(1.0f);
        if (!isAttacking)
        {
            if(!playerGetCaught)
            {
                playerGetCaught = true;
                playerFright.Play();

            }
            monster.transform.LookAt(player.transform);
            monsterFx.Stop();
            isAttacking = true;
            screamFX.Play();
            monster.GetComponent<Animator>().Play("player_get_caught");
            yield return new WaitForSeconds(2.0f);
            // launch the animation
            player.GetComponent<CharacterController>().enabled = false;
            killPlayer.Play();
            monster.GetComponent<Animator>().Play("attack");
            // add damage
            StartCoroutine(KillPlayer());
            


        }
    }

    IEnumerator KillPlayer()
    {
        // add damage
        Debug.Log("On rentre dedans");
        player.GetComponent<PlayerInfo>().currentHealth -= 10;
        Debug.Log(player.GetComponent<PlayerInfo>().currentHealth);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(KillPlayer());

    }



}
