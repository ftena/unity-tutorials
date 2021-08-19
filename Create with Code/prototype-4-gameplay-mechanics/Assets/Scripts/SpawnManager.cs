using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // to spawn new enemies
    public GameObject powerupPrefab; // to spawn new power ups
    public int enemyCount; // track the number of enemies
    public int waveNumber = 1;
    private int randomPosX = 9;
    private int randomPosZ = 9;
    

    // Start is called before the first frame update
    void Start()
    {
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // look for all the different objects in our scene

        if(enemyCount == 0)
        {            
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemies)
    {
        for (int i = 0; i < enemies; ++i)
        {
            Vector3 randomPos = GenerateSpawnPosition();
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-randomPosX, randomPosX);
        float spawnPosZ = Random.Range(-randomPosZ, randomPosZ);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
