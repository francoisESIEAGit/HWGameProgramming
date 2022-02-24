using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpFlashlight : MonoBehaviour
{
    public GameObject player;
    public float distance; // distance the player has to reach to take the gun
    public GameObject flashlight; // the door we want to open 
    public AudioSource takeItemSong; // sound played when we take the gun
    public GameObject actionDisplay; // display the key to take the gun
    public GameObject actionText; // display the text open the door
    
    // Update is called once per frame 
    void Update()
    {
        distance = PlayerRayCast.distanceFromTarget;


    }

    void OnMouseOver()
    {
        //Debug.Log("Mouse is over GameObject.");
        if (distance <= 2.5f) // if the player is close to the door //
        {
            actionDisplay.SetActive(true); // display the key to open the door and the text //
            actionText.GetComponent<Text>().text = "Pick Up the Flashlight";
            actionText.SetActive(true);


        }
        if (Input.GetButtonDown("Action")) // if the player is close to the door and press E it will open the door //
        {
            if (distance <= 2.5f) // if the distance between the player and the door is inferior to 2.5 //
            {
                // disabling the door trigger box collider 
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                takeItemSong.Play();
                flashlight.SetActive(false);
                player.GetComponent<Flashlight>().hasFlashLight = true;

            }
        }
    }
    void OnMouseExit()
    {
        actionDisplay.SetActive(false); // display the key to open the door and the text //
        actionText.SetActive(false);
    }
}
