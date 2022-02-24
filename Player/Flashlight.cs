using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool hasFlashLight = false;
    [SerializeField] GameObject flashLight = null;
    private bool isFlashLightActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
        flashLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(hasFlashLight)
            {
                if (isFlashLightActive)
                {
                    flashLight.gameObject.SetActive(false);
                    isFlashLightActive = false;
                }
                else
                {
                    flashLight.gameObject.SetActive(true);
                    isFlashLightActive = true;
                }
            }
            
        }
    }
}
