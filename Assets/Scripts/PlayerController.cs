using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 100;

    private bool isAlive;

    private int weaponCount;

    private float horizontalForce = 0;

    private float verticalForce = 0;

    private Rigidbody rb;

    float multipler;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponCount = 0;
        isAlive = true;
        multipler = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.LookAt(GameManager.Instance.GetWhereToLookAt); //Need to look at point to have good stering

        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            multipler = 4.0f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            multipler = 1.0f;
        }

         //Need to look at point to have good stering
        if(!isAlive) return;
        horizontalForce = Input.GetAxis("Horizontal");
        verticalForce = Input.GetAxis("Vertical");

        rb.AddRelativeForce(Vector3.forward * verticalForce * Time.deltaTime * force *  multipler);
        rb.AddRelativeForce(Vector3.right * horizontalForce * Time.deltaTime * force *  multipler);

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag.ToLower() == "weapon")
        {
            weaponCount++;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag.ToLower() == "enemy")
        {
            if(weaponCount == 0)
            {
                isAlive = false;
                gameObject.tag = "dead_player";
            }
            else
            {
                weaponCount--;
                Destroy(other.gameObject);
            }
        }
    }
}
