using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    // TODO: Very basic, just to test
    protected override void Die() {
        Destroy(gameObject);
    }
}
