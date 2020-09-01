using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    [SerializeField] int enemyPayout = 100;
    public AudioSource audioSource;
    public static AudioClip deathSound;
    // TODO: Very basic, just to test
    protected override void Die() {
        FindObjectOfType<GameLogic>().addScore(enemyPayout);
        PlaySound();
        Destroy(gameObject);
    }

    private void PlaySound() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(deathSound, 0.5f);
    }
}
