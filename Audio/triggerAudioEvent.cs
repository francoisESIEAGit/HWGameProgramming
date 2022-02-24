using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAudioEvent : MonoBehaviour
{
    public AudioSource soundToPlay;
    public GameObject trigger;
    public float soundDuration;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(playSound());
        }
    }


    IEnumerator playSound()
    {
        soundToPlay.Play();

        yield return new WaitForSeconds(soundDuration);
        soundToPlay.Stop();
       
        trigger.SetActive(false);


    }
}
