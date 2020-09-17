using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerWeapon : Weapon {

    //[SerializeField] PlayerWeaponManager playerWeaponManager;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        //playerWeaponManager = GetComponentInParent<PlayerWeaponManager>();
    }

    public override void Attack() {

        base.Attack();

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
