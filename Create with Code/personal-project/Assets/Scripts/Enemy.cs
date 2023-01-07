using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Animal // INHERITANCE
{
    public float speed = 5.0f;
    private Rigidbody objectRb;
    private float zDestroy = -23.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move() // POLYMORPHISM
    {
        objectRb.AddForce(Vector3.forward * -speed, ForceMode.Impulse);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        } 
    }
}
