using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);

    /* We use LateUpdate instead of Update because
     * is particularly useful when we try to calculate
     * the camera's position.
     */
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
