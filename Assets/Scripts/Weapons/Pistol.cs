using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : Weapon {

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI reloadingText;

    [Header("Ammo System")]
    [SerializeField] int maxAmmo = 20;
    [SerializeField] int currentAmmo;

    protected override void Start() {
        base.Start();
        currentAmmo = maxAmmo;
        SetAmmoText();
    }

    protected override void Update() {
        base.Update();
        reloadingText.text = "Reloading " + Mathf.Clamp((timeBetweenAttacks - timeSinceAttacking), 0f, timeBetweenAttacks).ToString("0.00");
    }

    public override void Attack() {

        if(currentAmmo <= 0) { return; }

        base.Attack();
        Debug.Log("Fired pistol");
        ((HitscanDamage)damageType).ProcessShot();

        currentAmmo--;
        SetAmmoText();
    }

    public void AddAmmo(int ammountToAdd) {
        currentAmmo = Mathf.Clamp(currentAmmo + ammountToAdd, 0, maxAmmo);
        SetAmmoText();
    }

    private void SetAmmoText() {
        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    // No start or update, because they don't need to be overridden
}
