using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour
{
    public float speed = 2.5f;
    public float rotspeed = 25.0f;

    private bool  isWandering = false;
    private bool isWalking = false;
    private bool isRotatingLeft = false;
    private bool  isRotatingRight = false;
    public GameObject visionField;
    public bool canWalk = true;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool PlayerGetCaught = visionField.GetComponent<sirenAI>().playerGetCaught;

        if(canWalk)
        {
            if (!PlayerGetCaught)
            {
                if (!isWandering)
                {
                    StartCoroutine(Wander());
                }
                if (isRotatingRight)
                {
                    transform.Rotate(transform.up * Time.deltaTime * rotspeed);
                }
                if (isRotatingLeft)
                {
                    transform.Rotate(transform.up * Time.deltaTime * -rotspeed);
                }
                if (isWalking)
                {
                    transform.position += transform.forward * speed * Time.deltaTime;
                    this.GetComponent<Animator>().Play("walk");
                }
                if (!isWalking)
                {
                    this.GetComponent<Animator>().Play("test");
                }
            }
            if(!canWalk)
            {
                this.GetComponent<Animator>().Play("test");
            }
        }
        
        
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1,4);
        int rotateLoR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLoR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;

        }
        if (rotateLoR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;




    }
}
