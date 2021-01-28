using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 movement;
    public AudioClip[] audioClipArray;
    public float timeBetweenShots = 0.9f;
    public int playbacks = 3;

    float timer = 0;
    bool toggle = false;

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
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                GetComponent<AudioSource>().PlayOneShot(RandomClip());
                timer = 0;
                playbacks--;
            }
        }

        if(playbacks == -1)
        {
            Destroy(gameObject);
        }

    }

    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
    }
}
