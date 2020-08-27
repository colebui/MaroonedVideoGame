using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : Weapon {

    public override void Attack() {
        base.Attack();
        Debug.Log("Swang saber");
        // FIXME: When we get animations, this is going to need to actually call an animation,
        // FIXME: Which will, in turn, trigger the damage
        ((MeleeDamage)damageType).SetHitboxActive(true);
    }

}
