﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -47;
    private float bottomLimit = -7;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position is less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
