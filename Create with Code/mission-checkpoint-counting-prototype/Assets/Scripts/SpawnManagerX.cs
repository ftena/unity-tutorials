using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitZLeft = -15;
    private float spawnLimitZRight = 15;
    private float spawnPosY = 23;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(0, spawnPosY, Random.Range(spawnLimitZLeft, spawnLimitZRight));

        // instantiate ball at random spawn location
        int randomIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);
    }

}
