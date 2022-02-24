using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMap : MonoBehaviour
{

    public bool hasMap = false;
    private bool isMapOpen = false;
    public GameObject map;
    public AudioSource mapOpeningSound;

    // Update is called once per frame
    void Update()
    {

        if(hasMap)
        {
            if(Input.GetButtonDown("Map"))
            {
                if(isMapOpen)
                {
                    map.SetActive(false);
                    isMapOpen = false;
                    this.GetComponent<CharacterController>().enabled = true;
                    mapOpeningSound.Play();

                }
                else
                {
                    mapOpeningSound.Play();
                    map.SetActive(true);
                    isMapOpen = true;
                    this.GetComponent<CharacterController>().enabled = false;
                }
            }
        }
    }
}
