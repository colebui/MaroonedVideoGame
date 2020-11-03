using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonGun : PowerWeapon
{
    public float projectileVelocity = 5.0f;
    public int enemiesToPierce = 1;

    private ProjectileDamage projectileDamage;

    protected override void Start()
    {
        base.Start();
        projectileDamage = GetComponent<ProjectileDamage>();
    }
    protected override void LaunchAttack()
    {
        projectileDamage.LaunchProjectile();
    }

    //public override void Attack()
    //{
    //    base.Attack();
    //    LaunchAttack();
    //    //Thingy();
    //    //FinishPowerWeaponAttack();
    //}
}
