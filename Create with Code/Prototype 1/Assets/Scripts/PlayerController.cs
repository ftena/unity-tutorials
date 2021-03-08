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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We get the player input
       horizontalInput = Input.GetAxis("Horizontal");
       forwardInput = Input.GetAxis("Vertical");

       // Move the vehicle forward 
       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       // To slide: transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);       
       // But we want to turn the vehicle (Vector3.up == y axis)
       transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
