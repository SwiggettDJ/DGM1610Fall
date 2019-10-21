using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forSpeed, horSpeed, slipSpeed, ogSpeed;
    private float slipMultiplier = 5f;
    public float jumpHeight;
    public Rigidbody body;
    public Transform cameraTarget;
    private float forward, horizontal;


    private void Start()
    {
        slipSpeed = forSpeed * slipMultiplier;
        ogSpeed = forSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //Adds forces to the Player's Rigidbody when recieving the corresponding Input
    private void PlayerMovement()
    {
        //Stops the player from rotating because it hit something
        body.angularVelocity = new Vector3(0, 0, 0);

        forward = Input.GetAxis("Forward");
        horizontal = Input.GetAxis("Horizontal");

        //Forward and Horizontal forces applied
        if (forward != 0)
        {
            body.AddRelativeForce(Vector3.forward * forward * forSpeed * Time.deltaTime);
        }
        if (horizontal != 0)
        {
            body.AddRelativeForce(Vector3.right * horizontal * horSpeed * Time.deltaTime);
        }

        //Jump force
        if (Input.GetKeyDown("space"))
        {
            body.AddRelativeForce(new Vector3(0, 1, 0) * jumpHeight);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slippery"))
        {
            forSpeed = slipSpeed;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slippery"))
        {
            forSpeed = ogSpeed;
        }
    }
}
