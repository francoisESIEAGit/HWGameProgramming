using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public GameObject player;
    public int sirenHealth = 200;
    public bool isDead = false;
    public AudioSource screamFX;
    public AudioSource attackFx;
    public AudioSource monsterFx;
    public  bool ignorePlayer = false;
    public GameObject enemy; // the gameobject of the enemy
    

    void damageMonster(int damageAmount)
    {
        
        sirenHealth -= damageAmount; // when the monster get damage it take the damage from the gun

    }
    // Update is called once per frame
    void Update()
    {
        if (sirenHealth < 0 && !isDead) // if the enemy has no health left then he die
        {
            
            StartCoroutine(EnemyDie());

        }
    }

    IEnumerator EnemyDie()
    {
        // if the player was currently attack  by the monster // 
        player.GetComponent<CharacterController>().enabled = true;
        // 
        monsterFx.Stop();
        attackFx.Stop();

        isDead = true; // enemy is now dead 
        screamFX.Play();
        yield return new WaitForSeconds(3.0f);
        // add the animation

        enemy.SetActive(false);
    }
   
}
