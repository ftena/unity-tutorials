﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup = false; // to control if the player has the powerup
    private Rigidbody playerRb;
    private GameObject focalPoint; // to move in the direction the camera and focal point are facing
    private float powerupStrength = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
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
