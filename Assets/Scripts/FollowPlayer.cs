using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset; 

	 // Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        // not moving camera in y-direction, in other words, not move camera upwards when player jumps
        transform.position = new Vector3(player.position.x , transform.position.y + offset.y, player.position.z) + offset;
	}
}
