using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Health : MonoBehaviour {

    [SerializeField] protected float maxHealth = 100f;

    // TODO: Should not be serialized, just is now for debugging
    [SerializeField] protected float currentHealth = 0f;

    protected virtual void Start() {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageToTake) {
        currentHealth -= damageToTake;
        //Debug.Log("Current HP"+currentHealth);
        if (currentHealth <= 0) {
            Die();
        }

    }

    // Overridden by the type of entity with health
    protected abstract void Die();
}
