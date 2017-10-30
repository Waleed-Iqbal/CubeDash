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
        transform.position = player.position + offset;
	}
}
