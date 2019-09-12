using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float angle = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //makes the vehicle move
        if (Input.GetAxisRaw("forward") == 1)
        {
            transform.Translate(Vector3.forward * Time.fixedUnscaledDeltaTime * 20);
        }
        if (Input.GetAxisRaw("horizontal") == 1)
        {
            //transform.Translate(Vector3.right * Time.fixedUnscaledDeltaTime * 10);
            transform.Rotate(0, angle * Time.fixedUnscaledDeltaTime, 0);
        }
        if (Input.GetAxisRaw("horizontal") == -1)
        {
            //transform.Translate(Vector3.left * Time.fixedUnscaledDeltaTime * 10);
            transform.Rotate(0, -angle * Time.fixedUnscaledDeltaTime, 0);
        }
    }
}
