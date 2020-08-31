using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] Canvas PrepareCanvas;
    [SerializeField] Canvas TitleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Hello, World"); 
    }
    void StartPrepMenu()
    {
        TitleCanvas.gameObject.SetActive(false);
        PrepareCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("BrendenTestScene");
    }
    public void StartButtonClicked()
    {
        StartPrepMenu();
    }
}
