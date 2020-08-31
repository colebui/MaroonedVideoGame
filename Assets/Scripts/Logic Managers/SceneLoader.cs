using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Loads scenes using these functions
public class SceneLoader : MonoBehaviour {

    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadScene(string sceneToLoad) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene() {
        Debug.Log("Called");
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
