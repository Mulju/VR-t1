using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrabbed : MonoBehaviour
{
    public DistanceGrab distanceGrab;

    private void Update()
    {
        if(distanceGrab.grabbed == false)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
