using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFarmer : MonoBehaviour
{   public float horizontalInput;
    public GameObject projectilePrefab;
    private float speed = 30f;
    private float xRange = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            horizontalInput = 0;
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            horizontalInput = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 0.5f), transform.rotation);
        }
    }
}
