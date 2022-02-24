using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CloseDoor : MonoBehaviour
{
    public GameObject triggerToOpenTheDoor;
    public float distance; // distance the player has to reach to open the door
    public GameObject door; // the door we want to open
    public AudioSource CloseDoorSound;
    //public AudioSource openDoorSound; // sound played when we open a door
    public GameObject actionDisplay; // display the key to open the door
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
            actionText.GetComponent<Text>().text = "Close The Door";
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
                CloseDoorSound.Play();
                door.GetComponent<Animator>().SetBool("doorOpening", false);
                triggerToOpenTheDoor.SetActive(true);
                triggerToOpenTheDoor.GetComponent<BoxCollider>().enabled = true;

            }
        }
    }
    void OnMouseExit()
    {
        actionDisplay.SetActive(false); // display the key to open the door and the text //
        actionText.SetActive(false);
    }
}
