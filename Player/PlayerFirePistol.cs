using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFirePistol : MonoBehaviour
{
    public static bool hasGun = false;
    public GameObject playerGun;
    public AudioSource fireGunFX;
    public AudioSource emptyGunFX;
    public AudioSource reloadGunFX;
    public GameObject muzzleFlash;
    public int ammo = 0;
    public int magazineAmmo;
    public bool isFiring = false;
    public bool isReloading = false;
    public float targetDistance;
    public int damageAmount = 1000;
    int ammoTMP;
    public GameObject uiAmmoDisplay;

   void Start()
    {
        if (ammo <= 10)
        {
            magazineAmmo = 10;
            uiAmmoDisplay.GetComponent<Text>().text = magazineAmmo.ToString() + "/0";


        }
        if (ammo > 10)
        {
            ammoTMP = ammo - 10;
            magazineAmmo = 10;
            ammo = ammo - 10;
            uiAmmoDisplay.GetComponent<Text>().text = magazineAmmo.ToString() + "/" + ammoTMP.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        uiAmmoDisplay.GetComponent<Text>().text = magazineAmmo.ToString() + "/"+ammoTMP.ToString();

        if (Input.GetButtonDown("Fire1")) // if we press the left mouse button
        {
            if(!isFiring && !isReloading) // if the gun is not firing it can fire
            {
                StartCoroutine(gunFire());
            }
            
        }

        if(Input.GetButtonDown("Reloading")) // if we press the left mouse button
        {
            if (!isFiring && !isReloading) // if the gun is not firing it can fire
            {
                StartCoroutine(gunReload());
            }

        }


    }

    IEnumerator gunFire()
    {
        RaycastHit Shot;
        isFiring = true; // the gun is firing now 
        
        if(hasGun && magazineAmmo > 0) // if the player has the gun and there is ammo then he can shoot
        {

            // raycast to create the bullet
            if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot))
            {

                targetDistance = Shot.distance;
                Shot.transform.SendMessage("damageMonster", damageAmount,SendMessageOptions.DontRequireReceiver);
            }

            muzzleFlash.SetActive(true); // turn on the light when the gun is firing
            playerGun.GetComponent<Animator>().Play("pistol_shot_anim");
            fireGunFX.Play(); // play the sound
            magazineAmmo = magazineAmmo - 1;
            
        }

        if(hasGun && magazineAmmo <= 0) // if the player has the gun but no ammo then 
        {
            magazineAmmo = 0; // to avoid negatives values
            emptyGunFX.Play(); // play empty sound
            playerGun.GetComponent<Animator>().Play("pistol_shot_anim");

        }

        yield return new WaitForSeconds(0.5f); // we wait for half a second;
        muzzleFlash.SetActive(false);
        isFiring =false; // we can shoot again 
    }

    IEnumerator gunReload()
    {
        isReloading = true;

        if(ammo>0)
        {
            if (hasGun)
            {
                playerGun.GetComponent<Animator>().Play("reload_pistol_anim");
                reloadGunFX.Play(); // play the sound
                                    // add something to get new ammo;
               
            
            }
            yield return new WaitForSeconds(0.5f);
            if(magazineAmmo == 0)
            {
                ammo = ammo - 10;
                ammoTMP = ammo;
                magazineAmmo = 10;

            }
            if(magazineAmmo > 0)
            {
                int nbOfBullet = 10 - magazineAmmo;
                ammo = ammo - nbOfBullet;
                ammoTMP = ammo;
                magazineAmmo = 10;
            }
           
            isReloading = false;
        }
        

    }
}
