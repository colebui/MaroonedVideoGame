using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blunderbuss : PowerWeapon {

    // TODO: Definitely a placeholder, gonna need to change this (and probably the base class) to have actual icons at some point
    [SerializeField] TextMeshProUGUI CDText;

    protected override void LaunchAttack() {
        Debug.Log("called");
    }

    protected override void Update() {
        base.Update();
        CDText.text = "Blunderbuss CD: " + Mathf.Clamp((timeBetweenAttacks - timeSinceAttacking), 0f, timeBetweenAttacks).ToString("0.00");
    }

}
