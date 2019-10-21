using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCameraController : MonoBehaviour
{
    public float sensitivityX = 1.2f;
    public float sensitivityY = 1.8f;
    public Transform target;
    public Transform player;
    private float xAxis, yAxis;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetAxis("Forward") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            player.rotation = Quaternion.Euler(0, xAxis, 0);
        }
    }

    void LateUpdate()
    {
        xAxis += Input.GetAxis("Mouse X") * sensitivityX;
        yAxis -= Input.GetAxis("Mouse Y") * sensitivityY;
        yAxis = Mathf.Clamp(yAxis, -60, 50);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(yAxis, xAxis, 0);
    }
}
