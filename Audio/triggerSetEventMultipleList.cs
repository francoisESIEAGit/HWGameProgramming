using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSetEventMultipleList : MonoBehaviour
{
    public List<GameObject> objectToSet;
    public GameObject trigger;
    public float Duration;
    public bool setForever = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(SetEvent());
        }
    }


    IEnumerator SetEvent()
    {
        int nbEvents = objectToSet.Count;

        for(int i = 0; i < nbEvents; i++)
        {
            objectToSet[i].SetActive(true);
        }

        yield return new WaitForSeconds(Duration);

        if(!setForever)
        {
            for (int i = 0; i < nbEvents; i++)
            {
                objectToSet[i].SetActive(false);
            }

            trigger.SetActive(false);
        }
        


    }
}
