using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript; // reference to the desired script
    public float speed = 30;
    private float leftBound = -15; // left boundary

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.introFinished)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * playerControllerScript.dashSpeed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
