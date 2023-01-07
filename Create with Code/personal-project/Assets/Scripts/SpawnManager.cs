using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesObj;
    public GameObject powerup;
    private float xSpawnRange = 19.0f;
    private float zPowerupRange = 7.0f;
    private float zEnemySpawn = 27.0f;
    public int waveNumber = 1;
    private int enemyCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        Spawn();
    }

    void Spawn()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // look for all the different objects in our scene

        if (enemyCount == 0)
        {
            waveNumber++;
            // ABSTRACTION
            SpawnEnemyWave(waveNumber);
            // ABSTRACTION
            SpawnPowerup();
        }
    }

    void SpawnEnemyWave(int enemies)
    {
        for (int i = 0; i < enemies; ++i)
        {
            Vector3 randomPos = GenerateSpawnPosition();
            int randomEnemyIndex = Random.Range(0, enemiesObj.Length);

            Instantiate(enemiesObj[randomEnemyIndex], randomPos, enemiesObj[randomEnemyIndex].transform.rotation);
        }
    }

    void SpawnPowerup()
    {

        float spawnPosX = Random.Range(-xSpawnRange, xSpawnRange);
        float spawnPosZ = Random.Range(-zPowerupRange, zPowerupRange);
        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);

        Instantiate(powerup, randomPos, powerup.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, zEnemySpawn);

        return randomPos;
    }
}
