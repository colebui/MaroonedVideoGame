using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerWeapon : Weapon {

    [SerializeField] string ATTACK_TRIGGER_NAME;

    private Animator animator;

    private bool attackFinished = true;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        animator = GetComponent<Animator>();
    }

    public override void Attack() {

        base.Attack();

        Debug.Log("Shoot power weapon!");

        attackFinished = false;

        // Start animation
        animator.SetTrigger(ATTACK_TRIGGER_NAME);
    }

    // Is called by an animation event to actually do the damage and stuff
    protected abstract void LaunchAttack();

    // Is called by animation event to finish the attack up
    private void FinishPowerWeaponAttack() {
        attackFinished = true;
        playerWeaponManager.EnableOtherWeapons();
    }

    IEnumerator WaitForTimeOrSomething() {
        yield return new WaitForSeconds(1.0f);
        FinishPowerWeaponAttack();
    }

    protected override void Update() {
        base.Update();

        // Makes the cooldown only actually count once the attack is over
        if(!attackFinished) {
            timeSinceAttacking = 0;
        }
    }

    public void AddPowerWeapon() {
        playerWeaponManager.AddPowerWeapon(this);
    }
}
