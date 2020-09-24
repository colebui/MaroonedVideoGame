using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    static int UPGRADE_COST = 1000;

    int HPLevel = 0;
    int HPDelayLevel = 0;
    int HPRegenLevel = 0;
    int MaxStaminaLevel = 0;
    int MoveSpeedLevel = 0;


    // Start is called before the first frame update
    void Start() {
        
    }

    private void OnEnable() {//setActive(true) https://www.youtube.com/watch?v=OD-p1eMsyrU&ab_channel=Unity
        Debug.Log("Enabled");
    }
    private void OnDisable() {//setActive(false)
        Debug.Log("Disabled");
    }

    void AddMoney() {
        //austin
    }

    void RemoveMoney(int cost) {
        //austin
        //can you throw exception "Not Enough Money" if not enough skill points
    }

    void HPIncrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }
        
        HPLevel++;

    }

    void HPDelayDecrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

    void HPRegenIncrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

    void MaxStaminaIncrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

    void StaminaRecoveryIncrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
            return;
        }

    }

    void MoveSpeedIncrease() {
        try {
            RemoveMoney(UPGRADE_COST);
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

}
