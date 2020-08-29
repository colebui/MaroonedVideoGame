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
        FindObjectOfType<CustomFirstPersonController>().m_MouseLook.lockCursor = false;
        FindObjectOfType<CustomFirstPersonController>().m_MouseLook.XSensitivity = 0;
        FindObjectOfType<CustomFirstPersonController>().m_MouseLook.YSensitivity = 0;
        GameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<PlayerWeaponManager>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
