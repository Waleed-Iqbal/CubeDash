using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = new Vector3(0f, 3.5f, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        // not moving camera in y-direction, in other words, not move camera upwards when player jumps
        transform.position = new Vector3(transform.position.x, offset.y, player.position.z + offset.z);
    }
}
