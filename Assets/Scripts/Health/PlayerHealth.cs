using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

    protected override void Die() {
        Debug.Log("Blegh");
        FindObjectOfType<GameLogic>().PlayerDied();
    }
}
