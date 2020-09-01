﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script will handle things like game state, player death, score, etc
public class GameLogic : MonoBehaviour {

    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start() {
        // Set score text
        scoreText.text = "Score: " + score;

        GameOverCanvas.gameObject.SetActive(false);
    }

    public void Update() {
        //Debug.Log("Score is: " + score);
    }

    public void PlayerDied() {
        // Gets this to prevent the script from automatically reverting what we do here and disable mouse look
        CustomFirstPersonController playerController = FindObjectOfType<CustomFirstPersonController>();
        playerController.m_MouseLook.lockCursor = false;
        playerController.m_MouseLook.XSensitivity = 0;
        playerController.m_MouseLook.YSensitivity = 0;

        // Typical game over stuff, load the game over screen
        GameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<PlayerWeaponManager>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //getters
    public int getScore() {
        return score;
    }

    //setters
    public void setScore(int s) {
        score = s;
        // Set score text
        scoreText.text = "Score: " + score;
    }
    public void addScore(int s) {
        score += s;
        // Set score text
        scoreText.text = "Score: " + score;
        Debug.Log("Score is: " + score);
    }
}
