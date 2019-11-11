using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(posX, 0, posZ);
        return randomPos;
    }
}
