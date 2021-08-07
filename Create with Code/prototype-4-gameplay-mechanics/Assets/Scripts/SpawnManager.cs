﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // to spawn new enemies
    private int randomPosX = 9;
    private int randomPosZ = 9;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPos = GenerateSpawnPosition();
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-randomPosX, randomPosX);
        float spawnPosZ = Random.Range(-randomPosZ, randomPosZ);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
