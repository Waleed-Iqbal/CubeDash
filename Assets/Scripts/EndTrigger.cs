﻿using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject completeLevelUI;

    void OnTriggerEnter()
    {
        completeLevelUI.SetActive(true);
        Debug.Log("Game ended");
    }

}
