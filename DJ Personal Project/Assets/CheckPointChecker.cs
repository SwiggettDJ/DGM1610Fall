using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointChecker : MonoBehaviour
{
    private PlayerController player;
    public CheckPoint lastCheckPoint;
    public int par;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        foreach (GameObject test in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {
            if (test.GetComponent<CheckPoint>().order == 1)
            {
                lastCheckPoint = test.GetComponent<CheckPoint>();
                foreach (GameObject secondTest in GameObject.FindGameObjectsWithTag("CheckPoint"))
                {
                    if (secondTest.GetComponent<CheckPoint>().order == lastCheckPoint.order + 1)
                    {
                        //turn on next checkpoint
                        secondTest.GetComponent<CheckPoint>().toggle = true;
                    }
                }
            }
        }
        transform.position = lastCheckPoint.pos;
        par = lastCheckPoint.nextPar;
        player.parText.text = "Par: " + par;
        player.parHighlightText.text = "Par: " + par;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check(Collider other)
    {
        //Makes the new checkpoint the current one and activates the next one in the order
        lastCheckPoint = other.GetComponent<CheckPoint>();
        //turn the collided checkpoint off
        lastCheckPoint.toggle = true;
        foreach (GameObject test in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {
            if (test.GetComponent<CheckPoint>().order == lastCheckPoint.order + 1)
            {
                //turn next checkpoint on
                test.GetComponent<CheckPoint>().toggle = true;
            }
        }
    }

}
