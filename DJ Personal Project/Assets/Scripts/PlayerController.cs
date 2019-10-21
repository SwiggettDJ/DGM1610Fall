using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public Rigidbody body;
    public Transform cameraTarget;
    private float forward, horizontal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        body.angularVelocity = new Vector3(0, 0, 0);
        forward = Input.GetAxis("Forward");
        horizontal = Input.GetAxis("Horizontal");

        if (forward != 0)
        {
            body.AddRelativeForce(Vector3.forward * forward * speed * Time.deltaTime);
        }
        if (horizontal != 0)
        {
            body.AddRelativeForce(Vector3.right * horizontal * speed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown("space"))
        {
            body.AddRelativeForce(new Vector3(0,1,0) * jumpHeight);
        }
    }
}
