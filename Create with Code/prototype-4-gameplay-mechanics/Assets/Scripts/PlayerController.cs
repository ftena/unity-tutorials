using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Powerups {None, Powerup, Rocket, Smash};    
    public float speed = 5.0f;
    public GameObject powerupIndicator;
    public GameObject rocket;
    public GameObject[] shotSpawns;
    public float fireRate;
    private float nextFire;
    private Powerups kindOfPowerup;
    private Rigidbody playerRb;
    private GameObject focalPoint; // to move in the direction the camera and focal point are facing
    private float powerupStrength = 10.0f;
    private Vector3 powerupIndicatorOffset;
    private Vector3[] shotSpawnOffsets;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicatorOffset = powerupIndicator.transform.position;
        shotSpawnOffsets = new Vector3[shotSpawns.Length];

        for (int i = 0; i < shotSpawns.Length; ++i)
        {
            shotSpawnOffsets[i] = shotSpawns[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Set the powerup indicator as the same as the player position
        powerupIndicator.transform.position = transform.position + powerupIndicatorOffset;
        
        // Set the shot spawn as the same as the player position
        for (int i = 0; i < shotSpawns.Length; ++i)
        {
            shotSpawns[i].transform.position = transform.position + shotSpawnOffsets[i];
        }

        if (Input.GetButton ("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;

            for (int i = 0; i < shotSpawns.Length; ++i)
            {
                Instantiate(rocket, shotSpawns[i].transform.position, shotSpawns[i].transform.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            kindOfPowerup = Powerups.Powerup;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdowRoutine());
        }
        if(other.CompareTag("RocketPowerup"))
        {
            kindOfPowerup = Powerups.Rocket;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);


            StartCoroutine(PowerupCountdowRoutine());
        }
        if(other.CompareTag("SmashPowerup"))
        {
            kindOfPowerup = Powerups.Smash;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdowRoutine());
        }
    }

    IEnumerator PowerupCountdowRoutine()
    {
        // WaitForSeconds can only be used with a yield statement in coroutines.
        yield return new WaitForSeconds(7);
        // After the required seconds...
        kindOfPowerup = Powerups.None;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")  && kindOfPowerup == Powerups.Powerup)
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemy.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // 'Impulse' addd the force immediately
        }
    }
}
