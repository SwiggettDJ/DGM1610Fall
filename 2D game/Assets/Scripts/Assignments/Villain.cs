using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    string villainName = "Vilgax";
    int age = 1000;
    float height = 8.2f;
    bool masterOfTheUniverse = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(villainName);
        Debug.Log(age);
        Debug.Log(height);
        Debug.Log(masterOfTheUniverse);
    }
}
