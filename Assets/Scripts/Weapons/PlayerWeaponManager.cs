﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour {

    [SerializeField] Weapon[] standardWeapons;
    [SerializeField] PowerWeapon[] powerWeapons;

    private Weapon currentlySelectedWeapon;
    private int currentlySelectedWeaponIndex = 0;
    private bool powerWeaponInUse = false;

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
        if(powerWeaponInUse) { return; }

        if(Input.GetButtonDown("Switch Weapon")) {
            HandleWeaponSwitch();
        }

        if(currentlySelectedWeapon.GetCanAttack() && Input.GetButtonDown(currentlySelectedWeapon.GetAttackButtonName())) {
            currentlySelectedWeapon.Attack();
            currentlySelectedWeapon.SetCanAttack(false);
        }

        foreach(PowerWeapon powerWeapon in powerWeapons) {
            if(Input.GetButtonDown(powerWeapon.GetAttackButtonName())) {
                // TODO: Replace this with starting an animation that calls this method in an event
                // TODO: Also needs to lock all other weapons, which will need to happen on switch, as well
                // TODO: Probably a good idea to use each weapon's canAttack member for that
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

    // TODO: Needs work, will be called by the power weapon
    public void EnableOtherWeapons() {
        currentlySelectedWeapon.gameObject.SetActive(true);
        powerWeaponInUse = false;
    }
}
