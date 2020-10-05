using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    static int UPGRADE_COST = 1000;
    //objects
<<<<<<< HEAD
    CustomFirstPersonController FPController = FindObjectOfType<CustomFirstPersonController>();
    PlayerHealth healthGO = FindObjectOfType<PlayerHealth>();
    Pistol pistolGO = FindObjectOfType<Pistol>();
    Saber saberGO = FindObjectOfType<Saber>();
    Blunderbuss blunderbussGO = FindObjectOfType<Blunderbuss>();

    //levels
        //player
=======
    Pistol pistolGO = FindObjectOfType<Pistol>();

    //counters
    int pistolDamageCount = 0;
    int pistolFRCount = 0;
    int pistolAmmoCount = 0;
    //ints
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
    int HPLevel = 0;
    int HPDelayLevel = 0;
    int HPRegenLevel = 0;
    int MaxStaminaLevel = 0;
<<<<<<< HEAD
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
=======
    int MoveSpeedLevel = 0;
    int money = 0;

    //serialized fields
    [SerializeField] int pistolUpDamage = 8;
    [SerializeField] float pistolReduceFireRate = 0.05f;
    [SerializeField] int pistolAddAmmo = 10;
    
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3

    // Start is called before the first frame update
    void Start() {
        
    }

    private void OnEnable() {//setActive(true) https://www.youtube.com/watch?v=OD-p1eMsyrU&ab_channel=Unity
        Debug.Log("Enabled");
    }
    private void OnDisable() {//setActive(false)
        Debug.Log("Disabled");
    }

<<<<<<< HEAD
    public void AddMoney(int amount) {
=======
    void AddMoney(int amount) {
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
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
            throw new Exception("Your broke! get some more money you piece of poop");
        }
    }
<<<<<<< HEAD
    public int getMoney()
    {
        return money;
    }

    void HPIncrease() {
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
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }
    }

    void HPDelayDecrease() {
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
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }
    }

    void HPRegenIncrease() {
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
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
=======

    void HPIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }
        
        HPLevel++;

    }

    void HPDelayDecrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

    void HPRegenIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
        }

    }

    void MaxStaminaIncrease() {
<<<<<<< HEAD
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
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }
    }

    void StaminaRecoveryIncrease() {
        if (staminaRecLevel <= 20)
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

            staminaRecLevel++;
            FPController.SetStaminaRecoveryPerSecond(FPController.GetStaminaRecoveryPerSecond() - staminaRecDec);
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }
=======
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

    }

    void StaminaRecoveryIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
            return;
        }

    }

    void MoveSpeedIncrease() {
        try {
            RemoveMoney();
        }
        catch (Exception exception) {
            Debug.Log("RemoveMoney() returned exception: " + exception);
        }

>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
    }

    //weapon upgrades
    void pistolDamageUp()
    {
<<<<<<< HEAD
        if (pistolDamageLevel <= 20)
=======
        if (pistolDamageCount >= 20)
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
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

            pistolGO.SetMaxWeaponDamage(pistolGO.GetMaxWeaponDamage() + pistolUpDamage);
<<<<<<< HEAD
            pistolDamageLevel++;
=======
            pistolDamageCount++;
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }

    void pistolFireRate()
    {
<<<<<<< HEAD
        if (pistolFRLevel <= 20)
=======
        if (pistolFRCount >= 20)
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
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

            pistolGO.SetTimeBetweenAttacks(pistolGO.GetTimeBetweenAttacks() - pistolReduceFireRate);
<<<<<<< HEAD
            pistolFRLevel++;
=======
            pistolFRCount++;
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }
    void pistolMaxAmmo()
    {
<<<<<<< HEAD
        if (pistolAmmoLevel <= 20)
=======
        if (pistolAmmoCount >= 20)
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
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

            //change to ammo
            //pistolGO.SetMaxAmmo(pistolGO.GetMaxAmmo() + pistolAddAmmo);
            Pistol.AddMaxAmmo(pistolAddAmmo);
<<<<<<< HEAD
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
=======
            pistolAmmoCount++;
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
            return;
        }
        else
        {
            throw new Exception("Your at max upgrades, are you kidding you want more after all ive done for you!");
        }

    }
<<<<<<< HEAD

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

=======
>>>>>>> 905bb2bd51f21a8d32e6f01797daef1069ce6ec3
}
