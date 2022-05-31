using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Required variables
    public float speed = 15.0f;
    public float turnSpeed = 35.0f;
    public float horizontalInput = 0.0f;
    public float forwardInput = 0.0f;
    [SerializeField] private float horsePower = 0.0f;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // set the center of mass to the position of the centerOfMass object
        playerRb.centerOfMass = centerOfMass.transform.position; 
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
       playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput); // Adds force relative to its coordinate system.
       // To slide: transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);       
       // But we want to turn the vehicle (Vector3.up == y axis)
       transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
