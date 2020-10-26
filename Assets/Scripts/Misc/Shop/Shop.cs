using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    static int UPGRADE_COST = 1000;
    //objects
    CustomFirstPersonController FPController = FindObjectOfType<CustomFirstPersonController>();
    PlayerHealth healthGO = FindObjectOfType<PlayerHealth>();
    Pistol pistolGO = FindObjectOfType<Pistol>();
    Saber saberGO = FindObjectOfType<Saber>();
    Blunderbuss blunderbussGO = FindObjectOfType<Blunderbuss>();

            //levels
    //player
    int HPLevel = 0;
    int HPDelayLevel = 0;
    int HPRegenLevel = 0;
    int MaxStaminaLevel = 0;
    int staminaRecLevel = 0;
    //pistol
    int pistolDamageLevel = 0;
    int pistolFRLevel = 0;
    int pistolAmmoLevel = 0;
    //saber
    int saberDamageLevel = 0;
    //blunderbuss
    int blunderDamageLevel = 0;
    int blunderFRLevel = 0;
    //harpoon
    //ints
    int money = 0;

            //serialized fields
    //player
    [SerializeField] int maxHealthAdd = 10;
    [SerializeField] float regenTimerReduc = 0.01f;
    [SerializeField] float healthRegenPerSec = 0.10f;
    [SerializeField] int staminaAdd = 10;
    [SerializeField] float staminaRecDec = 0.10f;
    //pistol
    [SerializeField] int pistolUpDamage = 8;
    [SerializeField] float pistolReduceFireRate = 0.05f;
    [SerializeField] int pistolAddAmmo = 10;
    //saber
    [SerializeField] int saberUpDamage = 10;
    //blunderbuss
    [SerializeField] int blunderUpDamage = 8;
    [SerializeField] float blunderReduceFireRate = 0.05f;
    //harpoon

    // Start is called before the first frame update
    void Start() {
        
    }

    private void OnEnable() {//setActive(true) https://www.youtube.com/watch?v=OD-p1eMsyrU&ab_channel=Unity
        Debug.Log("Enabled");
    }
    private void OnDisable() {//setActive(false)
        Debug.Log("Disabled");
    }

    public void AddMoney(int amount) {
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

    void HPIncrease()
    {
        try
        {
            if (HPLevel <= 20)
            {
                try
                {
                    RemoveMoney();
                }
                catch (Exception exception)
                {
                    Debug.Log("RemoveMoney() returned exception: " + exception);
                }

                HPLevel++;
                healthGO.SetMaxHealth(healthGO.GetMaxHealth() + maxHealthAdd);
            }
        }
        catch (Exception exception)
        {
            Debug.Log("RemoveMoney() from HPIncrease() returned exception: " + exception);
        }
    }

    void HPDelayDecrease()
    {
        try
        {
            if (HPDelayLevel <= 20)
            {
                try
                {
                    RemoveMoney();
                }
                catch (Exception exception)
                {
                    Debug.Log("RemoveMoney() returned exception: " + exception);
                }
                HPDelayLevel++;
                healthGO.SetHealthRegenTimer(healthGO.GetHealthRegenTimer() - regenTimerReduc);
            }
        }
        catch (Exception exception)
        {
            Debug.Log("RemoveMoney() from HPDelayDecrease() returned exception: " + exception);

        }
    }

    void HPRegenIncrease()
    {
        try
        {
            if (HPRegenLevel <= 20)
            {
                try
                {
                    RemoveMoney();
                }
                catch (Exception exception)
                {
                    Debug.Log("RemoveMoney() returned exception: " + exception);
                }

                HPRegenLevel++;
                healthGO.SetHealthRegenPerSecond(healthGO.GetHealthRegenPerSecond() + healthRegenPerSec);
            }
        }

        catch (Exception exception)
        {
            Debug.Log("RemoveMoney() from HPRegenIncrease() returned exception: " + exception);
        }

    }

    void MaxStaminaIncrease()
    {
        try
        {
            if (MaxStaminaLevel <= 20)
            {
                try
                {
                    RemoveMoney();
                }
                catch (Exception exception)
                {
                    Debug.Log("RemoveMoney() returned exception: " + exception);
                }

                MaxStaminaLevel++;
                FPController.SetMaxStamina(FPController.GetMaxStamina() + staminaAdd);
            }
        }
        catch (Exception exception)
        {
            Debug.Log("RemoveMoney() from MaxStaminaIncrease() from returned exception: " + exception);
        }
    }

    void StaminaRecoveryIncrease()
    {
        if(staminaRecLevel <= 20) { 
            try
            {
                RemoveMoney();
                staminaRecLevel++;
                FPController.SetStaminaRecoveryPerSecond(FPController.GetStaminaRecoveryPerSecond() - staminaRecDec);
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() from MoveSpeedIncrease() returned exception: " + exception);
            }
        }
        
    }

    //weapon upgrades
    void pistolDamageUp()
    {
        if (pistolDamageLevel <= 20)
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
            pistolDamageLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void pistolFireRate()
    {
        if (pistolFRLevel <= 20)
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
            pistolFRLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }
    void pistolMaxAmmo()
    {
        if (pistolAmmoLevel <= 20)
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
            pistolAmmoLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void saberDamageUp()
    {
        if (saberDamageLevel <= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() returned exception: " + exception);
                return;
            }

            saberGO.SetMaxWeaponDamage(saberGO.GetMaxWeaponDamage() + saberUpDamage);
            saberDamageLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void blunderDamageUp()
    {
        if (blunderDamageLevel <= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() returned exception: " + exception);
                return;
            }

            blunderbussGO.SetMaxWeaponDamage(blunderbussGO.GetMaxWeaponDamage() + blunderUpDamage);
            blunderDamageLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void blunderFireRate()
    {
        if (blunderFRLevel <= 20)
        {
            try
            {
                RemoveMoney();
            }
            catch (Exception exception)
            {
                Debug.Log("RemoveMoney() returned exception: " + exception);
                return;
            }

            blunderbussGO.SetTimeBetweenAttacks(blunderbussGO.GetTimeBetweenAttacks() - blunderReduceFireRate);
            blunderFRLevel++;
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

}