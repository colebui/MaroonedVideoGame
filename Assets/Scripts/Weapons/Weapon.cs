using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class that all weapons should inherit from
// Inherit from this class when making a new weapon, like a sword or gun
// This component must be placed alongside the damage type of the weapon
abstract public class Weapon : MonoBehaviour {

    [SerializeField] protected float timeBetweenAttacks;
    // The button in the input manager for firing
    [SerializeField] private string attackButtonName = "Fire1";
    [SerializeField] private float minWeaponDamage = 10;
    [SerializeField] private float maxWeaponDamage = 10;

    protected bool canAttack = true;
    protected DamageType damageType;
    protected PlayerWeaponManager playerWeaponManager;

    // Overridden by the specific weapon, which defines its actual attacking behavior
    public virtual void Attack() {
        canAttack = false;
        playerWeaponManager.SetAllowWeaponSwitching(false);
        StartCoroutine(DelayAttack());
    }

    // Start is called before the first frame update
    protected virtual void Start() {
        damageType = GetComponent<DamageType>();
        if(damageType == null) {
            Debug.LogError("You MUST add a damage type to this object!");
        }

        playerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
    }

    // TODO: Make this like store itself or something so you can't swap spam
    private void OnEnable() {
        canAttack = true;
    }

    //protected virtual void Update() {
    //    if(canAttack && Input.GetButtonDown(attackButtonName)) {
    //        //Attack();
    //        //canAttack = false;
    //    }
    //}

    IEnumerator DelayAttack() {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
        playerWeaponManager.SetAllowWeaponSwitching(true);
    }

    public float GetMinWeaponDamage() { return minWeaponDamage; }
    public float GetMaxWeaponDamage() { return maxWeaponDamage; }
    public string GetAttackButtonName() { return attackButtonName; }
    public bool GetCanAttack() { return canAttack; }
    //public void SetCanAttack(bool value) { this.canAttack = value; }

}
