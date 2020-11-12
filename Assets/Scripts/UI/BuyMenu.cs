using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoSingleton<BuyMenu> {
    [SerializeField] GameObject BuyMenuContainer;
    [SerializeField] GameObject UpgradesContainer;
    [SerializeField] GameObject PlayerBuyMenu;
    [SerializeField] GameObject SaberBuyMenu;
    [SerializeField] GameObject PistolBuyMenu;
    [SerializeField] GameObject BlunderbussBuyMenu;

    [SerializeField] GameObject moneyText;
    [SerializeField] GameObject moneyTextInBuy;
    

    bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Buy Menu started");
        BuyMenuContainer.SetActive(false);
        UpgradesContainer.SetActive(false);
        PlayerBuyMenu.SetActive(false);
        SaberBuyMenu.SetActive(false);
        PistolBuyMenu.SetActive(false);
        BlunderbussBuyMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {//delete this later testing
            if (!menuOpen) {
                menuOpen = true;
                OpenMainBuyMenu();
            }
            else {
                menuOpen = false;
                CloseAllMenus();
            }
            
        }
    }

    public void OpenMainBuyMenu() {
        Debug.Log("OpenMainBuyMenu()");
        allowCursorMovement();
        BuyMenuContainer.SetActive(true);
        UpgradesContainer.SetActive(true);
        moneyText.SetActive(false);
    }


    public void OpenPlayerBuyMenu() {
        Debug.Log("OpenPlayerBuyMenu()");
        UpgradesContainer.SetActive(false);
        PlayerBuyMenu.SetActive(true);
        //Debug.Log("gameobject: "+GameObject.Find("HealthContainer/UpgradeInfo/CurrentUpgrades"));
        //GameObject.Find("HealthContainer/UpgradeInfo/CurrentUpgrades")
            //.GetComponentInChildren<CurrentUpgradeVisual>()
            //.initializeLevelsVisuals();
    }

    public void OpenSaberBuyMenu() {
        Debug.Log("OpenSaberBuyMenu()");
        UpgradesContainer.SetActive(false);
        SaberBuyMenu.SetActive(true);
    }
    public void OpenPistolBuyMenu() {
        Debug.Log("OpenSaberBuyMenu()");
        UpgradesContainer.SetActive(false);
        PistolBuyMenu.SetActive(true);
    }

    public void OpenBlunderbussBuyMenu() {
        Debug.Log("OpenSaberBuyMenu()");
        UpgradesContainer.SetActive(false);
        BlunderbussBuyMenu.SetActive(true);
    }

    public void CloseAllMenus() {
        Debug.Log("CloseMainBuyMenu()");
        PlayerBuyMenu.SetActive(false);
        UpgradesContainer.SetActive(false);
        BuyMenuContainer.SetActive(false);
        SaberBuyMenu.SetActive(false);
        PistolBuyMenu.SetActive(false);
        moneyText.SetActive(true);
        BlunderbussBuyMenu.SetActive(false);
        stopCursorMovement();
    }

    private void allowCursorMovement() {
        Debug.Log("allowCursor()");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.Instance.PauseGame();
    }

    private void stopCursorMovement() {
        Debug.Log("stopCursor()");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenu.Instance.ResumeGame();
    }
}
