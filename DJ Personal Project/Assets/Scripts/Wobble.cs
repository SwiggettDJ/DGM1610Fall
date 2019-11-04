using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    public bool vert;
    public int max;
    public int min;
    private bool down = false;
    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > max) down = true;
        if (transform.position.y < min) down = false;

        if (transform.position.x > max) left = true;
        if (transform.position.x < min) left = false;

        if (vert)
        {
            if (down)
            {
                transform.Translate(new Vector3(0, Random.Range(.1f, .5f) * Time.deltaTime,0));
            }
            else
            {
                transform.Translate(new Vector3(0, Random.Range(-.1f, -.5f) * Time.deltaTime,0));
            }
        }
        
        if(!vert)
        {
            if (left)
            {
                transform.Translate(new Vector3(Random.Range(-.1f, -.5f) * Time.deltaTime, 0 ,0));
            }
            else
            {
                transform.Translate(new Vector3(Random.Range(.1f, .5f) * Time.deltaTime,0 ,0));
            }
        }
        
        
    }
}
