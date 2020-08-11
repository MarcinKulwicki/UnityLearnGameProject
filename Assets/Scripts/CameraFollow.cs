using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;

    public float cameraSpeed = 50.0f;

    private Vector3 posOffset;

    private Quaternion rotationOffset;

    private void Start() 
    {
        posOffset = transform.position;
        rotationOffset = transform.rotation;
    }

    private void LateUpdate() 
    {
        transform.position = new Vector3(objectToFollow.position.x , 0,  objectToFollow.position.z) + posOffset;

        Vector3 lTargetDir = GameManager.Instance.GetWhereToLookAt.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.deltaTime * cameraSpeed);
    }
}
