using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
            {
                body.AddForce(transform.forward * speed);
            }
        if (Input.GetAxis("Horizontal") < 0)
        {
            body.AddForce(transform.forward * -speed);
        }
    }
}
