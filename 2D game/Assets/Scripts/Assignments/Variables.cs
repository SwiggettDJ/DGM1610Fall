using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    string myName = "DJ";
    int age = 40;
    float height = 5.11f;
    bool married = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myName);
        Debug.Log(age);
        Debug.Log(height);
        Debug.Log(married);
    }

}
