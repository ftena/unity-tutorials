using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemiesPrefabs; // to spawn new enemies
    public GameObject bossPrefab; // to spawn new enemies
    public GameObject[] powerupPrefabs; // to spawn new power ups
    public int enemyCount; // track the number of enemies
    public int waveNumber = 1;
    public int bossLevel = 3;
    private int randomPosX = 9;
    private int randomPosZ = 9;
    

    // Start is called before the first frame update
    void Start()
    {
            SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // look for all the different objects in our scene

        if(enemyCount == 0)
        {            
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            if (waveNumber % bossLevel == 0)
            {
                Vector3 randomPos = GenerateSpawnPosition();
                Instantiate(bossPrefab, randomPos, bossPrefab.transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int enemies)
    {
        int index = Random.Range(0, powerupPrefabs.Length);           
        Instantiate(powerupPrefabs[index], GenerateSpawnPosition(), powerupPrefabs[index].transform.rotation);

        for (int i = 0; i < enemies; ++i)
        {
            index = Random.Range(0, enemiesPrefabs.Length);           
            Vector3 randomPos = GenerateSpawnPosition();
            Instantiate(enemiesPrefabs[index], randomPos, enemiesPrefabs[index].transform.rotation);
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
