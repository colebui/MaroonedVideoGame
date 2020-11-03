using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[HideInInspector] public int enemiesToPierce;
    [HideInInspector] public ProjectileDamage owner;

    private int enemiesPierced = 0;

    // TODO: Fuck rigidbodies, make your own goddamn gravity if that's all you need

    private void OnTriggerEnter(Collider other)
    {
        if(enemiesPierced >= owner.harpoonGun.enemiesToPierce) { return; }

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            Debug.Log("Hit enemy!!");
            owner.CallOnHitRegistered();
            enemiesPierced++;
            enemyHealth.TakeDamage(Random.Range(owner.harpoonGun.GetMinWeaponDamage(), owner.harpoonGun.GetMaxWeaponDamage()));
        }
    }
}
