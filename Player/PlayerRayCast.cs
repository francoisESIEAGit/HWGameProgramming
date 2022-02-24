using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static float distanceFromTarget; // distance between player and the interactable object //
    public float toTarget;
                                          

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }

    }
}
