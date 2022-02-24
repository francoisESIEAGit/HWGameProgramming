using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // recognize UI elements;

public class OpenDoor : MonoBehaviour
{
    
    public bool TryOpening = false;
    public GameObject triggerToCloseTheDoor;
    public float distance; // distance the player has to reach to open the door
    public GameObject door; // the door we want to open 
    public AudioSource lockedDoorSound; // sound played when we open a door
    public AudioSource OpenDoorSound; // sound played when we open a door
    public GameObject actionDisplay; // display the key to open the door
    public GameObject actionText; // display the text open the door
    // Update is called once per frame 
    void Update()
    {
        distance = PlayerRayCast.distanceFromTarget;


    }

    void OnMouseOver ()
    {
        bool isLocked = door.GetComponent<Door>().isLocked;
        bool needAkey = door.GetComponent<Door>().needAkeyToOpen;

        //Debug.Log("Mouse is over GameObject.");
        if (distance <= 1.0f && !TryOpening) // if the player is close to the door //
        {
            actionDisplay.SetActive(true); // display the key to open the door and the text //
            actionText.GetComponent<Text>().text = "OpenTheDoor";
            actionText.SetActive(true);
           
        }
        if(Input.GetButtonDown("Action")) // if the player is close to the door and press E it will open the door //
        {
            if(distance <= 2.5f) // if the distance between the player and the door is inferior to 2.5 //
            {

                if(!isLocked) // if the door is unlocked
                {
                    
                    // disabling the door trigger box collider 
                    this.GetComponent<BoxCollider>().enabled = false;
                    actionDisplay.SetActive(false);
                    actionText.SetActive(false);
                    OpenDoorSound.Play();
                    door.GetComponent<Animator>().SetBool("doorOpening", true);
                    triggerToCloseTheDoor.SetActive(true);
                    triggerToCloseTheDoor.GetComponent<BoxCollider>().enabled = true;

                }
                
                if(isLocked && !TryOpening && !needAkey)
                {
                    actionDisplay.SetActive(false);

                    TryOpening = true;
                    StartCoroutine(LockedDoor());
                    
                }

                if (isLocked && !TryOpening && needAkey)
                {
                    actionDisplay.SetActive(false);
                    
                    TryOpening = true;
                    StartCoroutine(LockedDoorNeedAKey());

                }

                //door.GetComponent<Animator>().SetBool("doorOpening", false);
            }
        }
    }
    void OnMouseExit()
    {
        actionDisplay.SetActive(false); // display the key to open the door and the text //
        actionText.SetActive(false);
    }

    IEnumerator LockedDoor()
    {
        actionDisplay.SetActive(false);
        lockedDoorSound.Play();
        actionText.GetComponent<Text>().text = "it's seem the door cannot be open ";
        door.GetComponent<Animator>().SetBool("doorOpening", true);
        yield return new WaitForSeconds(2.5f);
        door.GetComponent<Animator>().SetBool("doorOpening",false);
        TryOpening = false;
        
    }

    IEnumerator LockedDoorNeedAKey()
    {
        string keyName = door.GetComponent<Door>().KeyName;
        actionDisplay.SetActive(false);
        lockedDoorSound.Play();
        actionText.GetComponent<Text>().text = "i need the " + keyName + " key to open the door";
        door.GetComponent<Animator>().SetBool("doorOpening", true);
        yield return new WaitForSeconds(2.5f);
        door.GetComponent<Animator>().SetBool("doorOpening", false);
        TryOpening = false;
    }
}
