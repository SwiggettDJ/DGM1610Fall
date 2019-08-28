using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonCharacter : MonoBehaviour
{
    string characterName = "DeadPool";
    int age = 38;
    float height = 6.1f;
    string favoriteFood = "Chimmechangas";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(characterName);
        Debug.Log(age);
        Debug.Log(height);
        Debug.Log(favoriteFood);
    }
}
