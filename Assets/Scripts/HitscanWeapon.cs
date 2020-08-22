﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class HitscanWeapon : Weapon {

    [SerializeField] float weaponRange = 100f;

    protected virtual void ProcessShot() {
        ProcessShotWithDeviation(0f);
    }

    protected virtual void ProcessShot(float shotDeviationFactor) {
        ProcessShotWithDeviation(shotDeviationFactor);
    }

    private void ProcessShotWithDeviation(float shotDeviationFactor) {
        // What we hit with the cast
        RaycastHit hit;

        // Gets a random shot deviation to apply to the center of the screen to make shots not 100% acurrate
        Vector3 shotDeviation = new Vector3(UnityEngine.Random.Range(-shotDeviationFactor, shotDeviationFactor),
            UnityEngine.Random.Range(-shotDeviationFactor, shotDeviationFactor), UnityEngine.Random.Range(-shotDeviationFactor, shotDeviationFactor));

        // First is where to shoot the ray from, next is what direction, then what we hit, and finally the range
        if(Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward + shotDeviation, out hit, weaponRange)) { // If we hit something, and assigns this to "hit"

            Debug.Log("Hit " + hit.transform.name + " with raycast");

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) { return; } // protects against null reference
            target.TakeDamage(UnityEngine.Random.Range(minWeaponDamage, maxWeaponDamage)); // Simple damage spread
        }
        else { return; } // protects against null reference
    }

}
