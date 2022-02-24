using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public  int currentHealth = 100;
    public int internalHealth;
    public AudioSource screamPlayer;
    public GameObject gameOverFadeScreen;
    public AudioSource playerFright;
    public GameObject lifePointDisplay;
    public GameObject ammoDisplay;


    // Update is called once per frame
    void Update()
    {
        internalHealth = currentHealth;
        lifePointDisplay.GetComponent<Text>().text = currentHealth.ToString();
        if (internalHealth <=0)
        {
            playerFright.Stop();
            screamPlayer.Play();
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {

        gameOverFadeScreen.SetActive(true);

        this.enabled = false;
        this.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(2.0f);
        ammoDisplay.SetActive(false);
        lifePointDisplay.SetActive(false);

        SceneManager.LoadScene("gameOver");
        // do the game over screen
    }
}
