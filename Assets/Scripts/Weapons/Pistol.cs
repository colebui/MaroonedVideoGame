using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : Weapon {

    [SerializeField] TextMeshProUGUI reloadingText;

    protected override void Update() {
        base.Update();
        reloadingText.text = "Reloading " + Mathf.Clamp((timeBetweenAttacks - timeSinceAttacking), 0f, timeBetweenAttacks).ToString("0.00");
    }

    public override void Attack() {
        base.Attack();
        Debug.Log("Fired pistol");
        ((HitscanDamage)damageType).ProcessShot();
    }

    // No start or update, because they don't need to be overridden
}
