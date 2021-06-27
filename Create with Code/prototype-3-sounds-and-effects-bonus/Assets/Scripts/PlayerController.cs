using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true; // to prevent double jump
    public bool gameOver = false;
    public int numberOfJumpings = 2;
    public ParticleSystem explosionParticle; // reference to a ParticleSystem
    public ParticleSystem dirtParticle; // reference to a ParticleSystem
    public AudioClip jumpSound; // reference to sound effect
    public AudioClip crashSound; // reference to sound effect
    private Rigidbody playerRb; // reference to own Rigidbody
    private Animator playerAnim;  // reference to own Animator
    private AudioSource playerAudio; // reference to own AudioSource

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        // Physics.gravity: the gravity applied to all rigid bodies in the Scene.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Make player jump if spacebar pressed
        if(Input.GetKeyDown(KeyCode.Space) && !gameOver && numberOfJumpings > 0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            numberOfJumpings--;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);            

            /* Tip: If you want the physics to feel a little more like a
            double jump normally does in most games, you can reset
            the player's velocity to 0 using "playerRb.velocity = Vector3.zero;"*/
            playerRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            numberOfJumpings = 2;
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
