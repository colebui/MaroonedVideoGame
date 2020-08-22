using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class that all weapons should inherit from
abstract public class Weapon : MonoBehaviour {

    [SerializeField] private float timeBetweenAttacks;
    // The button in the input manager for firing
    [SerializeField] private string attackButtonName = "Fire1";
    [SerializeField] protected Camera firstPersonCamera;
    [SerializeField] protected float minWeaponDamage = 10;
    [SerializeField] protected float maxWeaponDamage = 10;

    private bool canAttack = true;

    public abstract void Attack();

    // Start is called before the first frame update
    void Start() {

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

}
