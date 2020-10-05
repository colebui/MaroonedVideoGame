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
    IEnumerator StartPrepMenu()
    {
        TitleCanvas.gameObject.SetActive(false);
        PrepareCanvas.gameObject.SetActive(true);
        for (int i = 7; i > -1; i--)
        {
            yield return new WaitForSeconds(1);
            TimerText.text = "*" + i.ToString() + "*";
        }
        Time.timeScale = 1;
        SceneLoader.Instance.LoadScene(nextSceneName);
    }
    public void StartButtonClicked()
    {
        StartCoroutine( StartPrepMenu());
    }
}
