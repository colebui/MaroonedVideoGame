using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will handle things like game state, player death, score, etc
public class GameLogic : MonoBehaviour {

    [SerializeField] Canvas GameOverCanvas;

    private void Start() {
        GameOverCanvas.gameObject.SetActive(false);
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

}
