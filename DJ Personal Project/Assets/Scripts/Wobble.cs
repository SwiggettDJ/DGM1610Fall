using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 16) down = true;
        if (transform.position.y < 14) down = false;

        if (down)
        {
            transform.Translate(new Vector3(0, Random.Range(.1f, .4f) * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, Random.Range(-.1f, -.4f) * Time.deltaTime, 0));
        }
    }
}
