using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWeapon : Weapon {

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

        // TODO: Start some animation, which calls an attack through an animation event, and then re-enables things after that

        Debug.Log("Shoot power weapon!");
        StartCoroutine(WaitForTimeOrSomething());
    }

    IEnumerator WaitForTimeOrSomething() {
        yield return new WaitForSeconds(1.0f);
        FinishPowerWeaponAttack();
    }

    private void FinishPowerWeaponAttack() {
        playerWeaponManager.EnableOtherWeapons();
    }
}
