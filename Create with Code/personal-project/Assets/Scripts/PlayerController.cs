using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float zBound = 7.0f;
    // If using physics, declare a new Rigidbody playerRb variable for it and initialize it in Start()
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player based on arrow key input
        MovePlayer();

        // Prevent the player from leaving the top or bottom of the screen
        ConstrainPlayerMovement();
    }

    void MovePlayer()
    {
        /* Notes:
        a) If using arrow keys, declare new verticalInput and/or horizontalInput variables 
        b) If basing your movement off a key press, create the if-statement to test for the KeyCode
        c) Use either the Translate method or AddForce method (if using physics) to move your character
        */

        // We'll get from the input manager the x and y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        // Try this!: transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ConstrainPlayerMovement()
    {
        // The  Player cannot go off the screen. Check and reset the position if necessary.
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}
