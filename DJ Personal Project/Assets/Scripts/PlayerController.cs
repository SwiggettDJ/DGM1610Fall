using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forSpeed, horSpeed;
    private float slipSpeed, ogSpeed, groundSpeed;
    private float forward, horizontal;
    private float slipMultiplier = 5f;
    private float groundMultiplier = 1.8f;
    private float nextJump = 0.0f;
    private float interval = 0.3f;

    private CheckPoint lastCheckPoint;

    public Rigidbody body;
    public float jumpHeight = 35;
    public Transform cameraTarget;
    public bool playerDeath;


    private void Start()
    {
        //Sets groundSpeed and slipSpeed using the multiplier and the public forSpeed. These are the speeds you will be set to while on the ground or a slippery slope
        groundSpeed = forSpeed * groundMultiplier;
        slipSpeed = forSpeed * slipMultiplier;
        //Need an original speed to return to
        ogSpeed = forSpeed;

        playerDeath = false;

        foreach(GameObject test in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {
            if(test.GetComponent<CheckPoint>().order == 1)
            {
                lastCheckPoint = test.GetComponent<CheckPoint>();
            }
        }
        
        transform.position = lastCheckPoint.pos;
    }
    // Update is called once per frame
    void Update()
    {
        TooHigh();
        //So player can't move while respawning
        if (playerDeath == false)
        {
            PlayerMovement();
        }

        //playerDeath gets set to false again here instead of in OnCollision because this is the only way for the 
        //camera controller to see that playerDeath is true so it can reset to (0 0 0)
        playerDeath = false;
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
        if (Input.GetKeyDown("space") && Time.time > nextJump)
        {
            //makes it so jump can only be pressed every interval
            nextJump = Time.time + interval;
            body.AddRelativeForce(new Vector3(0, 1, 0) * jumpHeight);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            forSpeed = groundSpeed;
        }
        else if (collision.gameObject.CompareTag("Slippery"))
        {
            forSpeed = slipSpeed;
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            KillPlayer();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Whenever you're in the air your speed goes back to normal
            forSpeed = ogSpeed;
    }

    //makes sure you don't try to fly too high... will probably put left and right bounds here too
    private void TooHigh()
    {
        if(body.transform.position.y > 25)
        {
            body.transform.position = new Vector3(body.transform.position.x, 25, body.transform.position.z);
            body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
        }
        if (body.transform.position.y < -5)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        //resets player position to last checkpoint
        playerDeath = true;
        body.velocity = new Vector3(0, 0, 0);
        transform.position = lastCheckPoint.pos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            lastCheckPoint = other.GetComponent<CheckPoint>();
        }
    }
}
