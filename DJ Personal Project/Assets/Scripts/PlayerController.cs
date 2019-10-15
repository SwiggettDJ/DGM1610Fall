using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        body.angularVelocity = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.transform.Rotate(new Vector3(body.transform.rotation.x, body.transform.rotation.y - 2, body.transform.rotation.z));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.transform.Rotate(new Vector3(body.transform.rotation.x, body.transform.rotation.y + 2, body.transform.rotation.z));
        }
        if (Input.GetKeyDown("space"))
        {
            body.AddRelativeForce(new Vector3(0,1,0) * jumpHeight);
        }
    }
}
