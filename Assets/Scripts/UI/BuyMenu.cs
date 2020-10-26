using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoSingleton<BuyMenu> {
    [SerializeField] GameObject BuyMenuContainer;
    [SerializeField] GameObject UpgradesContainer;
    [SerializeField] GameObject PlayerBuyMenu;

    bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        BuyMenuContainer.SetActive(false);
        UpgradesContainer.SetActive(false);
        PlayerBuyMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {//delete this later testing
            if (!menuOpen) {
                OpenMainBuyMenu();
            }
            else {
                CloseAllMenus();
            }
            
        }
    }

    public void OpenMainBuyMenu() {
        Debug.Log("OpenMainBuyMenu()");
        allowCursorMovement();
        BuyMenuContainer.SetActive(true);
        UpgradesContainer.SetActive(true);
    }


    public void OpenPlayerBuyMenu() {
        Debug.Log("OpenPlayerBuyMenu()");
        UpgradesContainer.SetActive(false);
        PlayerBuyMenu.SetActive(true);
    }

    public void CloseAllMenus() {
        PlayerBuyMenu.SetActive(false);
        UpgradesContainer.SetActive(false);
        BuyMenuContainer.SetActive(false);
        stopCursorMovement();
    }

    private void allowCursorMovement() {
        Debug.Log("allowcursor()");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void stopCursorMovement() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
