using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAnimationEvent : MonoBehaviour
{
    public AudioSource soundToPlay;
    public string nameAnimation;
    public GameObject trigger;
    public float eventDuration;
    public GameObject objectToAnimate;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(playEvent());
        }
    }


    IEnumerator playEvent()
    {
        soundToPlay.Play();
        objectToAnimate.GetComponent<Animator>().Play(nameAnimation);
        yield return new WaitForSeconds(eventDuration);
        trigger.SetActive(false);


    }
}
