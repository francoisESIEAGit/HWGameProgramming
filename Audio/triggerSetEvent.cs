using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSetEvent : MonoBehaviour
{
    public GameObject objectToSet;
    public GameObject trigger;
    public float soundDuration;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(SetEvent());
        }
    }


    IEnumerator SetEvent()
    {
        objectToSet.SetActive(true);

        yield return new WaitForSeconds(soundDuration);
        objectToSet.SetActive(false);
        trigger.SetActive(false);


    }
}
