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
    [SerializeField] List<WheelCollider> allWheels;

    [SerializeField] private float horsePower = 0.0f;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] private float rpm = 0.0f;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // set the center of mass to the position of the centerOfMass object
        playerRb.centerOfMass = centerOfMass.transform.position; 
    }

    private void Update()
    {
        if (IsOnGround())
        {
            // Update speedometer text
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for hph
            speedometerText.SetText("Speed: " + speed + " mph");

            // Update rpm text
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    /* We use FixedUpdate instead of Update because it's
     * better to do movement and physics.
     */
    void FixedUpdate()
    {
        // We get the player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
           // Move the vehicle forward 
           // before adding the speedometer: transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
           playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput); // Adds force relative to its coordinate system.
           // To slide: transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);       
           // But we want to turn the vehicle (Vector3.up == y axis)
           transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
