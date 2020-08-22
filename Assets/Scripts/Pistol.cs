using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : HitscanWeapon {

    public override void Attack() {
        Debug.Log("Fire!");
        base.ProcessShot();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
    }
}
