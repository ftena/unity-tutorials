using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private PlayerController playerControllerScript; // reference to the desired script
    private Vector3 spawnPos = new Vector3(25, 0, 0); // spawn position for obstacles
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.introFinished)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPos, obstaclePrefabs[randomIndex].transform.rotation);
        }
    }
}
