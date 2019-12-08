using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boncer : MonoBehaviour
{
    private Rigidbody player;
    public Transform target;
    private Vector3 launch;
    // Start is called before the first frame update
    void Start()
    {
        launch = target.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Rigidbody>();
            player.velocity = new Vector3(0, 0, 0);
            player.AddForce(launch, ForceMode.VelocityChange);
        }
    }
}
