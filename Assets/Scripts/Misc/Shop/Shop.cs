using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    static int UPGRADE_COST = 1000;
    //objects
    Pistol pistolGO = FindObjectOfType<Pistol>();

    //counters
    int pistolDamageCount = 0;
    int pistolFRCount = 0;
    int pistolAmmoCount = 0;
    //ints
    int HPLevel = 0;
    int HPDelayLevel = 0;
    int HPRegenLevel = 0;
    int MaxStaminaLevel = 0;
    int MoveSpeedLevel = 0;
    int money = 0;

    //serialized fields
    [SerializeField] int pistolUpDamage = 8;
    [SerializeField] float pistolReduceFireRate = 0.05f;
    [SerializeField] int pistolAddAmmo = 10;
    

    // Start is called before the first frame update
    void Start() {
        
    }

    private void OnEnable() {//setActive(true) https://www.youtube.com/watch?v=OD-p1eMsyrU&ab_channel=Unity
        Debug.Log("Enabled");
    }
    private void OnDisable() {//setActive(false)
        Debug.Log("Disabled");
    }

    void AddMoney(int amount) {
        //austin
        money += amount;
    }

    private void RemoveMoney() {
        //austin
        //can you throw exception "Not Enough Money" if not enough skill points
        if(money >= UPGRADE_COST)
        {
            money -= UPGRADE_COST;
            return;
        }
        else
        {
            throw new Exception("RemoveMoney() broke: Your broke! get some more money you piece of poop");
        }
    }

    void HPIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from HPIncrease() returned exception: " + exception);
        }
        
        HPLevel++;

    }

    void HPDelayDecrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from HPDelayDecrease() returned exception: " + exception);
        }

    }

    void HPRegenIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from HPRegenIncrease() returned exception: " + exception);
        }

    }

    void MaxStaminaIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from MaxStaminaIncrease() from returned exception: " + exception);
        }

    }

    void StaminaRecoveryIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from StaminaRecoveryIncrease returned exception: " + exception);
            return;
        }

    }

    void MoveSpeedIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() from MoveSpeedIncrease() returned exception: " + exception);
        }

    }

    //weapon upgrades
    void pistolDamageUp()
    {
        if (pistolDamageCount >= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() from pistolDamageUp() returned exception: " + exception);
                return;
            }

            pistolGO.SetMaxWeaponDamage(pistolGO.GetMaxWeaponDamage() + pistolUpDamage);
            pistolDamageCount++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void pistolFireRate()
    {
        if (pistolFRCount >= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() from pistolFireRate() returned exception: " + exception);
                return;
            }

            pistolGO.SetTimeBetweenAttacks(pistolGO.GetTimeBetweenAttacks() - pistolReduceFireRate);
            pistolFRCount++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }
    void pistolMaxAmmo()
    {
        if (pistolAmmoCount >= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() from pistolMaxAmmo() returned exception: " + exception);
                return;
            }

            //change to ammo
            //pistolGO.SetMaxAmmo(pistolGO.GetMaxAmmo() + pistolAddAmmo);
            Pistol.AddMaxAmmo(pistolAddAmmo);
            pistolAmmoCount++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }
}
