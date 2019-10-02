using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMangager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15f;
    private float spawnPosZ = 33f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnAnimal", startDelay, spawnInterval);
    }

    void spawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
