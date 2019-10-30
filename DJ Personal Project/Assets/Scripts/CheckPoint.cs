using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 pos;
    public int nextPar;
    public int order;

    private ParticleSystem blueParticles;
    private Light blueLight;

    private void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z);
        blueLight = gameObject.GetComponent<Light>();
        blueParticles = gameObject.GetComponent<ParticleSystem>();
    }
}