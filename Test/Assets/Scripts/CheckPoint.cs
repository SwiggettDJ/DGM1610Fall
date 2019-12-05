using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 pos;
    public int nextPar;
    public int order;
    public bool active = false;

    private ParticleSystem blueParticles;
    private Light blueLight;

    private void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z);
        blueLight = GetComponentInChildren<Light>();
        blueParticles = GetComponentInChildren<ParticleSystem>();
        TurnOff();
    }

    public void TurnOff()
    {
        blueLight.enabled = false;
        blueParticles.Stop();
        active = false;
    }

    public void TurnOn()
    {
        blueLight.enabled = true;
        blueParticles.Play();
        active = true;
    }
}