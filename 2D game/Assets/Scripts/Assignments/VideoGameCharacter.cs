using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoGameCharacter : MonoBehaviour
{
    string characterName = "Doom Guy";
    int age = 1000000;
    float height = 6.1f;
    string abilities = "Guns, Flamethrower, Chainsaw, Dash, Glory Kill, Super Punch";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(characterName);
        Debug.Log(age);
        Debug.Log(height);
        Debug.Log(abilities);
    }
}
