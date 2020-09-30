﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponPickup : MonoBehaviour {

    public enum PowerWeaponType { Blunderbuss, HarpoonGun, HandCannon };

    [SerializeField] PowerWeaponType powerWeaponType;

    private void OnTriggerEnter(Collider other)
    {

        var playerWeaponManager = other.GetComponent<PlayerWeaponManager>();

        if(playerWeaponManager == null) { return; }

        Debug.Log("Player entered");

        switch(powerWeaponType)
        {
            case PowerWeaponType.Blunderbuss:
                FindObjectOfType<Blunderbuss>().AddPowerWeapon();
                break;
            case PowerWeaponType.HandCannon:
                // TODO: Set these up once those weapons are actually made
                break;
            case PowerWeaponType.HarpoonGun:
                break;
        }

        Destroy(gameObject);
    }
}
