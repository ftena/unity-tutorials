using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Required variables
    // old variable: public float speed = 15.0f;    
    public float turnSpeed = 35.0f;
    public float horizontalInput = 0.0f;
    public float forwardInput = 0.0f;

    [SerializeField] private float horsePower = 10.0f;
    private Rigidbody playerRb;
    [SerializeField] private float speed = 0.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    /* We use FixedUpdate instead of Update because it's
     * better to do movement and physics.
     */
    void FixedUpdate()
    {
        // We get the player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

           // Move the vehicle forward 
           // before adding the speedometer: transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
           //playerRb.AddRelativeForce(Vector3.right * horsePower * forwardInput); // Adds force relative to its coordinate system.
           // To slide: transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);       
           // But we want to turn the vehicle (Vector3.up == y axis)
           playerRb.AddRelativeForce(Vector3.forward * turnSpeed * horizontalInput);
    }
}
