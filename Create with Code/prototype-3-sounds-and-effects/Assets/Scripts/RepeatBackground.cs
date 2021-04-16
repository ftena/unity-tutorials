using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // we use the size of the BoxCollider to get the width for this GameObject
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.x < startPos.x - repeatWidth) 
       {
           transform.position = startPos;
       }
    }
}
