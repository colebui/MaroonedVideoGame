using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoSingleton<PauseMenu>
{

    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject ConfirmCanvas;

    public bool isPaused { get; private set; }

    private void Start()
    {
        PauseCanvas.SetActive(false);
        ConfirmCanvas.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
        PauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        ConfirmCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        //SceneLoader.Instance.ReloadScene();
        ShowConfirmationMenu();
    }

    public void ReturnToMenu()
    {
        ShowConfirmationMenu();
    }

    public void QuitGame()
    {
        ShowConfirmationMenu();
    }

    public void Confirm()
    {

    }

    public void Deny()
    {
        ConfirmCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
    }

    private void ShowConfirmationMenu()
    {
        PauseCanvas.SetActive(false);
        ConfirmCanvas.SetActive(true);
    }
}
