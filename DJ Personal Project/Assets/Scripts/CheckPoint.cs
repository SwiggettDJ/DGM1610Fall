using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 pos;
    public int nextPar;
    public int order;

    private void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}