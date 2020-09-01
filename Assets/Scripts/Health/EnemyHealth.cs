using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    [SerializeField] int enemyPayout = 100;
    public AudioSource deathSound;
    // TODO: Very basic, just to test
    protected override void Die() {
        FindObjectOfType<GameLogic>().addScore(enemyPayout);
        PlaySound();
        Destroy(gameObject);
    }

    private void PlaySound() {
        //TODO Brendan turn off AI and play Sound "monster_death"

    }
}
