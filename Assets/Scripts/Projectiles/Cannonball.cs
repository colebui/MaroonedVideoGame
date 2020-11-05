using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectile
{
    float fuse;
    float radius;

    public override void Init()
    {
        HandCannon handCannon = (HandCannon)owner.projectileWeapon;
        fuse = handCannon.bombFuse;
        radius = handCannon.bombRadius;
    }

    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(fuse);

        Debug.Log("radius: " + radius);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
