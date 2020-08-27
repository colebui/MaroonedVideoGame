using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : DamageType {

    [SerializeField] float weaponRange = 1f;
    [SerializeField] float spherecastRadius = 1f;

    // TODO: This needs to be set in the animation at the start
    private bool hitboxActive = false;

    public void SetHitboxActive(int value) {
        if(value == 0) {
            hitboxActive = false;
        }
        else {
            hitboxActive = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(!hitboxActive) { return; }

        HitDetectionThisFrame();
    }

    private void HitDetectionThisFrame() {
        // What we hit with the cast
        RaycastHit hit;

        // First is where to shoot the ray from, next is what direction, then what we hit, and finally the range
        if(Physics.SphereCast(firstPersonCamera.transform.position, spherecastRadius, firstPersonCamera.transform.forward, out hit, weaponRange)) { // If we hit something, and assigns this to "hit"

            Debug.Log("Hit " + hit.transform.name + " with raycast");

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) { return; } // protects against null reference

            float damageToDeal = UnityEngine.Random.Range(minWeaponDamage, maxWeaponDamage); // Simple damage spread
            Debug.Log("Deal " + damageToDeal + " damage to " + target.transform.name);

            target.TakeDamage(damageToDeal);
            hitboxActive = false;
        }
        else { return; } // protects against null reference
    }
}
