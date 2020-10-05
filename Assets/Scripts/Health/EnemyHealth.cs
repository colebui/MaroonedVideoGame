using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    // TODO: Very basic, just to test
    protected override void Die() {
<<<<<<< Updated upstream
=======
        GameLogic.Instance.addScore(enemyPayout);
        FindObjectOfType<Shop>().AddMoney(enemyPayout);

        // Turn off the enemy AI
        var enemyAI = GetComponent<EnemyController>();
        enemyAI.StopAllCoroutines();
        enemyAI.enabled = false;
        GetComponent<NavMeshAgent>().speed = 0;
        // Play the death sound attatched to this object
        deathSound.Play();
        // Set isDead so no more damage is taken
        isDead = true;
        // Set a timer to wait to destroy the object
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(deathTimer);
>>>>>>> Stashed changes
        Destroy(gameObject);
    }
}
