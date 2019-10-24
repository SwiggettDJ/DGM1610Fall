using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forSpeed, horSpeed;
    private float slipSpeed, ogSpeed;
    private float forward, horizontal;
    private float slipMultiplier = 5f;

    public Rigidbody body;
    public float jumpHeight = 35;
    public Transform cameraTarget;
    private bool playerDeath;
    private TrailRenderer trail;

    //Sets the starting pos
    private Vector3 respawnPoint =  new Vector3(0, 1, 0);


    private void Start()
    {
        slipSpeed = forSpeed * slipMultiplier;
        ogSpeed = forSpeed;
        playerDeath = false;
        transform.position = respawnPoint;
        trail = gameObject.GetComponent<TrailRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        //So player can't move while respawning
        if (playerDeath == false)
        {
            PlayerMovement();
        }
        TooHigh();
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
        if (collision.gameObject.CompareTag("Lava"))
        {
            playerDeath = true;
            body.velocity = new Vector3(0, 0, 0);
            transform.position = respawnPoint;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            playerDeath = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slippery"))
        {
            forSpeed = ogSpeed;
        }
    }

    private void TooHigh()
    {
        if(body.transform.position.y > 20)
        {
            body.transform.position = new Vector3(body.transform.position.x, 20, body.transform.position.z);
            body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
        }
    }
}
