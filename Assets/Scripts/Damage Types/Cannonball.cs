using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectile
{
    // Empty to override behavior from Projectile.cs
    protected override void OnTriggerEnter(Collider other) { }

    public override void Init()
    {
        HandCannon handCannon = (HandCannon)owner.projectileWeapon;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
