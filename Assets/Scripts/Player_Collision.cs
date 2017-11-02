using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour {

    public Player_Movement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag ==  "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
