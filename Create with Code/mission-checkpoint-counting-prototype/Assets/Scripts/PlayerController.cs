using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Required variables
    public float speed = 35.0f;

    private float horizontalInput = 0.0f;
    private float forwardInput = 0.0f;
    private Rigidbody playerRb;

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

        playerRb.AddRelativeForce(Vector3.forward * speed * horizontalInput);
    }
}
