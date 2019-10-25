using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCameraController : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public float sensitivityX = 1f;
    public float sensitivityY = 1.8f;
    public Transform target;
    public Transform player;
    private float xAxis, yAxis;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (Input.GetAxis("Forward") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            player.rotation = Quaternion.Euler(0, xAxis, 0);
        }

        if (playerControllerScript.playerDeath == true)
        {
            xAxis = 0;
            yAxis = 0;
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
