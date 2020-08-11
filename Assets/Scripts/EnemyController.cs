using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float forceMovement = 5.0f;

    Transform target = null;

    List<Transform> fokesPos = new List<Transform>();

    Rigidbody rb;

    FOVDetection fov;

    Transform playerTransform;
    void Start()
    {
        fokesPos = GameManager.Instance.GetFokesPosition();
        rb = GetComponent<Rigidbody>();
        fov = GetComponent<FOVDetection>();
        playerTransform = GameManager.Instance.Player.transform;
    }
    void Update()
    {
        if(target == null)
        {
            CheckDistanceFromFokes();

            if(FOVDetection.inFOV(transform, playerTransform, 45.0f, 20.0f) && playerTransform.tag.ToLower() == "player")
            {
                target = playerTransform;
            }
        }
        else
        {
            Attack(target);
        }
            
    }

    private void CheckDistanceFromFokes()
    {
        foreach (Transform foke in fokesPos)
        {
            float distanceFromFoke = Vector3.Distance(transform.position, foke.position);

            if (distanceFromFoke <= 25.0f)
            {
                if(foke.tag == "foke") //Attack only alive foke
                {
                    target = foke;
                    return;
                }
            }
        }
    }

    private void Attack(Transform target)
    {
        transform.LookAt(target);

        rb.AddRelativeForce(Vector3.forward * Time.deltaTime * forceMovement, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        target = null;
    }
}
