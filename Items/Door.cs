using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked=false;
    public bool needAkeyToOpen;
    public string KeyName;
    public GameObject keyToOpen;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocked && !needAkeyToOpen) // if the door cant be open // 
        {
            this.GetComponent<Animator>().SetBool("isLocked", true);
            keyToOpen = null;
        }
        if(isLocked && needAkeyToOpen) // if the door can be open without a key // 
        {
            this.GetComponent<Animator>().SetBool("isLocked", true);
        }

        if(!isLocked)
        {
            keyToOpen = null;
            needAkeyToOpen = false;
        }
    }
}
