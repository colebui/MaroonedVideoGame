using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    [SerializeField] int enemyPayout = 100;
    // The amount of time between an enemy death and them disappearing
    [SerializeField] float deathTimer = 1.5f;
    [SerializeField] AudioSource deathSound;
    // TODO: Very basic, just to test
    protected override void Die() {
        FindObjectOfType<GameLogic>().addScore(enemyPayout);

        // Turn off the enemy AI
        GetComponent<EnemyController>().enabled = false;
        // Play the death sound attatched to this object
        deathSound.Play();
        // Set isDead so no more damage is taken
        isDead = true;
        // Set a timer to wait to destroy the object
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}
