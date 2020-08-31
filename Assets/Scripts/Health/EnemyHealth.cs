using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    [SerializeField] int enemyPayout = 100;

    // TODO: Very basic, just to test
    protected override void Die() {
        FindObjectOfType<GameLogic>().addScore(enemyPayout);
        Destroy(gameObject);
    }
}
