﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : Weapon {

    private static TextMeshProUGUI ammoText;
    private TextMeshProUGUI reloadingText;

    [Header("Ammo System")]
    [SerializeField] int maxAmmoStart = 40;

    private static int maxAmmo;
    private static int currentAmmo;

    protected override void Start() {
        base.Start();

        ammoText = GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<TextMeshProUGUI>();
        reloadingText = GameObject.FindGameObjectWithTag("ReloadingUI").GetComponent<TextMeshProUGUI>();

        maxAmmo = maxAmmoStart;
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

    public static void AddAmmo(int ammountToAdd) {
        currentAmmo = Mathf.Clamp(currentAmmo + ammountToAdd, 0, maxAmmo);
        SetAmmoText();
    }

    public static void AddMaxAmmo(int ammountToAdd)
    {
        maxAmmo += ammountToAdd;
        currentAmmo = maxAmmo;
        SetAmmoText();
    }

    private static void SetAmmoText() {
        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    // No start or update, because they don't need to be overridden
}
