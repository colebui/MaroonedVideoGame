using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] Canvas PrepareCanvas;
    [SerializeField] Canvas TitleCanvas;
    [SerializeField] Text TimerText;
    [SerializeField] string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Hello, World"); 
    }
    public void StartButtonClicked()
    {
        TitleCanvas.gameObject.SetActive(false);
        PrepareCanvas.gameObject.SetActive(true);
    }
    public void PrepareButtonClicked() {
        Time.timeScale = 1;
        SceneLoader.Instance.LoadScene("IslandGame");
    }
}
