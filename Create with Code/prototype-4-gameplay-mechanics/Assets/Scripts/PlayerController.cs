using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Powerups {None, Powerup, Rocket, Smash}; // to control the powerup picked up by the player 
    public float speed = 5.0f; // player speed
    public float jumpForce; // jump force when spacebar is pressed
    public float gravityModifier;
    public GameObject powerupIndicator; // to control the powerup indicator (show/hide)
    public GameObject rocket; // the rocket launched by the player
    public GameObject[] shotSpawns; // the spawns positions for the rockets
    public float fireRate; 
    private float nextFire;
    private bool isOnGround = true; // to prevent double jump 
    private Powerups kindOfPowerup; // to store the current powerup picked up by the player
    private Rigidbody playerRb; 
    private GameObject focalPoint; // to move in the direction the camera and focal point are facing
    private float powerupStrength = 10.0f; // strength for the normal powerup
    private Vector3 powerupIndicatorOffset; // offset position for the powerup indicator
    private Vector3[] shotSpawnOffsets; // offset position for the rocket spawn positions

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Physics.gravity: the gravity applied to all rigid bodies in the Scene.
        Physics.gravity *= gravityModifier;

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

        if (Input.GetButton ("Fire1") && Time.time > nextFire && kindOfPowerup == Powerups.Rocket) {
            nextFire = Time.time + fireRate;

            for (int i = 0; i < shotSpawns.Length; ++i)
            {
                Instantiate(rocket, shotSpawns[i].transform.position, shotSpawns[i].transform.rotation);
            }
        }

        // Make player jump if spacebar pressed
         if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
         {
             playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             isOnGround = false;
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

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
