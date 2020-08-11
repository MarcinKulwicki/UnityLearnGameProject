using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllFreeCamera : MonoBehaviour
{
    [SerializeField]

    private Transform objectToFollow;

    
    private void LateUpdate() 
    {
        transform.position = objectToFollow.position;

        if(Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.position, Vector3.down , 1f);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(transform.position, Vector3.up , 1f);
        }
    }
}
