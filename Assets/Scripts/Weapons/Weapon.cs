using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class that all weapons should inherit from
// Inherit from this class when making a new weapon, like a sword or gun
// This component must be placed alongside the damage type of the weapon
abstract public class Weapon : MonoBehaviour {

    [SerializeField] private float timeBetweenAttacks;
    // The button in the input manager for firing
    [SerializeField] private string attackButtonName = "Fire1";
    [SerializeField] private float minWeaponDamage = 10;
    [SerializeField] private float maxWeaponDamage = 10;

    private bool canAttack = true;
    protected DamageType damageType;

    // Overridden by the specific weapon, which defines its actual attacking behavior
    public abstract void Attack();

    // Start is called before the first frame update
    void Start() {
        damageType = GetComponent<DamageType>();
        if(damageType == null) {
            Debug.LogError("You MUST add a damage type to this object!");
        }
    }

    // Update is called once per frame
    protected virtual void Update() {
        if(canAttack && Input.GetButtonDown(attackButtonName)) {
            Attack();
            canAttack = false;
            StartCoroutine(DelayAttack());
        }
    }

    IEnumerator DelayAttack() {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    public float GetMinWeaponDamage() { return minWeaponDamage; }
    public float GetMaxWeaponDamage() { return maxWeaponDamage; }

}
