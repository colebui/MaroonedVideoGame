using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerWeapon : Weapon {

    private bool attackFinished = true;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
    }

    public override void Attack() {

        base.Attack();

        // TODO: Start some animation, which calls an attack through an animation event, and then re-enables things after that

        Debug.Log("Shoot power weapon!");

        attackFinished = false;

        StartCoroutine(WaitForTimeOrSomething());
    }

    IEnumerator WaitForTimeOrSomething() {
        yield return new WaitForSeconds(1.0f);
        FinishPowerWeaponAttack();
    }

    private void FinishPowerWeaponAttack() {
        attackFinished = true;
        playerWeaponManager.EnableOtherWeapons();
    }

    protected override void Update() {
        base.Update();

        // Makes the cooldown only actually count once the attack is over
        if(!attackFinished) {
            timeSinceAttacking = 0;
        }
    }
}
