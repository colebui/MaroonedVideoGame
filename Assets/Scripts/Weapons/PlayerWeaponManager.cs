using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoSingleton<PlayerWeaponManager> {

    [SerializeField] Weapon[] standardWeapons;

    [SerializeField] bool isFullAuto = false;

    List<PowerWeapon> powerWeapons = new List<PowerWeapon>();

    private Weapon currentlySelectedWeapon;
    private int currentlySelectedWeaponIndex = 0;
    private bool powerWeaponInUse = false;
    private bool allowWeaponSwitching = true;

    // Start is called before the first frame update
    void Start() {

        currentlySelectedWeapon = standardWeapons[currentlySelectedWeaponIndex];

        // Disable all weapons but the first one
        foreach(Weapon weap in standardWeapons) {
            weap.gameObject.SetActive(false);
        }
        currentlySelectedWeapon.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {

        // If using a power weapon, then return until it is no longer in use
        if(powerWeaponInUse || PauseMenu.Instance.isPaused) { return; }

        // Switching weapons
        if(Input.GetButtonDown("Switch Weapon") && allowWeaponSwitching) {
            HandleWeaponSwitch();
        }

        // Attacking
        if(isFullAuto)
        {
            if(Input.GetButton(currentlySelectedWeapon.GetAttackButtonName()) && currentlySelectedWeapon.GetCanAttack())
            {
                currentlySelectedWeapon.Attack();
                //currentlySelectedWeapon.SetCanAttack(false);
            }
        }
        else
        {
            if(Input.GetButtonDown(currentlySelectedWeapon.GetAttackButtonName()) && currentlySelectedWeapon.GetCanAttack())
            {
                currentlySelectedWeapon.Attack();
                //currentlySelectedWeapon.SetCanAttack(false);
            }
        }

        foreach(PowerWeapon powerWeapon in powerWeapons) {
            if(Input.GetButtonDown(powerWeapon.GetAttackButtonName()) && powerWeapon.GetCanAttack() && allowWeaponSwitching) {
                DisableCurrentWeapon();
                powerWeapon.Attack();
                powerWeaponInUse = true;
            }
        }

    }

    private void DisableCurrentWeapon() {
        currentlySelectedWeapon.gameObject.SetActive(false);
    }

    private void HandleWeaponSwitch() {
        // Disable previous weapon
        DisableCurrentWeapon();
        // Go to next weapon
        currentlySelectedWeaponIndex++;
        // Loop if needed
        if(currentlySelectedWeaponIndex >= standardWeapons.Length) {
            currentlySelectedWeaponIndex = 0;
        }
        currentlySelectedWeapon = standardWeapons[currentlySelectedWeaponIndex];
        // Enable next weapon
        currentlySelectedWeapon.gameObject.SetActive(true);
    }

    public void SetAllowWeaponSwitching(bool value) {
        allowWeaponSwitching = value;
    }

    public void EnableOtherWeapons() {
        currentlySelectedWeapon.gameObject.SetActive(true);
        powerWeaponInUse = false;
    }

    public void AddPowerWeapon(PowerWeapon powerWeapon) {
        //Debug.LogError("Power weapon added");
        powerWeapons.Add(powerWeapon);
    }

    public Weapon[] GetStandardWeapons() { return standardWeapons; }
    public List<PowerWeapon> GetPowerWeapons() { return powerWeapons; }
}
