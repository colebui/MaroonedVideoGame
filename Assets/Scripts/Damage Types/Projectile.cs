using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[HideInInspector] public int enemiesToPierce;
    [HideInInspector] public ProjectileDamage owner;

    private int enemiesPierced = 0;

    public virtual void Init() { }

    protected virtual void OnTriggerEnter(Collider other)
    {
        HarpoonGun harpoonGun = (HarpoonGun)owner.projectileWeapon;

        if(enemiesPierced >= harpoonGun.enemiesToPierce) { return; }

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            Debug.Log("Hit enemy!!");
            owner.CallOnHitRegistered();
            enemiesPierced++;
            enemyHealth.TakeDamage(Random.Range(owner.projectileWeapon.GetMinWeaponDamage(), owner.projectileWeapon.GetMaxWeaponDamage()));
        }
    }
}
