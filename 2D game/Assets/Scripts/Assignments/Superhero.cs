using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superhero : MonoBehaviour
{
    string heroName = "Spider-Man";
    int age = 18;
    int height = 6;
    string powers = "Web slinging/wall crawling.";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(heroName);
        Debug.Log(age);
        Debug.Log(height);
        Debug.Log(powers);
    }
}
