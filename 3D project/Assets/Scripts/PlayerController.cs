using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float angle = 30;
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //makes the vehicle move
            transform.Translate(Vector3.forward * Input.GetAxisRaw("forward") * Time.fixedUnscaledDeltaTime * speed);

            transform.Rotate(Vector3.up, angle * Input.GetAxisRaw("horizontal") * Time.fixedUnscaledDeltaTime, 0);
    }
}
