using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the position
        if (transform.position.x <= -1.509f)
        {
            transform.position = transform.position + new Vector3(movement.x * speed, 0, movement.z * speed);
        } else
        {
            //Destroy(gameObject);
        }

    }
}
