using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    public override void Attack() {
        base.Attack();
        Debug.Log("Fired pistol");
        ((HitscanDamage)damageType).ProcessShot();
    }

    // No start or update, because they don't need to be overridden
}
