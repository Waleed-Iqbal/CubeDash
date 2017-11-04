﻿

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;

	// Update is called once per frame
	void Update ()
    {

        if (FindObjectOfType<GameManager>().hasGameEnded)
            scoreText.text = player.position.z.ToString("Game Over !!");

        else
            scoreText.text = player.position.z.ToString("0");
    }
}
