using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerWeapon : Weapon {

    private PlayerWeaponManager playerWeaponManager;

    // Start is called before the first frame update
    void Start() {
        base.Start();
        playerWeaponManager = GetComponentInParent<PlayerWeaponManager>();
    }

    // Update is called once per frame
    void Update() {
        // Needs to be empty so the Weapon update isn't called
    }

    public override void Attack() {
        // TODO: Put some code in here for locking other weapons and switching to the power weapon
        // TODO: Then unlock and switch back after the attack is launched
        playerWeaponManager.EnableOtherWeapons();
    }
}
