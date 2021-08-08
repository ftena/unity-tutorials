using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup = false; // to control if the player has the powerup
    public GameObject powerupIndicator;
    private Rigidbody playerRb;
    private GameObject focalPoint; // to move in the direction the camera and focal point are facing
    private float powerupStrength = 10.0f;
    private Vector3 powerupIndicatorOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicatorOffset = powerupIndicator.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Set the powerup indicator as the same as the player position
        powerupIndicator.transform.position = transform.position + powerupIndicatorOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
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
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")  && hasPowerup)
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemy.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // 'Impulse' addd the force immediately
        }
    }
}
