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
    public float dashSpeed = 1.0f; // to control the dash speed
    public bool introFinished = false; // to control when the intro finishes
    public ParticleSystem explosionParticle; // reference to a ParticleSystem
    public ParticleSystem dirtParticle; // reference to a ParticleSystem
    public AudioClip jumpSound; // reference to sound effect
    public AudioClip crashSound; // reference to sound effect
    private Rigidbody playerRb; // reference to own Rigidbody
    private Animator playerAnim;  // reference to own Animator
    private AudioSource playerAudio; // reference to own AudioSource
    private float introSpeed = 2.0f;

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
        if (transform.position.x < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * introSpeed);
        }
        else
        {
            introFinished = true;
            playerAnim.SetFloat("Speed_f", 1.0f);
        }

        // Make player jump if spacebar pressed
        Jump();

        // Double speed if horizontal keys are pressed
        Dash();
    }

    void Jump()
    {
        if(introFinished && Input.GetKeyDown(KeyCode.Space) && !gameOver && numberOfJumpings > 0)
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

    void Dash()
    {
        if (introFinished && isOnGround)
        {
            if (Input.GetButton("Horizontal")) // left control
            {
                dashSpeed = 2.0f;
                playerAnim.speed = dashSpeed;
            }

            if (!Input.GetButton("Horizontal")) // left control
            {
                dashSpeed = 1.0f;
                playerAnim.speed = dashSpeed;
            }
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
