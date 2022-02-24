using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // recognize UI elements;

public class PickUpKey : MonoBehaviour
{
    public float distance; // distance the player has to reach to take the key
    public GameObject key; // the key we want to take  
    public AudioSource takeItemSong; // sound played when we take the gun
    public GameObject actionDisplay; // display the key to take the gun
    public GameObject door; // the door that need the key to open
    public GameObject actionText; // display the text open the door

    // Update is called once per frame 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance = PlayerRayCast.distanceFromTarget;


    }
    void OnMouseOver()
    {

        string keyName = door.GetComponent<Door>().KeyName;
        //Debug.Log("Mouse is over GameObject.");
        if (distance <= 2.5f) // if the player is close to the door //
        {
            actionDisplay.SetActive(true); // display the key to open the door and the text //
            actionText.GetComponent<Text>().text = "Pick Up the "+ keyName+" key";
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
                key.SetActive(false);
                door.GetComponent<Animator>().SetBool("isLocked",false);
                door.GetComponent<Door>().isLocked = false;




            }
        }
    }


    void OnMouseExit()
    {
        actionDisplay.SetActive(false); // display the key to open the door and the text //
        actionText.SetActive(false);
    }

}
