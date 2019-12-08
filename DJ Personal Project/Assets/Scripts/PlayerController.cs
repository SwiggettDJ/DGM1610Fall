using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float forSpeed, horSpeed;
    private float slipSpeed, ogSpeed, groundSpeed;
    private float forward, horizontal;
    private float slipMultiplier = 5f;
    private float groundMultiplier = 2f;

    private int maxJumps = 2;
    private int jumps = 0;
    public int totalJumps = -1;

    private CheckPointChecker checkPointChecker;

    public Rigidbody body;
    public float jumpHeight = 35;
    public Transform cameraTarget;
    public bool playerDeath;

    public TextMeshProUGUI jumpsText;
    public TextMeshProUGUI jumpsHighlightText;

    public AudioClip jumpSound;
    private AudioSource playerAudio;


    private void Start()
    {
        setJumps();
        //Sets groundSpeed and slipSpeed using the multiplier and the public forSpeed. These are the speeds you will be set to while on the ground or a slippery slope
        groundSpeed = forSpeed * groundMultiplier;
        slipSpeed = forSpeed * slipMultiplier;
        //Need an original speed to return to
        ogSpeed = forSpeed;

        playerDeath = false;


        checkPointChecker = GameObject.Find("CheckPoint Checker").GetComponent<CheckPointChecker>();
        playerAudio = GetComponent<AudioSource>();
        setJumps(0);
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
        if (Input.GetKeyDown("space") && jumps < maxJumps)
        {
            body.AddRelativeForce(new Vector3(0, 1, 0) * jumpHeight);
            jumps ++;
            setJumps();
            playerAudio.PlayOneShot(jumpSound, .8f);
            StartCoroutine(Flash(jumpsHighlightText));
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
        jumps = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        //Whenever you're in the air your speed goes back to normal
            forSpeed = ogSpeed;
    }

    //makes sure you don't try to fly too high... will probably put left and right bounds here too
    private void TooHigh()
    {
        if(body.transform.position.y > 50)
        {
            body.transform.position = new Vector3(body.transform.position.x, 50, body.transform.position.z);
            body.velocity = new Vector3(body.velocity.x, 0, body.velocity.z);
        }
        if (body.transform.position.y < -10)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        //resets player position to last checkpoint
        playerDeath = true;
        body.velocity = new Vector3(0, 0, 0);
        transform.position = checkPointChecker.lastCheckPoint.pos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        setJumps(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Finds the next checkpoint by seeing which one is active
        if (other.gameObject.CompareTag("CheckPoint") && other.gameObject.GetComponent<CheckPoint>().active)
        {
            //turn the collided checkpoint off
            other.gameObject.GetComponent<CheckPoint>().Toggle();
            //send the collider to CheckPointChecker to be replace lastCheckPoint
            checkPointChecker.Check(other);

            //flash the new score and par
            StartCoroutine(Flash(checkPointChecker.scoreHighlightText));
            StartCoroutine(Flash(checkPointChecker.parHighlightText));
        }
    }

    public void setJumps()
    {
        totalJumps ++;
        jumpsText.text = "Jumps: " + totalJumps;
        jumpsHighlightText.text = "Jumps: " + totalJumps;
    }
    public void setJumps(int jumpsToSet)
    {
        totalJumps = jumpsToSet;
        jumpsText.text = "Jumps: " + totalJumps;
        jumpsHighlightText.text = "Jumps: " + totalJumps;
    }

    private IEnumerator Flash(TextMeshProUGUI flash)
    {
        flash.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        flash.gameObject.SetActive(false);
    }

    
}
