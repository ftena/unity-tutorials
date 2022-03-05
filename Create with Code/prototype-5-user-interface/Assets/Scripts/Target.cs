using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float randomMinForce = 12.0f;
    private float randomMaxForce = 16.0f;
    private float randomTorque = 10.0f;
    private float randomX = 4.0f;
    private float randomY = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(Vector3.up * Random.Range(randomMinForce, randomMaxForce), ForceMode.Impulse);

        // AddTorque applies the rotation
        targetRb.AddTorque(Random.Range(-randomTorque, randomTorque), Random.Range(-randomTorque, randomTorque), Random.Range(-randomTorque, randomTorque), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-randomX, randomX), -randomY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
