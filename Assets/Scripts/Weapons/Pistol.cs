using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : Weapon {

    private TextMeshProUGUI ammoText;
    private TextMeshProUGUI reloadingText;

    [Header("Ammo System")]
    [SerializeField] int maxAmmo = 20;
    [SerializeField] int currentAmmo;

    protected override void Start() {
        base.Start();

        ammoText = GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<TextMeshProUGUI>();
        reloadingText = GameObject.FindGameObjectWithTag("ReloadingUI").GetComponent<TextMeshProUGUI>();

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
