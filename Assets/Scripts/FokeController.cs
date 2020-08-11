using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FokeController : MonoBehaviour
{
    public float force = 1500;

    private float distFromPlayer;

    private Rigidbody rb;

    private bool fokeIsAlive;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        fokeIsAlive = true;
    }

    void Update()
    {
        if(!fokeIsAlive) return;
        distFromPlayer = GameManager.Instance.CalculateDistFromPlayer(transform);

        RunAwayFromPlayer(9.0f);
    }

    void RunAwayFromPlayer(float minDist)
    {
        if(distFromPlayer <= minDist)
        {
            Transform playerTransform = GameManager.Instance.Player.transform;

            transform.LookAt(playerTransform);

            Vector3 rot = transform.rotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(new Vector3(rot.x,rot.y+180,rot.z));

            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * force * (1/distFromPlayer));

            if(distFromPlayer < 5.0f){
                rb.AddRelativeForce(Vector3.forward * Time.deltaTime * 3 * force * (1/distFromPlayer), ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "enemy")
        {
            gameObject.tag = "dead_foke";
            fokeIsAlive = false;
        }
    }
}
