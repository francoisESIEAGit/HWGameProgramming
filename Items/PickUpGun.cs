using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // recognize UI elements;

public class PickUpGun : MonoBehaviour
{
    public float distance; // distance the player has to reach to take the gun
    public GameObject gun; // the door we want to open 
    public AudioSource takeItemSong; // sound played when we take the gun
    public GameObject actionDisplay; // display the key to take the gun
    public GameObject playerGun; //
    public GameObject actionText; // display the text open the door
    public GameObject pistolDot; // display the text open the door
    public GameObject TriggerSirene;
    public GameObject AmmoUi;
    // Update is called once per frame 
    void Update()
    {
        distance = PlayerRayCast.distanceFromTarget;


    }

    void OnMouseOver ()
    {
        //Debug.Log("Mouse is over GameObject.");
        if (distance <= 2.5f) // if the player is close to the door //
        {
            actionDisplay.SetActive(true); // display the key to open the door and the text //
            actionText.GetComponent<Text>().text = "Pick Up Makarov Pistol";
            actionText.SetActive(true);


        }
        if(Input.GetButtonDown("Action")) // if the player is close to the door and press E it will open the door //
        {
            if(distance <= 2.5f) // if the distance between the player and the door is inferior to 2.5 //
            {
                // disabling the door trigger box collider 
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                takeItemSong.Play();
                gun.SetActive(false);
                AmmoUi.SetActive(true);
                playerGun.SetActive(true);
                playerGun.GetComponent<Animator>().Play("get_pistol_anim");
                pistolDot.SetActive(true);

                PlayerFirePistol.hasGun = true; // the player get the gun
                TriggerSirene.SetActive(true);




            }
        }
    }
    void OnMouseExit()
    {
        actionDisplay.SetActive(false); // display the key to open the door and the text //
        actionText.SetActive(false);
    }
}
