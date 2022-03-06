using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointsPerEnemy = 0;
    public ParticleSystem explosion;
    private Rigidbody targetRb;
    private GameManager gameManager; // to comunicate with GameManager script
    private float randomMinForce = 12.0f;
    private float randomMaxForce = 16.0f;
    private float randomTorque = 10.0f;
    private float randomXRange = 4.0f;
    private float ySpawnPos = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // AddTorque applies the rotation
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.UpdateScore(pointsPerEnemy);        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // We have a Sensor object in the scene to help us in this case.
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(randomMinForce, randomMaxForce);
    }

    float RandomTorque()
    {
        return Random.Range(-randomTorque, randomTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-randomXRange, randomXRange), -ySpawnPos);

    }
}
