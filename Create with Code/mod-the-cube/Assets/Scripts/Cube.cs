using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        // Rotate to one way or another depending on the left/right arrow keys        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(20.0f * Time.deltaTime * horizontalInput, 0.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space)) {
            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);

            Renderer.material.color = new Color(r, g, b, 0.4f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.localScale += Vector3.one * 1.1f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.localScale -= Vector3.one * 1.1f;
        }
    }
}
