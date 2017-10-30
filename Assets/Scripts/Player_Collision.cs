using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour {


    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag ==  "Obstacle")
        {
            Debug.Log("Obstacle hit");
        }
    }
}
