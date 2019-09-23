using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 10;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime);
    }
}
